using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoanWeb_BanGame.Models
{
    public class TypeGameDetails
    {
        [Key] public int Id { get; set; }
        [ForeignKey("TypeGame")] public int TypeGameId { get; set; }
        public TypeGame TypeGame { get; set; }
        [ForeignKey("Game")] public int GameId { get; set; }
        public Game Game { get; set; }
    }
}