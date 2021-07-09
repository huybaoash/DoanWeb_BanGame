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
        [Display(Name = "Mã khuyến mãi")]
        public string Code { get; set; }
        [Display(Name = "Tỉ lệ khuyến mãi")]
        public int Rate { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        public DateTime StartDay { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public DateTime EndDay { get; set; }
    }
}