﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cursada
{
    public partial class Backup : System.Web.UI.Page
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
        protected void btnBackup_Click(object sender, EventArgs e)
        {
            string ruta = "C:\\Users\\Public";
            BLL.Security seg = new BLL.Security();
            seg.RealizarBackup(ruta);

            seg.GrabarBitacora(Session["Nickname"].ToString(), "Backup realizado");
            lblBackup.Text = "Backup realizado correctamente";
        }
    }
}