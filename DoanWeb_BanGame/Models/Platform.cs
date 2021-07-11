using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên nền tảng")]
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [DisplayName("Hãng sản xuất")]
        public string ProducerName { get; set; }
        public ICollection<PlatformDetails> PlatformDetailsCollection { get; set; }
    }
}