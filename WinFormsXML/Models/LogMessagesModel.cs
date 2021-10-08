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
    [Table("LogMessage")]
    public class LogMessages
    {
        [Key()]
        [Required]
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DtIns { get; set; }

        public string UserIns { get; set; } = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    }
}
