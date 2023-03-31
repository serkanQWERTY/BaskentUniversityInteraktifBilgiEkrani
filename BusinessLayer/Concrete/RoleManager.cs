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
    public class RoleManager : IRoleService
    {
        IRoleDAL _roleDAL;

        public RoleManager(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        public Role GetByID(int id)
        {
            return _roleDAL.Get(x => x.RoleID == id);
        }

        public List<Role> GetList()
        {
            return _roleDAL.List();
        }

        public void RoleAdd(Role role)
        {
            _roleDAL.Insert(role);
        }

        public void RoleDelete(Role role)
        {
            _roleDAL.Delete(role);
        }

        public void RoleUpdate(Role role)
        {
            _roleDAL.Update(role);
        }

        public void RoleChangeStatus(Role role)
        {
            if (role.RoleStatus == true)
            {
                role.RoleStatus = false;
                _roleDAL.Update(role);
            }
            else if(role.RoleStatus == false)
            {
                role.RoleStatus = true;
                _roleDAL.Update(role);
            }

        }
    }
}
