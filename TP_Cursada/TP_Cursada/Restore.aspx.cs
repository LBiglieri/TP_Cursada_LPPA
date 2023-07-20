using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cursada
{
    public partial class Restore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Profile"].ToString() != "Webmaster")
            {
                if (Session["Profile"].ToString() == "")
                    Response.Redirect("Login.aspx");
                else
                    Response.Redirect("Default.aspx");
            }
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            if (FileUploadRestore.PostedFile.FileName != "")
            {
            string route = FileUploadRestore.PostedFile.FileName;
            BLL.Security sec = new BLL.Security();

            sec.RealizarRestore(@"C:\Users\Public\" + route);

            sec.GrabarBitacora(Session["Nickname"].ToString(), "Restore realizado de forma correcta");
            lblRestore.Text = "Restore realizado de forma correcta";
            }
            else
            {
                lblRestore.Text = "Debe elegir un archivo para poder Restaurar la Base de datos.";
            }
        }
    }
}