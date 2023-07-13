using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Security
    {
        [System.Runtime.InteropServices.ComVisible(true)]
        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
        public string EncriptarPassword(string str)
        {
            return DAL.Security.Encriptar(str);
        }

        public DataTable ObtenerDatosBitacora()
        {
            DAL.Security seg = new DAL.Security();
            return seg.ObtenerDatosBitacora();
        }

        public void RealizarRestore(string ruta)
        {
            DAL.Security seg = new DAL.Security();

            seg.RealizarRestore(ruta);
        }

        public void RealizarBackup(string ruta)
        {
            DAL.Security seg = new DAL.Security();

            //falta linea para ruta completa 
            string ruta_full = ruta + @"\BKP_TP_Cursada_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".bak";
            seg.RealizarBackup(ruta);
        }

        public void GrabarBitacora(string user, string message)
        {
            DAL.Security seg = new DAL.Security();

            seg.GrabarBitacora(user, message);
        }

        public static DataTable DatosErrores()
        {
            List<string> tableList = new List<string>();
            tableList.Add("Bitacora");
            tableList.Add("Users");

            DataTable dt = DAL.Security.AnalizarIntegridad(tableList);

            return dt;
        }

        public static void RecalcularDVV(DataTable dt)
        {
            List<string> tableList = new List<string>();
            tableList.Add("Bitacora");
            tableList.Add("Users");

            List<string> DeleteTableList = new List<string>();
            DeleteTableList.Clear();

            bool flag = new bool();

            foreach (string item in tableList)
            {
                flag = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == item)
                    {
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    DeleteTableList.Add(item);
                }
            }

            DAL.Security.RecalcularDVV(DeleteTableList);
        }
    }
}
