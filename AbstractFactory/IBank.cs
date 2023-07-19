using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory

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
        private List<Tuple<string, IBankFactory>> _factories = new List<Tuple<string, IBankFactory>>();
        public Payment()
        {

            foreach (var type in typeof(Payment).Assembly.GetTypes())
            {
                if (typeof(IBankFactory).IsAssignableFrom(type) && !type.IsInterface)
                {
                    _factories.Add(Tuple.Create(type.Name.Replace("Factory", string.Empty),
                        (IBankFactory)Activator.CreateInstance(type)
                        ));
                }
            }
        }
        public IBank OrderPayment(out int orderid)
        {
            orderid = 0;
            Console.WriteLine("Banks: ");
            for (var index = 0; index < _factories.Count; index++)
            {
                var tuple = _factories[index];
                Console.WriteLine($"{index}:{tuple.Item1}");
            }

            while (true)
            {
                string temp;
                Console.WriteLine($"inter bank number:");
                if ((temp = Console.ReadLine()) != null && int.TryParse(temp, out int index) && index >= 0 && index < _factories.Count)
                {
                    var order = _factories[index].Item2.order(orderid);
                    return order;
                }
            }
            return null;
        }
    }
}