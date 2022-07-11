using System;
using System.Collections.Generic;
using System.Data;//
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Interfaces;//
using DAO.Model;//
using MySql.Data.MySqlClient;//


namespace DAO.Implementation
{
    public class SocioImpl : DataBase, ISocio
    {
        public int Delete(Socio t)
        {
            string query = @"UPDATE socio SET estado = 0, fechaActualizacion = CURRENT_TIMESTAMP, idUsuario = @idUsuario
                            WHERE idSocio = @idSocio";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idUsuario", Session.SessionID);
            command.Parameters.AddWithValue("@idSocio", t.IdSocio);
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

        public Socio Get(int id)
        {
            Socio t = null;
            string query = @"SELECT idSocio, ci, nombres, primerApellido, segundoApellido,
                              fechaNacimiento, matriculaProfesional, lugarTrabajo, fuenteFinanciacion,celular, estado, fechaRegistro,
                              fechaActualizacion, idUsuario
                              FROM socio
                              WHERE idSocio=@id";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable dt = ExecuteDataTableCommand(command);
                if (dt.Rows.Count>0)
                {
                    DateTime fecha2;
                    string fech = dt.Rows[0][12].ToString();
                    if (fech == "")
                    {
                        fecha2 = DateTime.Now;
                    }
                    else
                    {
                        fecha2 = DateTime.Parse(dt.Rows[0][12].ToString());
                    }
                    
                    t = new Socio(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), DateTime.Parse(dt.Rows[0][5].ToString()), dt.Rows[0][6].ToString(), dt.Rows[0][7].ToString(), dt.Rows[0][8].ToString(), int.Parse(dt.Rows[0][9].ToString()), byte.Parse(dt.Rows[0][10].ToString()), DateTime.Parse(dt.Rows[0][11].ToString()), fecha2, int.Parse(dt.Rows[0][13].ToString()));
                }
            }
            catch (Exception ex)
            {
                //LOG
                throw ex;
            }
            return t;
        }

        public int Insert(Socio t)
        {
            string query = @"INSERT INTO socio(ci, nombres, primerApellido, segundoApellido,
                              fechaNacimiento, matriculaProfesional, lugarTrabajo, fuenteFinanciacion,celular, idUsuario)
                            VALUES (@ci, @nombres, @primerApellido, @segundoApellido,@fechaNacimiento, @matriculaProfesional,
                                    @lugarTrabajo, @fuenteFinanciacion, @celular, @idUsuario)";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@nombres", t.Nombres);
            command.Parameters.AddWithValue("@primerApellido", t.PrimerApellido);
            command.Parameters.AddWithValue("@segundoApellido", t.SegundoApellido);
            command.Parameters.AddWithValue("@fechaNacimiento", t.FechaNacimiento);
            command.Parameters.AddWithValue("@matriculaProfesional", t.MatriculaProfesional);
            command.Parameters.AddWithValue("@lugarTrabajo", t.LugarTrabajo);
            command.Parameters.AddWithValue("@fuenteFinanciacion", t.FuenteFinanciacion);
            command.Parameters.AddWithValue("@celular", t.Celular);
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
            string query = @"SELECT idSocio, ci, CONCAT(nombres,' ',primerApellido,' ',IFNULL(segundoApellido,'')) AS 'Nombre Completo',
                            fechaNacimiento as 'Fecha Nacimiento', matriculaProfesional, lugarTrabajo, fuenteFinanciacion, 
                            celular, estado, fechaRegistro, fechaActualizacion, idUsuario
                            FROM socio
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

        public int Update(Socio t)
        {
            string query = @"UPDATE socio SET ci= @ci, nombres= @nombres, primerApellido= @primerApellido, segundoApellido= @segundoApellido,
                            fechaNacimiento= @fechaNacimiento, matriculaProfesional= @matriculaProfesional,
                            lugarTrabajo= @lugarTrabajo, fuenteFinanciacion= @fuenteFinanciacion, celular= @celular, 
                            fechaActualizacion = CURRENT_TIMESTAMP, idUsuario = @idUsuario
                            WHERE idSocio = @idSocio";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idSocio", t.IdSocio);
            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@nombres", t.Nombres);
            command.Parameters.AddWithValue("@primerApellido", t.PrimerApellido);
            command.Parameters.AddWithValue("@segundoApellido", t.SegundoApellido);
            command.Parameters.AddWithValue("@fechaNacimiento", t.FechaNacimiento);
            command.Parameters.AddWithValue("@matriculaProfesional", t.MatriculaProfesional);
            command.Parameters.AddWithValue("@lugarTrabajo", t.LugarTrabajo);
            command.Parameters.AddWithValue("@fuenteFinanciacion", t.FuenteFinanciacion);
            command.Parameters.AddWithValue("@celular", t.Celular);
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
