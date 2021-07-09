using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    public class TypeGame
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên thể loại")]
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        public ICollection<TypeGameDetails> TypeGameDetailsCollection { get; set; }
    }
}