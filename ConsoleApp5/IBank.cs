using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public interface IBank
    {
        void Verify();
    }

    public class Meli : IBank
    {
        public void Verify()
        {
            Console.WriteLine("meli");
        }
    }
    public class Saderat : IBank
    {
        public void Verify()
        {
            Console.WriteLine("Saderat");
        }
    }
    public class Mellat : IBank
    {
        public void Verify()
        {
            Console.WriteLine("Mellat");
        }
    }

    public interface IBankFactory
    {
        IBank order(int id);
    }

    public class MeliFactory : IBankFactory
    {
        public IBank order(int id)
        {
            var model = new Meli();
            model.Verify();
            return model;
        }
    }
    public class MellatFactory : IBankFactory
    {
        public IBank order(int id)
        {
            var model = new Mellat();
            model.Verify();
            return model;
        }
    }
    public class SaderatFactory : IBankFactory
    {
        public IBank order(int id)
        {
            var model = new Saderat();
            model.Verify();
            return model;
        }
    }
    public class Payment
    {
        public enum AvalableBank
        {
            Meli,
            Saderat,
            Mellat
        }
        private Dictionary<AvalableBank, IBankFactory> _factories=
            new Dictionary<AvalableBank, IBankFactory> ();

        public Payment()
        {
            foreach(AvalableBank bank in Enum.GetValues(typeof(AvalableBank)))
            {
                var factory=(IBankFactory)Activator.CreateInstance(Type.GetType($"ConsoleApp5.{Enum.GetName(typeof(AvalableBank), bank)}Factory"));
                _factories.Add(bank, factory);
            }
        }
        public IBank OrderPayment(AvalableBank bank,int orderid)
        {
             return _factories[bank].order(orderid);
        }
    }
}
