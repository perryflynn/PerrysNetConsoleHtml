using System;
using System.Collections.Generic;
using System.Linq;
using PerrysNetConsole;

namespace PerrysNetConsoleHtml
{
    /// <summary>
    /// Converts Console Colors into HTML Colors
    /// </summary>
    public static class ColorConverter
    {

        public enum ColorType { Background, Foreground }

        private static List<ColorItem> Colors = new List<ColorItem>()
        {
            new ColorItem(ConsoleColor.Black, "#000000", "black"),
            new ColorItem(ConsoleColor.Blue, "#0000ff", "blue"),
            new ColorItem(ConsoleColor.Cyan, "#00ffff", "cyan"),
            new ColorItem(ConsoleColor.DarkBlue, "#000084", "darkblue"),
            new ColorItem(ConsoleColor.DarkCyan, "#008284", "darkcyan"),
            new ColorItem(ConsoleColor.DarkGray, "#848284", "darkgray"),
            new ColorItem(ConsoleColor.DarkGreen, "#008200", "darkgreen"),
            new ColorItem(ConsoleColor.DarkMagenta, "#840084", "darkmagenta"),
            new ColorItem(ConsoleColor.DarkRed, "#840000", "darkred"),
            new ColorItem(ConsoleColor.DarkYellow, "#848200", "darkyellow"),
            new ColorItem(ConsoleColor.Gray, "#c6c3c6", "gray"),
            new ColorItem(ConsoleColor.Green, "#00ff00", "green"),
            new ColorItem(ConsoleColor.Magenta, "#ff00ff", "magenta"),
            new ColorItem(ConsoleColor.Red, "#ff0000", "red"),
            new ColorItem(ConsoleColor.White, "#ffffff", "white"),
            new ColorItem(ConsoleColor.Yellow, "#ffff00", "yellow")
        };

        public static string GetHexcode(ConsoleColor color)
        {
            return Colors.Where(v => v.ConsoleColor == color).Single().Hexcode;
        }

        public static string GetHexcode(ColorScheme scheme, ColorType type)
        {
            var defcolor = (type == ColorType.Background ? CoEx.DefaultBackgroundColor : CoEx.DefaultForegroundColor);
            var color = type == ColorType.Background ? scheme.Background : scheme.Foreground;
            return GetHexcode(color ?? defcolor);
        }

    }
}
