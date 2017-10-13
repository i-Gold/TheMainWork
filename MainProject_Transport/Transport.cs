using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Transport
    {
        protected int speed;
        protected string manufactor;
        protected double weight;
        protected double height;
        protected Engine engine;
        protected int amount;

        public Transport()
        {
            manufactor = "unknown";
        }

        public Transport(int speed, string manufactor, double weight, double height, Engine engine, int amount)
        {
            this.speed = speed;
            this.manufactor = manufactor;
            this.weight = weight;
            this.height = height;
            this.engine = engine;
            this.amount = amount;
        }
        
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        public string Manufactor
        {
            get
            {
                return manufactor;
            }
            set
            {
                manufactor = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public Engine Engine
        {
            get
            {
                return engine;
            }
            set
            {
                engine = value;
            }
        }
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public virtual string getInformation()
        {
            return "Manufactor: " + manufactor
                + " , speed: " + speed
                + " , weight: " + weight
                + " , height: " + height
                + " , engine: " + engine.getInformation()
                + " , amount: " + amount;
        }

        public virtual string infoToWrite()
        {
            return manufactor + "\t"
                + speed + "\t"
                + weight + "\t"
                + height + "\t"
                + engine.infoToWrite() + "\t"
                + amount + "\t";
        }
    }

    public abstract  class WaterTransport : Transport
    {
        public WaterTransport()
        {
            engine = new Disel();
        }
        public WaterTransport(int speed, string manufactor, double weight, double height, Engine engine, int amount)
            : base(speed, manufactor, weight, height, engine, amount)
        {

        }
    }

    public abstract class AirTransport : Transport
    {
        public AirTransport()
        {
            engine = new ReactiveEngine();
        }
        public AirTransport(int speed, string manufactor, double weight, double height, Engine engine, int amount)
            : base(speed, manufactor, weight, height, engine, amount)
        {

        }
    }

    public abstract class LandTransport : Transport
    {
        public LandTransport()
        {
            engine = new PetrolEngine();
        }
        public LandTransport(int speed, string manufactor, double weight, double height, Engine engine, int amount)
            : base(speed, manufactor, weight, height, engine, amount)
        {

        }
    }

    public class Car : LandTransport
    {
        private string transmission;
        private string body;

        public Car() : base()
        {
            transmission = "unknown";
            body = "unknown";
        }
        public Car(int speed, string manufactor, double weight, double height, 
                Engine engine, int amount, string transmission, string body)
                : base(speed, manufactor, weight, height, engine, amount)
        {
            this.transmission = transmission;
            this.body = body;
        }

        public string Transmission
        {
            get
            {
                return transmission;
            }
            set
            {
                transmission = value;
            }
        }
        public string Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
            }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "Transmission: " + transmission
                + " , body" + body;
        }
        public override string infoToWrite()
        {
            return this.GetType().BaseType.Name + "\t"
                + this.GetType().Name + "\t"
                + base.infoToWrite()
                + "\t" + transmission
                + "\t" + body;
        }
    }

    public class Airplane : AirTransport
    {
        private string assignment;
        private int weightBoard;

        public Airplane()
        {
            assignment = "civil";
        }
        public Airplane(int speed, string manufactor, double weight, double height,
                Engine engine, int amount, string assignment, int weightBoard)
                : base(speed, manufactor, weight, height, engine, amount)
        {
            this.assignment = assignment;
            this.weightBoard = weightBoard;
        }

        public string Assignment
        {
            get
            {
                return assignment;
            }
            set
            {
                assignment = value;
            }
        }
        public int WeightBoard
        {
            get
            {
                return weightBoard;
            }
            set
            {
                weightBoard = value;
            }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "Assignment: " + assignment;
        }
        public override string infoToWrite()
        {
            return this.GetType().BaseType.Name + "\t"
                + this.GetType().Name + "\t"
                + base.infoToWrite()
                + "\t" + assignment
                + "\t" + weightBoard;
        }
    }

    public class Ship : WaterTransport
    {
        private string cabin;

        public Ship()
        {
            cabin = "standart";
        }
        public Ship(int speed, string manufactor, double weight, double height,
                Engine engine, int amount, string cabin)
                : base(speed, manufactor, weight, height, engine, amount)
        {
            this.cabin = cabin;
        }

        public string Cabin
        {
            get
            {
                return cabin;
            }
            set
            {
                cabin = value;
            }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "Cabin: " + cabin;
        }
        public override string infoToWrite()
        {
            return this.GetType().BaseType.Name + "\t"
                + this.GetType().Name + "\t"
                + base.infoToWrite()
                + "\t" + cabin;
        }
    }

    public class Train : LandTransport
    {
        private string category;

        public Train()
        {
            category = "passenger";
        }
        public Train(int speed, string manufactor, double weight, double height,
                Engine engine, int amount, string category)
                : base(speed, manufactor, weight, height, engine, amount)
        {
            this.category = category;
        }

        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "Category: " + category;
        }
        public override string infoToWrite()
        {
            return this.GetType().BaseType.Name + "\t"
                + this.GetType().Name + "\t"
                + base.infoToWrite()
                + "\t" + category;
        }
    }

    public class Bike : LandTransport
    {
        private string kind;

        public Bike()
        {
            kind = "classic";
        }
        public Bike(int speed, string manufactor, double weight, double height,
                Engine engine, int amount, string kind)
                : base(speed, manufactor, weight, height, engine, amount)
        {
            this.kind = kind;
        }

        public string Kind
        {
            get
            {
                return kind;
            }
            set
            {
                kind = value;
            }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "Kind: " + kind;
        }
        public override string infoToWrite()
        {
            return this.GetType().BaseType.Name + "\t"
                + this.GetType().Name + "\t"
                + base.infoToWrite()
                + "\t" + kind;
        }
    }

    public abstract class Engine
    {
        protected double power;
        protected string manufactor;

        public Engine()
        {
            manufactor = "unknown";
        }
        public Engine(double power, string manufactor)
        {
            this.power = power;
            this.manufactor = manufactor;
        }

        public double Power
        {
            get
            {
                return power;
            }
            set
            {
                power = value;
            }
        }
        public string Manufactor
        {
            get
            {
                return manufactor;
            }
            set
            {
                manufactor = value;
            }
        }

        public virtual string getInformation()
        {
            return "Power: " + power + "\t"
                + "Manufactor: "  + manufactor;
        }

        public virtual string infoToWrite()
        {
            return power + "\t"
                + manufactor;
        }
    }

    public class PetrolEngine : Engine
    {
        private int capacity;

        public PetrolEngine()
        {

        }
        public PetrolEngine(double power, string manufactor, int capacity)
                : base(power, manufactor)
        {
            this.capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\t" + capacity;
        }
        public override string infoToWrite()
        {
            return this.GetType().Name + "\t"
                + base.infoToWrite()
                + "\t" + capacity;
        }
    }

    public class Disel : Engine
    {
        private string type;

        public Disel()
        {
            type = "unknown";
        }
        public Disel(double power, string manufactor, string type)
                : base(power, manufactor)
        {
            this.type = type;
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\t" + type;
        }
        public override string infoToWrite()
        {
            return this.GetType().Name + "\t"
                + base.infoToWrite()
                + "\t" + type + "\t";
        }
    }

    public class ReactiveEngine : Engine
    {
        private string grade;

        public ReactiveEngine()
        {
            grade = "air-breathing";
        }
        public ReactiveEngine(double power, string manufactor, string grade)
                : base(power, manufactor)
        {
            this.grade = grade;
        }

        public string Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
            }
        }

        public override string getInformation()
        {
            return base.getInformation()
                + "\t" + grade;
        }
        public override string infoToWrite()
        {
            return this.GetType().Name + "\t"
                + base.infoToWrite()
                + "\t" + grade;
        }
    }
}
