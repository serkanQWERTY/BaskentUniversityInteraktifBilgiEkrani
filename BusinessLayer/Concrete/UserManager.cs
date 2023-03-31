using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL _userDAL;

        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public User GetByID(int id)
        {
            return _userDAL.Get(x => x.UserID == id);
        }

        public List<User> GetList()
        {
            return _userDAL.List();
        }

        public void UserAdd(User user)
        {
            _userDAL.Insert(user);
        }

        public void UserDelete(User user)
        {
            _userDAL.Delete(user);
        }

        public void UserUpdate(User user)
        {
            _userDAL.Update(user);
        }

        public void UserChangeStatus(User user)
        {
            if (user.UserStatus == true)
            {
                user.UserStatus = false;
                _userDAL.Update(user);
            }
            else if (user.UserStatus == false)
            {
                user.UserStatus = true;
                _userDAL.Update(user);
            }

        }
    }
}
