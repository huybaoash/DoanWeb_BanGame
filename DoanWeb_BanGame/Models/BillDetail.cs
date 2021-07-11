using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    public class BillDetail
    {
        [Key] public int Id { get; set; }

        [ForeignKey("Game")]
        [Display(Name = "Mã Game")]
        public int GameId { get; set; }
        public Game Game { get; set; }

        [ForeignKey("Bill")]
        [Display(Name = "Mã hóa đơn")]
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        [Display(Name = "Giá")]

        public decimal Cost { get; set; }

        [ForeignKey("Sale")]
        [Display(Name = "Mã khuyến mãi")]
        public int SaleId { get; set; }
        public Sale Sale { get; set; }



    }
}