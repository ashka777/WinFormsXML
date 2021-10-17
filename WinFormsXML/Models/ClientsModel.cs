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
    #nullable enable
    public class Client
    {
        [Key()]
        [Column(TypeName = "decimal(18,0)")]
        public decimal CARDCODE { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? FINISHDATE { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? LASTNAME { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FIRSTNAME { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? SURNAME { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string? GENDER { get; set; }

        public DateTime? BIRTHDAY { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string? PHONEHOME { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? PHONEMOBIL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? EMAIL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? CITY { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? STREET { get; set; }

        public string? HOUSE { get; set; }

        public string? APARTMENT { get; set; }
    }
}

