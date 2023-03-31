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
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDAL _departmentDAL;

        public DepartmentManager(IDepartmentDAL departmentDAL)
        {
            _departmentDAL = departmentDAL;
        }

        public void DepartmentAdd(Department department)
        {
            _departmentDAL.Insert(department);
        }

        public void DepartmentChangeStatus(Department department)
        {
            if (department.DepartmentStatus == true)
            {
                department.DepartmentStatus = false;
                _departmentDAL.Update(department);
            }
            else if (department.DepartmentStatus == false)
            {
                department.DepartmentStatus = true;
                _departmentDAL.Update(department);
            }
        }

        public void DepartmentDelete(Department department)
        {
            _departmentDAL.Delete(department);
        }

        public void DepartmentUpdate(Department department)
        {
            _departmentDAL.Update(department);
        }

        public Department GetByID(int id)
        {
            return _departmentDAL.Get(x => x.DepartmentID == id);
        }

        public List<Department> GetList()
        {
            return _departmentDAL.List();
        }
    }
}
