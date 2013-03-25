using System.Text;

namespace HTMLRenderer
{
    public class HTMLElement : Element
    {
        public HTMLElement(string name, string content = null) : base()// default constructor
        {
            this.Name = name;
            this.TextContent = content;
        }

        public override void Render(StringBuilder output)
        {
            if (this.Name != null && this.Name.Length > 0)
                output.Append("<" + this.Name + ">"); // opening element
            if (this.TextContent != null && this.TextContent.Length > 0) // if there is some text content
            {
                // TODO: remove spacing and new lines if needed
                // escapes all reqired characters 
                string txtContent = this.TextContent.Replace("&", "&amp;");
                txtContent = txtContent.Replace("<", "&lt;");
                txtContent = txtContent.Replace(">", "&gt;");
                output.Append(txtContent); // adds result to the output
            }
            if (this.ChildHTMLElements.Count > 0) // if there is some child nodes
            {
                // renders each of them
                foreach (var item in this.ChildHTMLElements)
                {
                    item.Render(output);
                }
            }
            if (this.Name != null && this.Name.Length > 0)
                output.Append("</" + this.Name + ">"); // closing element
        }
    }
}