using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Interfaces;//
using DAO.Model;//
using MySql.Data.MySqlClient;//

namespace DAO.Implementation
{
    public class UsuarioImpl : DataBase, IUsuario
    {
        public int Delete(Usuario t)
        {
            throw new NotImplementedException();
        }

        public int Insert(Usuario t)
        {
            throw new NotImplementedException();
        }

        public DataTable Login(string userName, string contrasenia)
        {
            string query = @"SELECT idUsuario, nombres, nombreUsuario, sexo
                            FROM usuario
                            WHERE estado=1 AND nombreUsuario=@nombreUsuario
                            AND contrasenia=MD5(@contrasenia)";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombreUsuario", userName);
            command.Parameters.AddWithValue("@contrasenia", contrasenia);

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

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}
