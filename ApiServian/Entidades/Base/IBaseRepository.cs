using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDADES.Base
{
    public interface IBaseRepository<TClass> where TClass : class
    {
        int Delete(int id, string modifiedBy, DateTime modifiedDate);
        IList<TClass> GetAll();
        TClass GetById(int id);
        int Insert(TClass data);
        int Update(TClass data);
    }
}