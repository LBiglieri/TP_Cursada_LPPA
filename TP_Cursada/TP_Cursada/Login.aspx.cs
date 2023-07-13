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
				if (Convert.ToInt16(dt.Rows[0]["LoginIntentos"]) >= 1)
				{
					//resetea la cantidad de intentos incorrectos y lo vuelve a dejar en cero
					objuser.ReiniciarContador(tbUsuario.Text);
				}
				Session["Usuario"] = dt.Rows[0]["NickName"].ToString();
				Session["Perfil"] = dt.Rows[0]["Perfil"].ToString();
				Session["NombreUsuario"] = dt.Rows[0]["Nombre"].ToString();

                //grabar en bitácora
                objseg.GrabarBitacora(tbUsuario.Text, "Login correcto");
                objuser.ReiniciarContador(tbUsuario.Text);

                //Lo llamo nuevamente
                dt = objuser.ObtenerUsuarioPorNombre(tbUsuario.Text);

				//actualización DVH
				string str = dt.Rows[0]["id"].ToString() + dt.Rows[0]["NickName"].ToString() + dt.Rows[0]["Password"].ToString() + dt.Rows[0]["Nombre"]; /*FALTA AGREGAR*/
				FormsAuthentication.RedirectFromLoginPage(tbUsuario.Text, true);
				Response.Redirect("Home.aspx");
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
					string str = dt.Rows[0]["id"].ToString() + dt.Rows[0]["NickName"].ToString() + dt.Rows[0]["Password"].ToString() + dt.Rows[0]["Nombre"] + dt.Rows[0]["Apellido"].ToString() + dt.Rows[0]["LoginIntentos"].ToString() + dt.Rows[0]["Bloqueado"].ToString();/*FALTA AGREGAR*/

					if (Convert.ToInt16(dt.Rows[0]["LoginIntentos"]) >= 3)
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
					lblEstado.Text = "No existe ningún usuario con ese nick";
				}
			}
		}
	}
}