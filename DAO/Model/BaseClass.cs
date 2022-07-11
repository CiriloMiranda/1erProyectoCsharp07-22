using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class BaseClass
    {

        public byte Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int IdUsuario { get; set; }

        public BaseClass()
        {

        }

        public BaseClass(byte estado, DateTime fechaRegistro, DateTime fechaActualizacion, int idUsuario)
        {
            Estado = estado;
            FechaRegistro = fechaRegistro;
            FechaActualizacion = fechaActualizacion;
            IdUsuario = idUsuario;
        }
    }
}
