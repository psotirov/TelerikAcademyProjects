using System.Collections.Generic;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLTable : Element, ITable
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public HTMLTable(int rows, int cols) : base()
        {
            this.ChildHTMLElements = new List<Element>(rows * cols);
            for (int i = 0; i < rows * cols; i++)
            {
                this.ChildHTMLElements.Add(null);
            }
            this.Rows = rows;
            this.Cols = cols;
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.ChildHTMLElements[row * this.Cols + col];
            }
            set
            {
                this.ChildHTMLElements[row * this.Cols + col] = (Element)value;
            }
        }

        public override void Render(StringBuilder output)
        {
            output.Append("<table>"); // opening table element
            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>"); // opening table row element
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("<td>"); // opening table col element
                    this.ChildHTMLElements[row * this.Cols + col].Render(output); // renders inner HTMLElement
                    output.Append("</td>"); // closing table col element			 
                }
                output.Append("</tr>"); // closing table row element			 
            }
            output.Append("</table>"); // closing table element
        }
    }
}