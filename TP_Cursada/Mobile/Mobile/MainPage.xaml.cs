using BLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        public RoomCountWrapper RoomCount { get; set; }
        public ObservableCollection<HotelRoom> HotelRooms { get; set; }

        public MainPage()
        {
            InitializeComponent();

            RoomCount = new RoomCountWrapper(0, 0, 0, 0);
            HotelRooms = new ObservableCollection<HotelRoom>
            {
                new HotelRoom { RoomID = "DobleDeluxe", RoomName = "Habitación Doble Deluxe", Description = "Disfrute de una experiencia de lujo en nuestra Habitación Doble Deluxe. Con una decoración elegante y moderna, esta habitación cuenta con una cama king-size que le brindará el máximo confort durante su estancia. Los tonos suaves y la iluminación ambiental crean un ambiente relajante, mientras que los servicios de alta gama, como televisores de pantalla plana, minibar surtido y conexión Wi-Fi de alta velocidad, garantizan su comodidad y entretenimiento. El baño privado está equipado con artículos de tocador de lujo y una ducha de lluvia para que pueda relajarse y rejuvenecer. Además, disfrute de vistas impresionantes desde su ventana panorámica, completando la experiencia de lujo que ofrecemos en nuestra Habitación Doble Deluxe.", Price = 150.00, ImageUrl = "https://images.pxsol.com/68/company/library/user/10111666398fd50f33aab7e8a5cbb5b0db56530ffa8.jpg?auto=format&browser=Edge&h=400&ixlib=php-3.3.1&w=600&s=82a9aa792e468b4f226136744036ebd1" },
                new HotelRoom { RoomID = "DobleStandard", RoomName = "Habitación Doble Standard", Description = "Nuestra Habitación Doble Standard es la opción perfecta para aquellos que buscan comodidad y funcionalidad sin comprometer el estilo. La habitación cuenta con una cama tamaño queen. La decoración sencilla pero acogedora crea un ambiente cálido y relajante. Las comodidades modernas, como televisores de pantalla plana, estación de trabajo y conexión Wi-Fi gratuita, aseguran que tenga todo lo que necesita a su alcance. El baño privado, bien equipado con artículos esenciales, garantiza su comodidad. Una elección práctica y agradable para una estancia cómoda.", Price = 100.00, ImageUrl = "https://images.pxsol.com/68/company/library/user/151435785245702edfb37339afc9cdc9e7fea8900d5.jpg?auto=format&browser=Edge&h=400&ixlib=php-3.3.1&w=600&s=cc37a8663f9c2e94dfb0b1a0bcb06006" },
                new HotelRoom { RoomID = "Suite", RoomName = "Suite", Description = "Sumérjase en el lujo de nuestra Suite. Esta espaciosa y elegante habitación ofrece un área de estar separada y un dormitorio con una lujosa cama king-size. La decoración refinada y los detalles cuidadosamente seleccionados crean un ambiente sofisticado y acogedor. Relájese en la sala de estar con cómodos sofás y disfrute de su programa favorito en el televisor de pantalla plana. La suite también cuenta con un escritorio de trabajo, conexión Wi-Fi de alta velocidad y minibar. El baño privado, con bañera y ducha separadas, está equipado con artículos de tocador de calidad. Experimente el confort y la elegancia en cada rincón de nuestra exclusiva Suite.", Price = 200.00, ImageUrl = "https://image-tc.galaxy.tf/wijpeg-6ha5k31iastgp77rz4map3j4l/oll6078_wide.jpg?crop=0%2C104%2C2000%2C1125&width=1140" },
                new HotelRoom { RoomID = "SuiteDeluxe", RoomName = "Suite Deluxe", Description = "Experimente el pináculo del lujo en nuestra Suite Deluxe. Esta suite excepcional combina una elegancia incomparable con comodidades de primera clase. La amplia sala de estar cuenta con mobiliario de diseño y una decoración lujosa, creando un espacio perfecto para el entretenimiento o la relajación. El dormitorio presenta una cama king-size con sábanas de alta calidad para garantizar una noche de descanso inigualable. Los ventanales del suelo al techo ofrecen vistas panorámicas impresionantes. La suite también incluye un baño privado con bañera de hidromasaje y ducha de lluvia, así como servicios adicionales como un minibar bien surtido y acceso exclusivo a instalaciones especiales del hotel. Disfrute de una experiencia única en nuestra Suite Deluxe, donde el lujo se encuentra con la comodidad.", Price = 250.00, ImageUrl = "https://image-tc.galaxy.tf/wijpeg-3mrazyiw6dj0e8bumc0f5zh70/oll6041_wide.jpg?crop=0%2C104%2C2000%2C1125&width=1140" }

            };

            RoomCollectionView.ItemsSource = HotelRooms;
        }
        private void AddToCart_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string roomName = button.CommandParameter.ToString();

            switch (roomName)
            {
                case "DobleDeluxe":
                    RoomCount.DobleDeluxe++;
                    break;
                case "DobleStandard":
                    RoomCount.DobleStandard++;
                    break;
                case "Suite":
                    RoomCount.Suite++;
                    break;
                case "SuiteDeluxe":
                    RoomCount.SuiteDeluxe++;
                    break;
            }

            DisplayAlert("Added to Cart", $"Room '{roomName}' added to the cart", "OK");
        }

        private async void GoToShoppingCart_Clicked(object sender, EventArgs e)
        {
            Carrito carro = new Carrito(RoomCount);
            await Navigation.PushAsync(carro);
            RoomCount = carro.RoomCount;
        }
    }
}
