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
    public class NewManager : INewService
    {
        INewDAL _newDAL;

        public NewManager(INewDAL newDAL)
        {
            _newDAL = newDAL;
        }

        public New GetByID(int id)
        {
            return _newDAL.Get(x => x.NewID == id);
        }

        public List<New> GetList()
        {
            return _newDAL.List();
        }

        public void NewAdd(New news)
        {
            _newDAL.Insert(news);
        }

        public void NewDelete(New news)
        {
            _newDAL.Delete(news);
        }

        public void NewUpdate(New news)
        {
            _newDAL.Update(news);
        }
    }
}
