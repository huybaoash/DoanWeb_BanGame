using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    public class Game
    {
        [Key]
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
        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        [DisplayName("Enable")]
        public bool Enable { get; set; }
        public ICollection<TypeGameDetails> TypeGameDetailsCollection { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
    }
}