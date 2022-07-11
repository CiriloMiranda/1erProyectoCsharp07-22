using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // PARA EL DATA TABLE
using DAO.Model; // PARA UTILIZAR EL MODELO

namespace DAO.Interfaces
{
    public interface ISocio : IDao<Socio>
    {
        Socio Get(int id);
    }
}
