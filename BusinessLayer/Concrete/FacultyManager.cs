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
    public class FacultyManager : IFacultyService
    {
        IFacultyDAL _facultyDAL;

        public FacultyManager(IFacultyDAL facultyDAL)
        {
            _facultyDAL = facultyDAL;
        }

        public void FacultyAdd(Faculty faculty)
        {
            _facultyDAL.Insert(faculty);
        }

        public void FacultyDelete(Faculty faculty)
        {
            _facultyDAL.Delete(faculty);
        }

        public void FacultyUpdate(Faculty faculty)
        {
            _facultyDAL.Update(faculty);
        }

        public void FacultyChangeStatus(Faculty faculty)
        {
            if (faculty.FacultyStatus == true)
            {
                faculty.FacultyStatus = false;
                _facultyDAL.Update(faculty);
            }
            else if (faculty.FacultyStatus == false)
            {
                faculty.FacultyStatus = true;
                _facultyDAL.Update(faculty);
            }
        }

        public Faculty GetByID(int id)
        {
            return _facultyDAL.Get(x => x.FacultyID == id);
        }

        public List<Faculty> GetList()
        {
            return _facultyDAL.List();
        }
    }
}
