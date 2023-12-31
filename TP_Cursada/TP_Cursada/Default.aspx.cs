﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cursada
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Profile"].ToString() == "")
				Response.Redirect("Login.aspx");

			switch (Session["Profile"].ToString())
			{
				case "Webmaster":
					GridView1.DataSource = BLL.Security.DatosErrores();
					GridView1.DataBind();

					if (GridView1.Rows.Count > 0)
					{
						GridView1.Visible = true;
						btnRecalcularDV.Visible = true;
						Label1.Visible = false;
						Label1.Text = "Todas las Tablas fueron analizadas y se encontraron los siguientes errores:";
					}
					else
					{
						btnRecalcularDV.Visible = false;
						GridView1.Visible = false;
						Label1.Visible = true;
						Label1.Text = "Todas las Tablas fueron analizadas y no se encontraron errores";
					}
					break;
				case "Admin":
					GridView1.Visible = false;
					btnRecalcularDV.Visible = false;
					Label1.Visible = true;
					Label1.Text = "Pantalla Principal de Administrador";
					break;
				case "Cliente":
					GridView1.Visible = false;
					btnRecalcularDV.Visible = false;
					Label1.Visible = true;
					Label1.Text = "Pantalla Principal de Cliente";
					break;
			}
		}
		protected void btnRecalcularDV_Click(object sender, EventArgs e)
		{
			BLL.Security objseg = new BLL.Security();
			objseg.GrabarBitacora(Session["Nickname"].ToString(),"Se recalcularán los DV");

			DataTable dt = (DataTable)GridView1.DataSource;
			BLL.Security.RecalcularDVV(dt);
			Response.Redirect("Default.aspx");
		}


	}
}