using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nhà sản xuất")]
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Quốc gia")]
        public string Country { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}