using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL
{
    [XmlRoot(ElementName = "HotelRoom")]
    public class HotelRoom
    {
        [XmlElement(ElementName = "RoomID")]
        public string RoomID { get; set; }
        [XmlElement(ElementName = "RoomName")]
        public string RoomName { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Price")]
        public double Price { get; set; }
        [XmlElement(ElementName = "ImageUrl")]
        public string ImageUrl { get; set; }
    }


    [XmlRoot("HotelRooms")]
    [XmlInclude(typeof(HotelRoom))] // include type class Person
    public class HotelRooms
    {
        [XmlArray("Cuartos")]
        [XmlArrayItem("HotelRooms")]
        public List<HotelRoom> Cuartos;

        [XmlElement("Listname")]
        public string Listname { get; set; }

        // Konstruktoren 
        public HotelRooms(List<HotelRoom> _lista, string _listname) 
        {
            Cuartos = _lista;
            Listname = _listname;
        }
        public HotelRooms() { }

    }

    public class RoomCountWrapper
    {
        public RoomCountWrapper(int dobleDeluxe, int dobleStandard, int suite, int suiteDeluxe) 
        {
            DobleDeluxe = dobleDeluxe;
            DobleStandard = dobleStandard;
            Suite = suite;
            SuiteDeluxe = suiteDeluxe; 
        }
        public int DobleDeluxe { get; set; }
        public int DobleStandard { get; set; }
        public int Suite { get; set; }
        public int SuiteDeluxe { get; set; }
    }
}
