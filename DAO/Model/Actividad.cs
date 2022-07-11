using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Actividad : BaseClass
    {

        public int IdActividad { get; set; }
        public string NombreActividad { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaActividad { get; set; }
        public float CostoActividad { get; set; }

        public Actividad()
        {

        }

        /// <summary>
        /// CONSTRUCTOR GET
        /// </summary>
        /// <param name="idActividad"></param>
        /// <param name="nombreActividad"></param>
        /// <param name="descripcion"></param>
        /// <param name="fechaActividad"></param>
        /// <param name="costoActividad"></param>
        /// <param name="estado"></param>
        /// <param name="fechaRegistro"></param>
        /// <param name="fechaActualizacion"></param>
        /// <param name="idUsuario"></param>
        public Actividad(int idActividad, string nombreActividad, string descripcion, DateTime fechaActividad, float costoActividad, byte estado, DateTime fechaRegistro, DateTime fechaActualizacion, int idUsuario)
            : base(estado, fechaRegistro, fechaActualizacion, idUsuario)
        {

            IdActividad = idActividad;
            NombreActividad = nombreActividad;
            Descripcion = descripcion;
            FechaActividad = fechaActividad;
            CostoActividad = costoActividad;
        }

        /// <summary>
        /// CONSTRUCTOR PARA INSERT
        /// </summary>
        /// <param name="nombreActividad"></param>
        /// <param name="descripcion"></param>
        /// <param name="fechaActividad"></param>
        /// <param name="costoActividad"></param>
        public Actividad(string nombreActividad, string descripcion, DateTime fechaActividad, float costoActividad)
        {
            NombreActividad = nombreActividad;
            Descripcion = descripcion;
            FechaActividad = fechaActividad;
            CostoActividad = costoActividad;
        }

        /// <summary>
        /// CONSTRUCTOR PARA ELIMINACION LOGICA
        /// </summary>
        /// <param name="idActividad"></param>
        public Actividad(int idActividad)
        {
            IdActividad = idActividad;
        }
    }
}
