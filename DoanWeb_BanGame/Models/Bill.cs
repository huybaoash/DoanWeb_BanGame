using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    public class Bill
    {

        [Key] 
        public int Id { get; set; }
        [Display(Name = "Ngày lập")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDay { get; set; }
        [Display(Name = "Khách hàng")]
        public string CustomerID { get; set; }
        [Display(Name = "Tổng tiền")]
        public decimal TotalCost { get; set; }

        public ApplicationUser Customer { get; set; }
        private ICollection<BillDetail> BillDetails { get; set; }
    }
}