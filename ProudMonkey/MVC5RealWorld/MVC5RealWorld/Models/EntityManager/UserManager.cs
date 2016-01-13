using MVC5RealWorld.Models.DB;
using MVC5RealWorld.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5RealWorld.Models.EntityManager
{
    public class UserManager
    {
        //create new user account
        public void AddUserAccount(UserSignUpView user){

            using (DemoDBEntities db = new DemoDBEntities())
            {
                SYSUser SU = new SYSUser();
                SU.LoginName = user.LoginName;
                SU.PasswordEncryptedText = user.Password;
                SU.RowCreatedSYSUserID = user.SYSuserId > 0 ? user.SYSuserId : 1;
                SU.RowModifiedSYSUserID = user.SYSuserId > 0 ? user.SYSuserId : 1;
                SU.RowCreatedDateTime = DateTime.Now;
                SU.RowMOdifiedDateTime = DateTime.Now;

                db.SYSUsers.Add(SU);
                db.SaveChanges();

                SYSUserProfile SUP = new SYSUserProfile();
                SUP.SYSUserID = SU.SYSUserID;
                SUP.FirstName = user.FirstName;
                SUP.LastName = user.LastName;
                SUP.Gender = user.Gender;
                SUP.RowCreatedSYSUserID = user.SYSuserId > 0 ? user.SYSuserId : 1;
                SUP.RowModifiedSYSUserID = user.SYSuserId > 0 ? user.SYSuserId : 1;
                SUP.RowCreatedDateTime = DateTime.Now;
                SUP.RowModifiedDateTime = DateTime.Now;

                db.SYSUserProfiles.Add(SUP);
                db.SaveChanges();

                if (user.LOOKUPRoleId > 0)
                {
                    SYSUserRole SUR = new SYSUserRole();
                    SUR.LOOKUPRoleID = user.LOOKUPRoleId;
                    SUR.SYSUserID = user.SYSuserId;
                    SUR.IsActive = true;
                    SUR.RowCreatedSYSUserID = user.SYSuserId > 0 ? user.SYSuserId : 1;
                    SUR.RowModifiedSYSUserID = user.SYSuserId > 0 ? user.SYSuserId : 1;
                    SUR.RowCreatedDateTime = DateTime.Now;
                    SUR.RowModifiedDateTime = DateTime.Now;
                    db.SYSUserRoles.Add(SUR);
                    db.SaveChanges();
                }
            }

        }
        //checks whether the use exists or not
        public bool IsLoginNameExist(string loginName)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                return db.SYSUsers.Where(o => o.LoginName.Equals(loginName)).Any();
            }
        }

        //get the user passwords
        public string GetUSerPassword(string loginName)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                var user = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().PasswordEncryptedText;
                else
                    return string.Empty;
            }
        }

       public bool IsUserInRole(string loginName, string roleName) {  
            using (DemoDBEntities db = new DemoDBEntities()) {
                SYSUser SU = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName)).FirstOrDefault();
                if (SU != null) {
                    var roles = from q in db.SYSUserRoles
                                join r in db.LOOKUPRoles on q.LOOKUPRoleID equals r.LOOKUPRoleID
                                where r.RoleName.Equals(roleName) && q.SYSUserID.Equals(SU.SYSUserID)
                                select r.RoleName;

                    if (roles != null) {
                        return roles.Any();
                    }
                }

                return false;
            }
        }
    }
}