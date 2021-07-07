using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    public class Bill
    {

        [Key] public int Id { get; set; }
        public DateTime CreateDay { get; set; }

        public ApplicationUser Customer { get; set; }
    }
}