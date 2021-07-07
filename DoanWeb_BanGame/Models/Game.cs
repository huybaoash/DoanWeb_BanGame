using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }
        public DateTime PublishDay { get; set; }
        public string Description { get; set; }
        public string SystemRequirememts { get; set; }
        public decimal Cost { get; set; }
        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<TypeGameDetails> TypeGameDetailsCollection { get; set; }
    }
}