using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Socio : BaseClass
    {

        public int IdSocio { get; set; }
        public string Ci { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string MatriculaProfesional { get; set; }
        public string LugarTrabajo { get; set; }
        public string FuenteFinanciacion { get; set; }
        public int Celular { get; set; }

        public Socio()
        {

        }
        /// <summary>
        /// CONSTRUCTOR GET
        /// </summary>
        /// <param name="idSocio"></param>
        /// <param name="ci"></param>
        /// <param name="nombres"></param>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="matriculaProfesional"></param>
        /// <param name="lugarTrabajo"></param>
        /// <param name="fuenteFinanciacion"></param>
        /// <param name="celular"></param>
        /// <param name="estado"></param>
        /// <param name="fechaRegistro"></param>
        /// <param name="fechaActualizacion"></param>
        /// <param name="idUsuario"></param>
        public Socio(int idSocio, string ci, string nombres, string primerApellido, string segundoApellido, DateTime fechaNacimiento, string matriculaProfesional, string lugarTrabajo, string fuenteFinanciacion, int celular, byte estado, DateTime fechaRegistro, DateTime fechaActualizacion, int idUsuario)
             : base(estado, fechaRegistro, fechaActualizacion, idUsuario)
        {
            IdSocio = idSocio;
            Ci = ci;
            Nombres = nombres;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            MatriculaProfesional = matriculaProfesional;
            LugarTrabajo = lugarTrabajo;
            FuenteFinanciacion = fuenteFinanciacion;
            Celular = celular;
        }

        /// <summary>
        /// CONSTRUCTOR PARA INSERT
        /// </summary>
        /// <param name="ci"></param>
        /// <param name="nombres"></param>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="matriculaProfesional"></param>
        /// <param name="lugarTrabajo"></param>
        /// <param name="fuenteFinanciacion"></param>
        /// <param name="celular"></param>
        public Socio(string ci, string nombres, string primerApellido, string segundoApellido, DateTime fechaNacimiento, string matriculaProfesional, string lugarTrabajo, string fuenteFinanciacion, int celular)
        {
            Ci = ci;
            Nombres = nombres;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            MatriculaProfesional = matriculaProfesional;
            LugarTrabajo = lugarTrabajo;
            FuenteFinanciacion = fuenteFinanciacion;
            Celular = celular;
        }

        /// <summary>
        /// CONSTRUCTOR PARA ELIMINACION LOGICA
        /// </summary>
        /// <param name="idSocio"></param>
        public Socio(int idSocio)
        {
            IdSocio = idSocio;
        }
    }
}
