using API;
using BLL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace TP_Cursada
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoomData();
            }
        }
        private void BindRoomData()
        {
            CatalogoAPI api = new CatalogoAPI();
            List<HotelRoom> rooms = api.ObtenerCatalogo();

            RoomRepeater.DataSource = rooms;
            RoomRepeater.DataBind();
        }

        protected void ChangeValueButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string RoomID = button.CommandArgument;

            if (Session[RoomID] == null)
            {
                Session[RoomID] = 1;
            }
            else
            {
                Session[RoomID] = Convert.ToInt32(Session[RoomID].ToString()) + 1;
            }
                    
            BindRoomData();
        }
        protected void DownloadButton_Click(object sender, EventArgs e)
        {
            CatalogoAPI api = new CatalogoAPI();
            List<HotelRoom> rooms = api.ObtenerCatalogo();
            string tempPath = Path.GetTempPath();

            HotelRooms hotelRooms = new HotelRooms(rooms, "Rooms");
            var serializer = new XmlSerializer(typeof(HotelRooms));
            using (var writer = new StreamWriter(tempPath + @"\HotelRooms.xml"))
            {
                serializer.Serialize(writer, hotelRooms);
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(tempPath + @"\HotelRooms.xml");

            Response.Clear();
            Response.ContentType = "text/xml";
            Response.AddHeader("Content-Disposition", "attachment; filename=example.xml");

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            doc.WriteTo(xmlTextWriter);
            string xmlString = stringWriter.ToString();

            Response.Write(xmlString);

            Response.End();
        }
    }
}