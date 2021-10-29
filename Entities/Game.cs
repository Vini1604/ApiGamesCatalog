using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Entities {
    public class Game {
        public Guid Id { get; set; }
        public string GameName { get; set; }
        public string Studio { get; set; }
        public string Gender { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
    }
}