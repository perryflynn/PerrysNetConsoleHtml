using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysNetConsoleHtml
{
    /// <summary>
    /// Represents a single ConsoleColor <-> HTML color mapping
    /// </summary>
    public class ColorItem
    {

        public ColorItem(ConsoleColor color, string hexcode, string name)
        {
            this.ConsoleColor = color;
            this.Hexcode = hexcode;
            this.Name = name;
        }

        public String Name { get; set; }
        public ConsoleColor ConsoleColor { get; set; }
        public String Hexcode { get; set; }

    }
}
