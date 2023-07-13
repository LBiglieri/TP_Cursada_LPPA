using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User
    {
        public DataTable ObtenerUsuario(string user, string encrypted_password)
        {
            string query = "Select ID, Nickname, Name, Surname, Password, FailedLogIns, Profile, Lock from Users where Nickname = '"
                            + user + "' and Password = '" + encrypted_password + "'";

            DataTable dt = new DataTable();
            DAL.Database database = new DAL.Database();
            dt = database.CargarDataset(query);
            return dt;
        }

        public DataTable ObtenerUsuarioPorNombre(string user)
        {
            string consulta = "Select • from Users where NickName = '" + user + "'";
            DataTable dt = new DataTable();
            DAL.Database bd = new DAL.Database();
            dt = bd.CargarDataset(consulta);
            return dt;
        }

        public void AumentarErrorIngreso(string user)
        {
            DAL.Database bd = new DAL.Database();
            string consulta = "update Users set FailedLogIns = FailedLogIns + 1 where NickName = '" + user + "'";
            bd.Insert_Update(consulta);

            List<string> lista = new List<string>();
            DataTable dt = ObtenerUsuarioPorNombre(user);

            for (int i = 0; i < dt.Columns.Count - 2; i++)
            {
                lista.Add(dt.Rows[0][i].ToString());
            }

            string dvh = DAL.Security.CalcularDVH(lista);
            string consulta2 = "update Users set DVH = '" + dvh + "' where NickName = '" + user + "'";
            bd.Insert_Update(consulta2);
            DAL.Security.ActualizarDVV("Users");
        }

        public void ReiniciarContador(string user)
        {
            DAL.Database bd = new DAL.Database();
            string consulta = "update Users set FailedLogIns = 0 where Nickname = '" + user + "'";

            List<string> lista = new List<string>();
            DataTable dt = ObtenerUsuarioPorNombre(user);

            for (int i = 0; i < dt.Columns.Count - 2; i++)
            {
                lista.Add(dt.Rows[0][i].ToString());
            }

            string dvh = DAL.Security.CalcularDVH(lista);
            string consulta2 = "update Users set DVH = '" + dvh + "' where NickName = '" + user + "'";
            bd.Insert_Update(consulta2);
            DAL.Security.ActualizarDVV("Users");
        }
    }
}
