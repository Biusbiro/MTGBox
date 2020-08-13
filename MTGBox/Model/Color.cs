using MTGBox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGBox.DAO
{
    class Color
    {
        public Int32 Id { get; set; }
        public Int32 Code { get; set; }
        public Card Card { get; set; }
    }
}
