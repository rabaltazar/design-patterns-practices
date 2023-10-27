
using System;
using System.Runtime.CompilerServices;

namespace RefactoringGuru.DesignPatterns.AbstractFactory.Conceptual
{
    public interface Button
    {
        public void render();
        public void onClick();
    }
    /*
     * Fabric Class or creator class
     */
    public abstract class Dialog
    {
        public abstract Button createButton();
        public void render()
        {
            Console.WriteLine("Rendering from Dialog");
            Button button = createButton();
            button.onClick();
            button.render();
        }
    }
    // Concrete creators
    class WindowsDialog : Dialog
    {
        public override Button createButton()
        {
            Console.WriteLine("Creating button from Windows Dialog");
            return new WindowsButton();
        }
    }
    class WebDialog : Dialog
    {
        public override Button createButton()
        {
            Console.WriteLine("Creating Button on Web Dialog");
            return new HTMLButton();
        }
    }
    class MobileDialog : Dialog
    {
        public override Button createButton()
        {
            Console.WriteLine("Creting Mobile Button");
            return new MobileButton();
        }
    }

    // Concrete Products

    class WindowsButton : Button
    {
        public void onClick()
        {
            Console.WriteLine("Onclick on windows Button");
        }

        public void render()
        {
            Console.WriteLine("Rendering Windows Button");
        }
    }   
    class HTMLButton : Button
    {
        public void onClick()
        {
            Console.WriteLine("OnClick on HTML Button");
        }

        public void render()
        {
            Console.WriteLine("Rendering HTML Button");
        }
    }
    class MobileButton : Button
    {
        public void onClick()
        {
            Console.WriteLine("onClick from mobile button");
        }

        public void render()
        {
            Console.WriteLine("Render from mobile button");
        }
    }
    // Client
    class Application
    {
        Dialog dialog;
        public void initialize()
        {
            string config = "Android";
            if(config == "Windows")
            {
                dialog = new WindowsDialog();
            }
            else if(config == "Web")
            {
                dialog = new WebDialog();
            }
            else if (config == "Android")
            {
                dialog = new MobileDialog();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public void main()
        {
            this.initialize();
            dialog.render();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Application().main();
        }
    }
}