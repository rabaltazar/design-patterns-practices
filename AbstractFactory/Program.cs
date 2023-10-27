
using System;
using System.Runtime.CompilerServices;

namespace RefactoringGuru.DesignPatterns.AbstractFactory.Conceptual
{
    interface GUIFactory
    {
        public Button createButton();
        public Checkbox createCheckbox();
    }

    class WinFactory : GUIFactory
    {
        public Button createButton()
        {
            return new WinButton();
        }

        public Checkbox createCheckbox()
        {
            return new WinCheckbox();
        }
    }

    class MacFactory : GUIFactory
    {
        public Button createButton()
        {
            return new MacButton();
        }

        public Checkbox createCheckbox()
        {
            return new MacCheckbox();
        }
    }

    interface Button
    {
        void paint();
    }

    class WinButton : Button
    {
        public void paint()
        {
            Console.WriteLine("painting from Win Button");
        }
    }

    class MacButton : Button
    {
        public void paint()
        {
            Console.WriteLine("painting from mac button");
        }
    }

    class WinCheckbox : Checkbox
    {
        public void paint()
        {
            Console.WriteLine("painting from win checkbox");
        }
    }
    class MacCheckbox : Checkbox
    {
        public void paint()
        {
            Console.WriteLine("painting from mac checkbox");
        }
    }

    interface Checkbox
    {
        void paint();
    }

    class Application
    {
        private GUIFactory factory;
        private Button button;
        private Checkbox checkbox;
        public Application(GUIFactory factory)
        {
            this.factory = factory;
            this.createUI();
            this.paint();
        }

        void createUI()
        {
            this.button = factory.createButton();
            this.checkbox = factory.createCheckbox();
        }
        void paint()
        {
            button.paint();
            checkbox.paint();
        }
        
    }

    class ApplicationConfigurator
    {
        GUIFactory factory;
        public void main()
        {
            string config = "mac";
            if(config == "windows")
            {
                factory = new WinFactory();
            }else if(config == "mac")
            {
                factory = new MacFactory();
            }
            Application app = new Application(factory);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new ApplicationConfigurator().main();
        }
    }
}