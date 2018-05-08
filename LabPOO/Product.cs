using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPOO
{
    class Product
    {
        public event EventHandler ThresholdReached;

        private string name;
        private int stock;
        private int price; //Price for one unit of the product
        private string unit;
        private int threshold;
        private int total;

        public Product(string name, int price, int stock, string unit, int threshold)
        {
            this.name = name;
            this.stock = stock;
            this.price = price;
            this.unit = unit;
            this.threshold = threshold;
            total = 0;
            
        }
        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public int GetTotal()
        {
            return total;
        }
        public bool Agregar(List<Product> carrito)
        {
            if (this.stock > 0)
            {
                this.total++;
                if (this.total > threshold)
                {
                    OnThresholdReached(EventArgs.Empty);
                }
                else
                {
                    carrito.Add(this);
                    stock--;
                    return true;
                }
            }
            return false;
        }

        public string Name { get => name; }
        public int Stock { get => stock; }
        public int Price { get => price; }
        public string Unit { get => unit; }
    }
}
