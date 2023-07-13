using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class User
    {
        public DataTable ObtenerUsuario(string user, string encrypted_password)
        {
            DataTable dt = new DataTable();
            DAL.User usuario = new DAL.User();

            dt = usuario.ObtenerUsuario(user, encrypted_password);
            return dt;
        }

        public void ReiniciarContador(string user)
        {
            DAL.User dal = new DAL.User();
            //dal.ReiniciarContador(user);
        }

        public DataTable ObtenerUsuarioPorNombre(string user)
        {
            DataTable dt = new DataTable();
            DAL.User usuario = new DAL.User();

            dt = usuario.ObtenerUsuarioPorNombre(user);
            return dt;
        }

        public void AumentarErrorIngreso(string user)
        {
            DAL.User dal = new DAL.User();
            dal.AumentarErrorIngreso(user);
        }
    }
}
