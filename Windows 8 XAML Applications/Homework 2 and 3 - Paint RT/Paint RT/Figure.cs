using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Paint_RT
{
    public enum FigureType
    {
        Line = 2,
        Ellipse = 1,
        Rectangle = 0
    }

    public class Figure
    {
        public FigureType Fig { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public Windows.UI.Color Color { get; set; }
    }
}
