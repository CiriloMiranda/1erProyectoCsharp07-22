using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }

        public byte Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public Usuario()
        {

        }

        /// <summary>
        /// CONSTRUCTOR PARA GET
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nombres"></param>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="sexo"></param>
        /// <param name="nombreUsuario"></param>
        /// <param name="contrasenia"></param>
        /// <param name="estado"></param>
        /// <param name="fechaRegistro"></param>
        /// <param name="fechaActualizacion"></param>
        public Usuario(int idUsuario, string nombres, string primerApellido, string segundoApellido, string sexo, string nombreUsuario, string contrasenia, byte estado, DateTime fechaRegistro, DateTime fechaActualizacion)
        {
            IdUsuario = idUsuario;
            Nombres = nombres;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Sexo = sexo;
            NombreUsuario = nombreUsuario;
            Contrasenia = contrasenia;
            Estado = estado;
            FechaRegistro = fechaRegistro;
            FechaActualizacion = fechaActualizacion;
        }
    }
}
