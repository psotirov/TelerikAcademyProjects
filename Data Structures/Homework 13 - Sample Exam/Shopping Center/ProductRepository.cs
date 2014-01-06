using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Shopping_Center
{
    class ProductRepository
    {
        private MultiDictionary<string, Tuple<string, double, string>> names;
        private OrderedMultiDictionary<double, Tuple<string, double, string>> prices;
        private MultiDictionary<string, Tuple<string, double, string>> producers;

        public ProductRepository()
        {
            this.names = new MultiDictionary<string, Tuple<string, double, string>>(true);
            this.prices = new OrderedMultiDictionary<double, Tuple<string, double, string>>(true);
            this.producers = new MultiDictionary<string, Tuple<string, double, string>>(true);
        }

        public string AddProduct(string name, double price, string producer)
        {
            Tuple<string, double, string> item = new Tuple<string, double, string>(name, price, producer);

            if (!names.ContainsKey(name))
            {
                names.Add(name, item);
            }
            else
            {
                names[name].Add(item);
            }

            if (!prices.ContainsKey(price))
            {
                prices.Add(price, item);
            }
            else
            {
                prices[price].Add(item);
            }

            if (!producers.ContainsKey(producer))
            {
                producers.Add(producer, item);
            }
            else
            {
                producers[producer].Add(item);
            }

            return "Product added";
        }

        public string DeleteProducts( string producer, string name = "")
        {
            if (!producers.ContainsKey(producer) || (name.Length > 0 && !names.ContainsKey(name)))
            {
                return "No products found";
            }

            Bag<Tuple<string, double, string>> intersection = new Bag<Tuple<string,double,string>>(producers[producer]);
            if (name.Length > 0)
            {
                intersection.IntersectionWith(new Bag<Tuple<string,double,string>>(names[name]));
            }

            int count = 0;
            foreach (var item in intersection)
            {
                names.Remove(item.Item1, item);
                prices.Remove(item.Item2, item);
                producers.Remove(item.Item3, item);
                count++;
            }

            return count.ToString() + " products deleted";
        }

        public string FindProducts(string producer, string name, double fromPrice = -1.0, double toPrice = -1.0)
        {
            ICollection<Tuple<string, double, string>> intersection = null;
            if (producer.Length > 0 && producers.ContainsKey(producer))
            {
                intersection = producers[producer];
            }

            if (name.Length > 0 && names.ContainsKey(name))
            {
                intersection = names[name];
            }

            if (fromPrice >=0.0 && toPrice > 0.0 )
            {
                intersection = prices.Range(fromPrice, true, toPrice, true).Values;
                if (intersection.Count == 0)
                {
                    intersection = null;
                }
            }

            if (intersection == null)
            {
                return "No products found";
            }

            OrderedBag<string> output = new OrderedBag<string>();
            foreach (var item in intersection)
            {
                output.Add(string.Format("{{{0};{1};{2:F2}{3}", item.Item1, item.Item3, item.Item2, "}"));
            }

            StringBuilder result = new StringBuilder();
            foreach (var item in output)
            {
                if (result.Length > 0)
                {
                    result.AppendLine();
                }
                result.Append(item);
            }

            return result.ToString();
        }
    }
}
