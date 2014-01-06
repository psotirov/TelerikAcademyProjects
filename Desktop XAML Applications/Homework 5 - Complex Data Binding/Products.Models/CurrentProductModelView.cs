using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    public class CurrentProductModelView : INotifyPropertyChanged
    {
        private ProductViewModel product;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductViewModel Product
        {
            get
            {
                return product;
            }

            set
            {
                this.product = value;
                this.OnPropertyChanged("Product");
            
            }
        }

        protected void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(p));
            }
        }

        public void GetCurrentProduct(int id)
        {
            this.Product = Products.Models.DataPersister.GetById(id);
        }
    }
}
