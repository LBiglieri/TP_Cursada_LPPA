using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cursada
{
    public partial class Bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Perfil"].ToString() != "Webmaster")
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                BLL.Security seg = new BLL.Security();
                DataTable dt = new DataTable();

                //dt = seg.ObtenerDatosBitacora();

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}