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

			if (dt.Rows.Count > 0)
			{
				if (Convert.ToInt16(dt.Rows[0]["FailedLogIns"]) >= 1)
				{
					//resetea la cantidad de intentos incorrectos y lo vuelve a dejar en cero
					objuser.ReiniciarContador(tbUsuario.Text);
				}
				Session["Nickname"] = dt.Rows[0]["Nickname"].ToString();
				Session["Profile"] = dt.Rows[0]["Profile"].ToString();
				Session["Name"] = dt.Rows[0]["Name"].ToString();

                //grabar en bitácora
                objseg.GrabarBitacora(tbUsuario.Text, "Login correcto");
                objuser.ReiniciarContador(tbUsuario.Text);

                //Lo llamo nuevamente
                dt = objuser.ObtenerUsuarioPorNombre(tbUsuario.Text);

				//actualización DVH
				string str = dt.Rows[0]["ID"].ToString() + dt.Rows[0]["Nickname"].ToString() + dt.Rows[0]["Password"].ToString() + dt.Rows[0]["Name"]; /*FALTA AGREGAR*/
				FormsAuthentication.RedirectFromLoginPage(tbUsuario.Text, true);
				Response.Redirect("Default.aspx");
			}
			else
			{
				//ingreso incorrecto
				//que busque el usuario, si lo encuentra que le sume al contador
				dt = objuser.ObtenerUsuarioPorNombre(tbUsuario.Text);

				if (dt.Rows.Count > 0)
				{
					objuser.AumentarErrorIngreso(tbUsuario.Text);
					//Lo llamo nuevamente
					dt = objuser.ObtenerUsuarioPorNombre(tbUsuario.Text);
					//actualización DVH
					string str = dt.Rows[0]["ID"].ToString() + dt.Rows[0]["Nickname"].ToString() + dt.Rows[0]["Password"].ToString() + dt.Rows[0]["Name"] + dt.Rows[0]["Surname"].ToString() + dt.Rows[0]["FailedLogIns"].ToString() + dt.Rows[0]["Lock"].ToString();/*FALTA AGREGAR*/

					if (Convert.ToInt16(dt.Rows[0]["FailedLogIns"]) >= 3)
					{
						//El usuario ha sido bloqueado
						Response.Write("Usuario bloqueado.Contacte con el Administrador");
						objseg.GrabarBitacora(tbUsuario.Text, "Usuario bloqueado");
					}
					else
					{
						objseg.GrabarBitacora(tbUsuario.Text, "Contraseña Incorrecta");
						lblEstado.Text = "Ha ingresado mal la contraseña";
					}
				}

				else
				{
					//alert No existe usuario con ese nombre de usuario
					lblEstado.Text = "No existe ningún usuario con ese nickname.";
				}
			}
		}
	}
}