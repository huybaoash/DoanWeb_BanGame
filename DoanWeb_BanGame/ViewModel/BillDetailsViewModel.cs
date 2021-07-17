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
    public class BillDetailsViewModel
    {
        [Display(Name = "Ngày lập")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDay { get; set; }
        [Display(Name = "Mã khách hàng")]
        public int CustomerID { get; set; }

        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; }

        [Display(Name = "Mã Game")]
        public List<int> GameId { get; set; }

        [Display(Name = "Tên trò chơi")]
        public List<string> GameName { get; set; }

        [Display(Name = "Mã hóa đơn")]
        public int BillId { get; set; }

        [Display(Name = "Giá")]
        public List<decimal> Cost { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal TotalCost { get; set; }

        [Display(Name = "Id huyến mãi")]
        public List<int> SaleId { get; set; }

        [Display(Name = "Mã khuyến mãi")]
        public List<string> Code { get; set; }
    }
}