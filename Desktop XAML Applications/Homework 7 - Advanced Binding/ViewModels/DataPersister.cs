using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModels
{
    public class DataPersister
    {
        private static string documentPath = "..\\..\\..\\ViewModels\\stores.xml";

        public static IEnumerable<StoreViewModel> GetAll()
        {
            var galleryDocumentRoot = XDocument.Load(documentPath).Root;
            var stores =
                            from store in galleryDocumentRoot.Elements("store")
                            select new StoreViewModel()
                            {
                                Name = store.Element("name").Value,

                                PhonesEnum = from phone in store.Element("phones").Elements("phone")
                                             select new PhoneViewModel()
                                             {
                                                 Vendor = phone.Element("vendor").Value,
                                                 Model = phone.Element("model").Value,
                                                 Image = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), phone.Element("image").Value),
                                                 Year = phone.Element("year").Value,
                                                 OS = new OSViewModel
                                                 {
                                                     Name = phone.Element("os").Element("name").Value,
                                                     Version = phone.Element("os").Element("version").Value,
                                                     Manufacturer = phone.Element("os").Element("manufacturer").Value
                                                 },
                                                 Features = from feature in phone.Element("features").Elements("feature")
                                                            select new FeatureViewModel 
                                                            {
                                                                Name = feature.Element("name").Value,
                                                                Value = feature.Element("value").Value
                                                            }
                                             }
                            };
            return stores;
        }
    }
}
