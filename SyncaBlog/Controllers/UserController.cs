using SyncaBlog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyncaBlog.Core.Models;
using SyncaBlog.Models.AccountViewModels;
using System.Web.Security;
using SyncaBlog.Models;

namespace SyncaBlog.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUnitOfWork unit;
        public UserController(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public ActionResult DeletePost(int id)
        {
            try
            {
                var myBlog = unit.Blogs.Get(unit.Users.Get(User.Identity.Name).BlogId).Id;
                var model = unit.Posts.Get(id);
                if (myBlog == model.BlogId || User.IsInRole("moderator"))
                {

                    unit.Posts.Delete(id);
                    unit.Save();
                    return RedirectToAction("Index", "Home", new { page = 1 });
                }
                return new HttpNotFoundResult();
            }
            catch(Exception ex)
            {
                return View("~/Views/Shared/ErrorPage.cshtml");
            }
        }


        List<SelectListItem> TagNames()
        {
            List<Tag> values = new List<Tag>();
            values.AddRange(unit.Tags.GetAll());
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var e in values)
            {
                list.Add(new SelectListItem
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                });
            }
            return list;
        }


        public ActionResult EditPost(int id)
        {
            
                var myBlog = unit.Blogs.Get(unit.Users.Get(User.Identity.Name).BlogId).Id;
                var model = unit.Posts.GetWithInclude(id);
                if (myBlog == model.BlogId || User.IsInRole("moderator"))
                {
                    int countIds = model.MyTag.Count();
                    string[] SelectedIds = new string[countIds];
                    int counter = 0;
                    foreach (Tag t in model.MyTag)
                    {
                        SelectedIds[counter] = t.Id.ToString();
                        counter++;
                    }
                    MultiSelectList tags = new MultiSelectList(unit.Tags.GetAll(), "Id", "Name", SelectedIds);
                    PostEditModel temp = new PostEditModel
                    {
                        Title = model.Title,
                        Text = model.Text,
                        ShortText = model.ShortText,
                        CreationTime = model.CreationTime,
                        Id = model.Id,
                        BlogId = model.BlogId,
                        Tags = tags
                    };
                    return View(temp);
                }
                else
                {
                    return View("~/Views/Shared/ErrorPage.cshtml");
                }
           
        }

        [HttpPost]
        public ActionResult EditPost(PostEditModel post)
        {          
                if (ModelState.IsValid)
                {
                Post temp = unit.Posts.GetWithInclude(post.Id);
                temp.Id = post.Id;
                temp.Title = post.Title;
                temp.Text = post.Text;
                temp.ShortText = post.ShortText;
                temp.CreationTime = post.CreationTime;
                temp.BlogId = post.BlogId;                
                temp.MyTag.Clear();

                if (post.TagSelected == null)
                {
                    temp.MyTag.Add(unit.Tags.Get(1));
                }
                else
                {
                    foreach (var id in post.TagSelected)
                    {
                        var qwer = int.Parse(id);
                        //var tag = unit.Tags.GetWithInclude(qwer);
                        //tag.MyPost.Add(temp);
                          temp.MyTag.Add(unit.Tags.GetWithInclude(qwer));
                    }
                }
                try
                {
                    unit.Posts.Update(temp);
                    unit.Save();
                    return RedirectToAction("PostDetails", "Home", new { id = post.Id, page = 1 });
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("",ex.Message);
                    return View(post);
                }                             
                }
                else
                    return View(post);

        }
        
        

        public ActionResult EditBlog(int id)
        {
            var myBlogId = unit.Blogs.Get(unit.Users.Get(User.Identity.Name).BlogId).Id;
            if (id == myBlogId)
            {
                Blog model = unit.Blogs.Get(id);
                return View(model);
            }
            else
                return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult EditBlog(Blog blog)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    unit.Blogs.Update(blog);
                    unit.Save();
                    return RedirectToAction("MyBlogDetail");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",ex.Message);
                }
            }
            return View(blog);
        }

        public ActionResult CreatePost()
        {
            var tags = unit.Tags.GetAll().ToList();
            MultiSelectList tagsList = new MultiSelectList(tags, "Id", "Name");
            PostCreateModel model = new PostCreateModel() { Tags = tagsList };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePost(PostCreateModel CreatedModel)
        {
            if (ModelState.IsValid)
            {
                Post temp = new Post()
                {
                    CreationTime = DateTime.Now,
                    BlogId = unit.Users.Get(User.Identity.Name).BlogId,
                    Text = CreatedModel.Text,
                    ShortText = CreatedModel.ShortText,
                    Title = CreatedModel.Title
                };
                if (CreatedModel.TagIds == null)
                {
                    temp.MyTag.Add(unit.Tags.Get(1));
                }
                else
                {
                    foreach (var id in CreatedModel.TagIds)
                    {
                        var qwer = int.Parse(id);
                        var tag = unit.Tags.GetWithInclude(qwer);
                        tag.MyPost.Add(temp);
                    }
                }
                try
                {
                    unit.Posts.Create(temp);
                    unit.Save();
                    return RedirectToAction("Index", "Home", new { page = 1 });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(CreatedModel);
                }

            }
            else
            {
                var tags = unit.Tags.GetAll().ToList();
                MultiSelectList tagsList = new MultiSelectList(tags, "Id", "Name");
                CreatedModel.Tags = tagsList;
                return View(CreatedModel);
            }
        }

        public ActionResult MyBlogDetail()
        {
           Blog myBlog = unit.Blogs.GetWithInclude( unit.Users.Get(User.Identity.Name).BlogId);
            return View(myBlog);
;        }

        [HttpPost]
        public ActionResult DeleteComment(int commentId,int postId)
        {
            unit.Comments.Delete(commentId);
            unit.Save();
            return RedirectToAction("PostDetails","Home", new { id=postId,page=1});
            
        }


    }
}