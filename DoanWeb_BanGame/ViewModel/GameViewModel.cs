using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DoanWeb_BanGame.Models;

namespace DoanWeb_BanGame.ViewModel
{
    public class GameViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tên trò chơi")]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }
        [Display(Name = "Ngày ra mắt")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishDay { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Cấu hình đề nghị")]
        public string SystemRequirememts { get; set; }
        [Display(Name = "Giá gốc")]
        public decimal Cost { get; set; }
        [DisplayName("Nhà sản xuất")]
        public string ProducerName { get; set; }
        [DisplayName("Nhà phát hành")]
        public string PublisherName { get; set; }
        [DisplayName("Enable")]
        public bool Enable { get; set; }
        [DisplayName("Thể loại")]
        public string TypeGameDetails { get; set; }

        [DisplayName("Nền tảng")]
        public string PlatformDetails { get; set; }
    }
}