using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyncaBlog.Core.Repositories;
using SyncaBlog.Core.Interfaces;
using SyncaBlog.Core.Models;
using SyncaBlog.Models;
using SyncaBlog.Infrastructure;

namespace SyncaBlog.Controllers
{
    public class HomeController : Controller
    {
        public const string ALL_TAGS = "...";
        public ActionResult Test()
        {
            return View();
        }
        
        //2rivneva
        private IUnitOfWork unit;
        public HomeController(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public int pageSize = 4;

        public ActionResult Index(int page = 1)
        {

            PostViewModel m1 = new PostViewModel
            {
                Posts = unit.Posts.FindWithInclude().OrderByDescending(e => e.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                Paging = new NumericPagingInfo
                {
                    SelectedPageNumber = page,
                    ItemsPerPage = pageSize,
                    TotalItems = unit.Posts.GetAll().Count()
                    }
                };
            return View(m1);           
        }

        public ActionResult PostDetails(int id, int page = 1)
        {
            try
            {
                Post p = unit.Posts.GetWithInclude(id);
                PostDetailViewModel model = new PostDetailViewModel()
                {
                    Post = p,
                    Comment = new CommentViewModel
                    {
                        Comments = p.MyComment.OrderByDescending(e => e.Id).Skip((page - 1) * pageSize).Take(pageSize),
                        Paging = new NumericPagingInfo
                        {
                            SelectedPageNumber = page,
                            ItemsPerPage = pageSize,
                            TotalItems = p.MyComment.Count
                        },
                        PostId = id
                    }
                    
                };
                return View(model);
            }
            catch(Exception ex)
            {
                return View("~/Views/Shared/ErrorPage.cshtml");
            }
        }

        [HttpPost]
        public RedirectToRouteResult CommentAdd(CommentAddModel model)
        {
            if (ModelState.IsValid)
            {
                Comment c = new Comment() { Description = model.Description, PostId = model.PostId };
                unit.Comments.Create(c);
                unit.Save();
            }
                return RedirectToAction("PostDetails", "Home", new { id = model.PostId, page = 1 });
    }

        public ActionResult TagDetails(int id, int page = 1)
        {
            try
            {
                var tag = unit.Tags.GetWithInclude(id);
                TagDetailViewModel model = new TagDetailViewModel
                {
                    TagName = tag.Name,
                    Posts = tag.MyPost.OrderByDescending(e => e.Id).Skip((page - 1) * pageSize).Take(pageSize),
                    TagId = id,
                    Paging = new NumericPagingInfo
                    {
                        SelectedPageNumber = page,
                        ItemsPerPage = pageSize,
                        TotalItems = tag.MyPost.Count
                    }
                };
                return View(model);
            }
            catch(Exception ex)
            {
                return View("~/Views/Shared/ErrorPage.cshtml");
            }

        }

        public ActionResult BlogDetails(int id)
        {
            Blog blog = unit.Blogs.GetWithInclude(id);
            return View(blog);
        }

        [HttpGet]
        public ActionResult SearchPosts(string SearchString, int page = 1)
        {
                PostViewModel model = new PostViewModel
                {
                    Posts = unit.Posts.Find(e => e.Text.ToLower().Contains(SearchString.ToLower())).OrderByDescending(e => e.Id)
                  .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                    Paging = new NumericPagingInfo
                    {
                        SelectedPageNumber = page,
                        ItemsPerPage = pageSize,
                        TotalItems = unit.Posts.Find(e => e.Text.ToLower().Contains(SearchString.ToLower())).Count()
                    }
                };
                ViewBag.SearchString = SearchString;
                return View(model);
        }

        public PartialViewResult TagMenuPartial()
        {
            var temp = unit.Tags.GetAll().OrderBy(e=>e.Name);
            return PartialView(temp);
        }        
    }
}