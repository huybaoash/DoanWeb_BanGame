using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Khách hàng")]
        public string CustomerID { get; set; }

        [Display(Name = "Mã Game")]
        public int GameId { get; set; }

        [Display(Name = "Tên trò chơi")]
        public string GameName { get; set; }

        [Display(Name = "Giá")]
        public decimal Cost { get; set; }

        [Display(Name = "Id huyến mãi")]
        public int SaleId { get; set; }

        [Display(Name = "Mã khuyến mãi")]
        public string Code { get; set; }

        [Display(Name = "Tỉ lệ khuyến mãi")]
        public int Rate { get; set; }

    }

    


}