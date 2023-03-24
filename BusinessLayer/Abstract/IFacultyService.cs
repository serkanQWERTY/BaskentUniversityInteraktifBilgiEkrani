using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFacultyService
    {
        List<Faculty> GetList();
        void FacultyAdd(Faculty faculty);
        Faculty GetByID(int id);
        void FacultyDelete(Faculty faculty);
        void FacultyUpdate(Faculty faculty);
    }
}
