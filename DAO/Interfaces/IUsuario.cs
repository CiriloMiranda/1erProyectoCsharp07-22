using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // PARA EL DATA TABLE
using DAO.Model; // PARA UTILIZAR EL MODELO

namespace DAO.Interfaces
{
    public interface IUsuario : IDao<Usuario>
    {
        DataTable Login(string userName, string contrasenia);
    }
}
