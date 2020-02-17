using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncaBlog.Core.EF;
using SyncaBlog.Core.Models;
using System.Data.Entity;
using System.Web.Security;




namespace SyncaBlog.Core.Providers
{

    public class CustomRoleProvider : RoleProvider
    {

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (MyContext db = new MyContext())
            {
                // Получаем пользователя
                User user = db.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == username);
                if (user != null && user.Role != null)
                {
                    // получаем роль
                    roles = new string[] { user.Role.Name };
                }
                return roles;
            }
        }
       
        public override bool IsUserInRole(string username, string roleName)
        {
            using (MyContext db = new MyContext())
            {
                // Получаем пользователя
                User user = db.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == username);
                
                if (user != null && user.Role != null && user.Role.Name == roleName)
                    return true;
                else
                    return false;
            }
        }


        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }



        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

     

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            using (MyContext db = new MyContext())
            {

                var roles = db.Roles.ToList();
                var str = new string[roles.Count];
                int i = 0;
                foreach(var item in roles)
                {
                    str[i] = item.Name;
                    i++;
                }
                return str;
            }

        }

        

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

       

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }

}
