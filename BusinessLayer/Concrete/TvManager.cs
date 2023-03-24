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
    public class TvManager : ITvService
    {
        ITvDAL _tvDAL;

        public TvManager(ITvDAL tvDAL)
        {
            _tvDAL = tvDAL;
        }

        public Tv GetByID(int id)
        {
            return _tvDAL.Get(x => x.TvID == id);
        }

        public List<Tv> GetList()
        {
            return _tvDAL.List();
        }

        public void TvAdd(Tv tv)
        {
            _tvDAL.Insert(tv);
        }

        public void TvDelete(Tv tv)
        {
            _tvDAL.Delete(tv);

        }

        public void TvUpdate(Tv tv)
        {
            _tvDAL.Update(tv);
        }
    }
}
