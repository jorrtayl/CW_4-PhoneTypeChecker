using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_4___PhoneTypeChecker
{
    public class PhoneTypeChecker
    {
        Manufacturers manu;
        IPhoneFactory factory;

        public PhoneTypeChecker(Manufacturers m)
        {
            manu = m;
        }

        public void CheckProducts()
        {
            switch (manu)
            {
                case Manufacturers.SAMSUNG:
                    factory = new SamsungFactory();
                    break;
                case Manufacturers.HTC:
                    factory = new HTCFactory();
                    break;
                case Manufacturers.NOKIA:
                    factory = new NokiaFactory();
                    break;
            }

            Console.WriteLine(factory.GetDumb().getName());
            Console.WriteLine(factory.GetSmart().getName());
        }
    }

    public enum Manufacturers { SAMSUNG, HTC, NOKIA };

    public interface IPhoneFactory
    {
        ISmart GetSmart();
        IDumb GetDumb();
    }

    public class SamsungFactory : IPhoneFactory
    {
        public IDumb GetDumb()
        {
            return new Genie();
        }

        public ISmart GetSmart()
        {
            return new GalaxyS2();
        }
    }

    public class HTCFactory : IPhoneFactory
    {
        public IDumb GetDumb()
        {
            return new Primo();
        }

        public ISmart GetSmart()
        {
            return new Titan();
        }
    }

    public class NokiaFactory : IPhoneFactory
    {
        public IDumb GetDumb()
        {
            return new Asha();
        }

        public ISmart GetSmart()
        {
            return new Lumia();
        }
    }

    public interface ISmart
    {
        string getName();
    }

    public class Lumia : ISmart
    {
        public string getName()
        {
            return "Nokia Lumia";
        }
    }

    public class GalaxyS2 : ISmart
    {
        public string getName()
        {
            return "Samsung GalaxyS2";
        }
    }

    public class Titan : ISmart
    {
        public string getName()
        {
            return "HTC Titan";
        }
    }

    public interface IDumb
    {
        string getName();
    }

    public class Asha : IDumb
    {
        public string getName()
        {
            return "Nokia Asha";
        }
    }

    public class Genie : IDumb
    {
        public string getName()
        {
            return "Samsung Genie";
        }
    }

    public class Primo : IDumb
    {
        public string getName()
        {
            return "HTC Primo";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            foreach (Manufacturers e in Enum.GetValues(typeof(Manufacturers)))
            {
                PhoneTypeChecker phoneTypeChecker = new PhoneTypeChecker(e);
                phoneTypeChecker.CheckProducts();
            }
            Console.ReadKey();
        }
    }
}
