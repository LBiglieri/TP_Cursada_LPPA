using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cursada
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            BLL.User objuser = new BLL.User();
            DataTable dt = new DataTable();
            BLL.Security objseg = new BLL.Security();
            string pass_encriptada = objseg.EncriptarPassword(tbPassword.Text);
            dt = objuser.ObtenerUsuario(tbUsuario.Text, pass_encriptada);

            Session["Usuario"] = dt.Rows[0]["Nickname"].ToString();
            Session["Perfil"] = dt.Rows[0]["Perfil"].ToString();
            Session["Usuario"] = dt.Rows[0]["Name"].ToString();

            FormsAuthentication.RedirectFromLoginPage(tbUsuario.Text, true);

            Response.Redirect("Default.aspx");
        }
    }
}