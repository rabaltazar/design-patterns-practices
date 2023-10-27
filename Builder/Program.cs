// Builder Design Pattern
//
// Intent: Lets you construct complex objects step by step. The pattern allows
// you to produce different types and representations of an object using the
// same construction code.

using System;
using System.Collections.Generic;

namespace RefactoringGuru.DesignPatterns.Builder.Conceptual
{
    public class Car
    {

    }

    public class Manual
    {

    }

    interface Builder
    {
        void reset();
        void setSeats();
        void setEngine();
        void setTripComputer();
        void setGPS();
    }

    class CarBuilder : Builder
    {
        private Car car;
        public CarBuilder()
        {
            this.reset();
        }
        public void reset()
        {
            this.car = new Car();
        }

        public void setEngine()
        {
            Console.WriteLine("Setting engine");
        }

        public void setGPS()
        {
            Console.WriteLine("Setting GPS Navigator");
        }

        public void setSeats()
        {
            Console.WriteLine("Setting Seats Number");
        }

        public void setTripComputer()
        {
            Console.WriteLine("Setting Trip Computer");
        }
        public Car getProduct()
        {
            Car product = this.car;
            this.reset();
            return product;
        }
    }
    class CarManualBuilder : Builder
    {
        private Manual manual;
        public CarManualBuilder()
        {
            this.reset();
        }
        public void reset()
        {
            this.manual = new Manual();
        }

        public void setEngine()
        {
            Console.WriteLine("Documenting the Engine");
        }

        public void setGPS()
        {
            Console.WriteLine("Documenting the GPS");
        }

        public void setSeats()
        {
            Console.WriteLine("Documenting seats quantity");
        }

        public void setTripComputer()
        {
            Console.WriteLine("Documenting trip computer");
        }
        public Manual getProduct()
        {
            Manual product = this.manual;
            this.reset();
            return product;
        }
    }

    class Director
    {
        private Builder builder;

        public void setBuilder(Builder builder)
        {
            this.builder = builder;
        }

        public void constructSportCar(Builder builder)
        {
            builder.reset();
            builder.setSeats();
            builder.setEngine();
            builder.setTripComputer();
            builder.setGPS();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Director director = new();

            CarBuilder builder = new();
            director.constructSportCar(builder);
            Car car = builder.getProduct();
            Console.WriteLine("car got", car);

            CarManualBuilder manualBuilder = new();
            director.constructSportCar(manualBuilder);
            Manual manual = manualBuilder.getProduct();
            Console.WriteLine("manual goy", manual);
        }
    }
}
