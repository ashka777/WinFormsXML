using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormsXML.Models
{
    [XmlRoot(ElementName = "Client")]
    public class Clients
    {
        [Key()]
        [Column(TypeName = "decimal(18,0)")]
        [XmlAttribute(AttributeName = "CARDCODE")]
        public decimal CARDCODE { get; set; }

        [XmlAttribute(AttributeName = "STARTDATE")]
        public DateTime STARTDATE { get; set; }

        [XmlAttribute(AttributeName = "FINISHDATE")]
        public DateTime FINISHDATE { get; set; }

        [XmlAttribute(AttributeName = "LASTNAME")]
        public string LASTNAME { get; set; }

        [XmlAttribute(AttributeName = "FIRSTNAME")]
        public string FIRSTNAME { get; set; }

        [XmlAttribute(AttributeName = "SURNAME")]
        public string SURNAME { get; set; }

        [XmlAttribute(AttributeName = "GENDER")]
        public string GENDER { get; set; }

        [XmlAttribute(AttributeName = "BIRTHDAY")]
        public DateTime BIRTHDAY { get; set; }

        [XmlAttribute(AttributeName = "PHONEHOME")]
        public string PHONEHOME { get; set; }

        [XmlAttribute(AttributeName = "PHONEMOBIL")]
        public string PHONEMOBIL { get; set; }

        [XmlAttribute(AttributeName = "EMAIL")]
        public string EMAIL { get; set; }

        [XmlAttribute(AttributeName = "CITY")]
        public string CITY { get; set; }

        [XmlAttribute(AttributeName = "STREET")]
        public string STREET { get; set; }

        [XmlAttribute(AttributeName = "HOUSE")]
        public int HOUSE { get; set; }

        [XmlAttribute(AttributeName = "APARTMENT")]
        public int APARTMENT { get; set; }
    }

    //Закоментировал после автогенерации класса из XML
    //[XmlRoot(ElementName = "Clients")]
    //public class Clients
    //{
    //	[XmlElement(ElementName = "Client")]
    //	public Client Client { get; set; }
    //}
}
