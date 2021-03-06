using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JoshuaC.Nealon_S00198699
{
    public class Game
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public int CriticScore { get; set; }
        public string Description{ get; set; }

        public string Platform { get; set; }
        public string GameImage { get; set; }
        public decimal Price { get; set; }

        public Game()
        {

        }

        public Game(string name, decimal price, int criticscore, string description,string platform, string gameImage = "")
        {
            Name = name;
            Price = price;
            CriticScore = criticscore;
            Description = description;
            Platform = platform;
            GameImage = gameImage;
        }

        public override string ToString()
        {
            return Name;
        }

        public void DecreasePrice(decimal decrease)
        {
            Price = Price - decrease;
        }
    }
    public class GameData : DbContext
    {
        public GameData() : base("GameInfo") { }
        public DbSet<Game> Games { get; set; }
    }
}
