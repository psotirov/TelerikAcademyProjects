using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace HTMLRenderer
{
	public interface IElement
	{
		string Name { get; }
		string TextContent { get; set; }
		IEnumerable<IElement> ChildElements { get; }
		void AddElement(IElement element);
		void Render(StringBuilder output);
		string ToString();
	}

	public interface ITable : IElement
	{
		int Rows { get; }
		int Cols { get; }
		IElement this[int row, int col] { get; set; }
	}

    public interface IElementFactory
    {
		IElement CreateElement(string name);
		IElement CreateElement(string name, string content);
		ITable CreateTable(int rows, int cols);
    }

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
            if (item != null) this.ChildHTMLElements.Add(item); // if not null put it to the list
            else throw new ArgumentNullException("Cannot add null HTML element as a child");
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }
    }

    public class HTMLElement : Element
    {
        public HTMLElement(string name, string content = null) : base() // default constructor
        {
            this.Name = name;
            this.TextContent = content;
        }

        public override void Render(StringBuilder output)
        {
            if (this.Name != null && this.Name.Length > 0) output.Append("<" + this.Name + ">"); // opening element
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
            if (this.Name != null && this.Name.Length > 0) output.Append("</" + this.Name + ">"); // closing element
        }
    }

    public class HTMLTable : Element, ITable
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public HTMLTable(int rows, int cols)
            : base()
        {
            this.ChildHTMLElements = new List<Element>(rows * cols);
            for (int i = 0; i < rows*cols; i++)
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

    public class HTMLElementFactory : IElementFactory
    {
		public IElement CreateElement(string name)
		{
            return new HTMLElement(name);
		}

		public IElement CreateElement(string name, string content)
		{
            return new HTMLElement(name, content);
		}

		public ITable CreateTable(int rows, int cols)
		{
            return new HTMLTable(rows, cols);
		}
	}

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
			string csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
            //Console.ReadLine();
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
            
            /*using (StreamReader sr = new StreamReader(@"..\..\sample-input.txt"))
            {
                string command = sr.ReadLine();
                while (command != "")
                {
                    result.AppendLine(command);
                    command = sr.ReadLine();
                }
            }

            return result.ToString();*/
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
