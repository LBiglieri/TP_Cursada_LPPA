using API;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cursada
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartData();
            }
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string RoomID = button.CommandArgument;

            UpdateQuantity(RoomID, 1);

            BindCartData();
        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string RoomID = button.CommandArgument;

            UpdateQuantity(RoomID, -1);

            BindCartData();
        }

        private void UpdateQuantity(string RoomID, int change)
        {
            int currentQuantity = Convert.ToInt32(Session[RoomID] ?? 0);

            currentQuantity += change;

            currentQuantity = Math.Max(currentQuantity, 0);

            Session[RoomID] = currentQuantity;
        }

        private void BindCartData()
        {
            CatalogoAPI api = new CatalogoAPI();
            List<HotelRoom> rooms = api.ObtenerCatalogo();

            List<HotelRoom> cartRooms = rooms
                .Where(room => Session[room.RoomID] != null && (int)Session[room.RoomID] > 0)
                .ToList();

            CartRepeater.DataSource = cartRooms;
            CartRepeater.DataBind();
        }
    }
}