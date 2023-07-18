using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cursada
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Profile"] == null)
            {
                Session["Profile"] = "";
            }
            switch (Session["Profile"].ToString())
            {
                case "Webmaster":
                    mnWebmaster.Enabled = true;
                    mnWebmaster.Visible = true;
                    mnAdministrador.Enabled = false;
                    mnAdministrador.Visible = false;
                    mnClientes.Enabled = false;
                    mnClientes.Visible = false;
                    LabelUsuario.Text = "Usted ha ingresado como Webmaster";
                    break;
                case "Admin":
                    mnWebmaster.Enabled = false;
                    mnWebmaster.Visible = false;
                    mnAdministrador.Enabled = true;
                    mnAdministrador.Visible = true;
                    mnClientes.Enabled = false;
                    mnClientes.Visible = false;
                    LabelUsuario.Text = "Usted ha ingresado como Administrador";
                    break;

                case "Cliente":
                    mnWebmaster.Enabled = false;
                    mnWebmaster.Visible = false;
                    mnAdministrador.Enabled = false;
                    mnAdministrador.Visible = false;
                    mnClientes.Enabled = true;
                    mnClientes.Visible = true;

                    LabelUsuario.Text = "Usted ha ingresado como Cliente";
                    break;
            }
        }
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            BLL.Security objseg = new BLL.Security();
            objseg.GrabarBitacora(Session["Nickname"].ToString(), "LogOut realizado ");
            LabelUsuario.Text = "";
            mnWebmaster.Enabled = false;
            mnWebmaster.Visible = false;
            mnAdministrador.Enabled = false;
            mnAdministrador.Visible = false;
            mnClientes.Enabled = false;
            mnClientes.Visible = false;
            Response.Redirect("Login.aspx");
        }


    }
}