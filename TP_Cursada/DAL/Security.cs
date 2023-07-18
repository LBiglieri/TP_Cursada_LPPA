using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Security
    {
        public void GrabarBitacora(string user, string mensaje)
        {
            DAL.Database bd = new DAL.Database();
            List<string> lista = new List<string>();

            lista.Add(user);
            lista.Add(mensaje);
            lista.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

            string dvh = CalcularDVH(lista);

            string consulta = "declare @rn int = 0" +
                " select @rn = ROW_NUMBER() over (order by a.InsertTime) from Bitacora a" +
                " insert into Bitacora(ID, Usuario, Description, InsertTime, DVH) VALUES(CAST((@rn+1) as nvarchar),'" + user + "','" + mensaje + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "','" + dvh + "')";

            bd.Insert_Update(consulta);

            ActualizarDVV("Bitacora");
        }

        public void RealizarBackup(string ruta_completa)
        {
            DAL.Database bd = new DAL.Database();
            string consulta = "BACKUP DATABASE TP_Cursada TO DISK = '" + ruta_completa + "' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = 'BackUp" + DateTime.Now.ToString("yyyy-MM-dd HHmm") + "'";

            bd.Insert_Update(consulta);
        }

        public DataTable ObtenerDatosBitacora()
        {
            string query = "Select * from Bitacora order by fecha desc";
            DataTable dt = new DataTable();
            DAL.Database db = new DAL.Database();
            dt = db.CargarDataset(query);
            return dt;
        }

        public static string CalcularDVH(List<string> lista)
        {
            string calcdvh = "";
            foreach (string param in lista)
            {
                calcdvh += param;
            }
            return calcdvh = Encriptar(calcdvh);
        }

        public static void ActualizarDVV(string tabla)
        {
            string acumulado = "";
            DataTable dt = new DataTable();
            dt = ObtenerTabla(tabla);
            DAL.Database db = new DAL.Database();
            string consulta;

            Int32 j = dt.Columns.Count - 1;

            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                acumulado = acumulado + dt.Rows[i][j].ToString();
            }
            string dvv = Encriptar(acumulado);

            consulta = "UPDATE DVVs SET dv_value ='" + dvv + "' WHERE dv_table = '" + tabla + "'";

            db.Insert_Update(consulta);
        }

        public static DataTable AnalizarIntegridad(List<string> listaTablas)
        {
            DataTable dtsalida = new DataTable();
            DataColumn col = new DataColumn();
            DataRow row;

            col.DataType = typeof(string);
            col.ColumnName = "Tabla";
            dtsalida.Columns.Add(col);

            col = new DataColumn();
            col.DataType = typeof(string);
            col.ColumnName = "Fila";
            dtsalida.Columns.Add(col);

            col = new DataColumn();
            col.DataType = typeof(Int32);
            col.ColumnName = "Id";
            dtsalida.Columns.Add(col);

            foreach (string campo in listaTablas)
            {
                DataTable dt = new DataTable();
                dt = ObtenerTabla(campo);

                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    List<string> listafila = new List<string>();
                    listafila.Clear();
                    for (int j = 0; j <= dt.Columns.Count - 1; j++)
                    {
                        if (j != 0 && j <= dt.Columns.Count - 2)
                        {
                            listafila.Add(dt.Rows[i][j].ToString());
                        }
                    }
                    string dvh = CalcularDVH(listafila);
                    if (dvh != dt.Rows[i][dt.Columns.Count - 1].ToString())
                    {
                        row = dtsalida.NewRow();
                        row["Tabla"] = campo;
                        row["Fila"] = i.ToString();
                        row["ID"] = dt.Rows[i][0].ToString();
                        dtsalida.Rows.Add(row);
                    }
                }
            }
            return dtsalida;
        }

        public static void RecalcularDVV(List<string> tablas)
        {
            DataTable dt = new DataTable();
            DAL.Database db = new DAL.Database();
            string consulta;

            foreach (string campo in tablas)
            {
                dt = ObtenerTabla(campo);

                for (int k = 0; k <= dt.Rows.Count - 1; k++)
                {
                    string acumulado = "";
                    for (int i = 0; i < dt.Columns.Count - 1; i++)
                    {
                        acumulado = acumulado + dt.Columns[i].ToString();
                    }
                    string dvh = Encriptar(acumulado);
                    consulta = "UPDATE " + campo + " SET DVH = '" + dvh + "' WHERE ID = " + dt.Rows[k][0].ToString();

                    db.Insert_Update(consulta);
                }

                ActualizarDVV(campo);
            }
        }

        private static DataTable ObtenerTabla(string tabla)
        {
            DataTable dt = new DataTable();
            DAL.Database db = new DAL.Database();
            string consulta = "SELECT * FROM " + tabla + " ORDER BY ID";
            dt = db.CargarDataset(consulta);
            return dt;
        }

        public static string Encriptar(string str)
        {
            //step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            Byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
            Byte[] hash = md5.ComputeHash(inputBytes);

            //step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public void RealizarRestore(string ruta)
        {
            DataTable dt = new DataTable();
            DAL.Database db = new DAL.Database();
            string query = "IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'TP_Cursada') DROP DATABASE TP_Cursada RESTORE DATABASE TP_Cursada FROM DISK = '" + ruta + "'";

            db.Insert_Update(query, "M"); //parametro opcional en M para ejecutar desde el contexto de la database master. 
        }
    }
}
