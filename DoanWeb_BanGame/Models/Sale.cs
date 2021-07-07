using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
    }
}