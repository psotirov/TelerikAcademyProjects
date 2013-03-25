using System;
using System.Collections.Generic;
using System.Text;

namespace HTMLRenderer
{
    public abstract class Element : IElement
    {
        public string Name { get; protected set; }
        public string TextContent { get; set; }
        protected List<Element> ChildHTMLElements; // a list of all child elements

        public abstract void Render(StringBuilder output);

        public Element() // default constructor
        {
            this.ChildHTMLElements = new List<Element>();
        }

        public IEnumerable<IElement> ChildElements
        {
            get
            {
                return this.ChildHTMLElements; // returns the list of all child elements
            }
        }

        public void AddElement(IElement element)
        {
            Element item = element as Element; // converts to HTML element
            if (item != null)
                this.ChildHTMLElements.Add(item); // if not null put it to the list
            else
                throw new ArgumentNullException("Cannot add null HTML element as a child");
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }
    }
}