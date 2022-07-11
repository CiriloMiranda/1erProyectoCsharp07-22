using System;
using System.Collections.Generic;
using System.Data;//
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IDao<T>
    {
        int Insert(T t);
        int Update(T t);
        int Delete(T t);
        DataTable Select();
    }
}
