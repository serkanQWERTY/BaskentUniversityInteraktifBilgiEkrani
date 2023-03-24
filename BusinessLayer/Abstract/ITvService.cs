using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITvService
    {
        List<Tv> GetList();
        void TvAdd(Tv tv);
        Tv GetByID(int id);
        void TvDelete(Tv tv);
        void TvUpdate(Tv tv);
    }
}
