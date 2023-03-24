using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewService
    {
        List<New> GetList();
        void NewAdd(New news);
        New GetByID(int id);
        void NewDelete(New news);
        void NewUpdate(New news);
    }
}
