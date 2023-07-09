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
            if (Session["Perfil"].ToString() != "Webmaster")
            {
                Response.Redirect("Default.aspx");
            }
        }
        protected void btnRestore_Click(object sender, EventArgs e)
        {
            string ruta = FileUpload1.PostedFile.FileName;
            BLL.Security seg = new BLL.Security();
            //seg.RealizarRestore(ruta);

            //seg.GrabarBitacora(Session["Usuario"].ToString(), "Restore realizado correctamente");
            lblRestore.Text = "Restore realizado correctamente";
        }
    }
}