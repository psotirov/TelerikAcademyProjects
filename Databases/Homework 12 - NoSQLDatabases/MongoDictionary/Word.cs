using MongoDB.Bson;
using System;
using System.Linq;
using System.Text;

namespace MongoDictionary
{
    public class Word
    {
        public ObjectId Id { get; set; }
        public string KeyWord { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} -> {1}", this.KeyWord, this.Description);

            return result.ToString();
        }
    }
}
