using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Interfaces;//
using DAO.Model;//<
using MySql.Data.MySqlClient;//
using System.Data;//

namespace DAO.Implementation
{
    public class ActividadImpl : DataBase, IActividad
    {
        public int Delete(Actividad t)
        {
            string query = @"UPDATE actividad SET estado = 0, fechaActualizacion = CURRENT_TIMESTAMP, idUsuario = @idUsuario
                            WHERE idActividad = @idActividad";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionID);
            command.Parameters.AddWithValue("@idActividad", t.IdActividad);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                //LOG
                throw ex;
            }
        }

        public Actividad Get(int id)
        {
            Actividad t = null;
            string query = @"SELECT idActividad, nombreActividad, descripcion, fechaActividad, costoActividad, estado, fechaRegistro,
                              fechaActualizacion, idUsuario
                              FROM actividad
                              WHERE idActividad=@id";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable dt = ExecuteDataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    DateTime fecha2;

                    string fech = dt.Rows[0][7].ToString();
                    if (fech == "")
                    {
                        fecha2 = DateTime.Now;
                    }
                    else
                    {
                        fecha2 = DateTime.Parse(dt.Rows[0][7].ToString());
                    }

                    t = new Actividad(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), DateTime.Parse(dt.Rows[0][3].ToString()), float.Parse(dt.Rows[0][4].ToString()), byte.Parse(dt.Rows[0][5].ToString()), DateTime.Parse(dt.Rows[0][6].ToString()), fecha2, int.Parse(dt.Rows[0][8].ToString()));
                }
            }
            catch (Exception ex)
            {
                //LOG
                throw ex;
            }
            return t;
        }

        public int Insert(Actividad t)
        {
            string query = @"INSERT INTO actividad(nombreActividad, descripcion, fechaActividad, costoActividad, idUsuario)
                            VALUES (@nombre, @descripcion, @fechaActividad, @costoActividad, @idUsuario)";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombre", t.NombreActividad);
            command.Parameters.AddWithValue("@descripcion", t.Descripcion);
            command.Parameters.AddWithValue("@fechaActividad", t.FechaActividad);
            command.Parameters.AddWithValue("@costoActividad", t.CostoActividad);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionID);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                //LOG
                throw ex;

            }
        }

        public DataTable Select()
        {
            string query = @"SELECT idActividad AS 'ID', nombreActividad, descripcion, fechaActividad, estado,
                                fechaRegistro, fechaActualizacion, idUsuario
                                FROM actividad
                                WHERE estado = 1
                                ORDER BY 2";
            MySqlCommand command = CreateBasicCommand(query);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                //LOG
                throw ex;
            }
        }

        public int Update(Actividad t)
        {
            string query = @"UPDATE actividad SET nombreActividad= @nombreActividad, descripcion= @descripcion,
                            fechaActividad= @fechaActividad, fechaActualizacion = CURRENT_TIMESTAMP, idUsuario = @idUsuario
                            WHERE idActividad = @idActividad";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idActividad", t.IdActividad);
            command.Parameters.AddWithValue("@nombreActividad", t.NombreActividad);
            command.Parameters.AddWithValue("@descripcion", t.Descripcion);
            command.Parameters.AddWithValue("@fechaActividad", t.FechaActividad);
            command.Parameters.AddWithValue("@costoActividad", t.CostoActividad);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionID);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                //LOG
                throw ex;

            }
        }
    }
}
