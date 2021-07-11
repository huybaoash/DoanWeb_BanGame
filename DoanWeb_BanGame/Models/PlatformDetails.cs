using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    public class PlatformDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Platform")]
        [Display(Name = "Nền tảng")]
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game Game { get; set; }
        [DisplayName("Ngày ra mắt game trên nền tảng")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublicDay { get; set; }
    }
}