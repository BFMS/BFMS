using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Shared.BFDO
{
    [Serializable]
    public class PriceSize
    {
        public PriceSize()
        {

        }
        public PriceSize(double price, double size)
        {
            this.Price = price;
            this.Size = size;
        }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "size")]
        public double Size { get; set; }

        public override string ToString()
        {
            return new StringBuilder().AppendFormat("{0}@{1}", Size, Price)
                        .ToString();
        }
    }

    class PriceSizeComparer : IEqualityComparer<PriceSize>
    {
        public bool Equals(PriceSize x, PriceSize y)
        {
            return
                x.Price == y.Price &&
                x.Size == y.Size;
        }

        public int GetHashCode(PriceSize obj)
        {
            PriceSize ps = (PriceSize)obj;
            int hash = 27;
            hash = (13 * hash) + ps.Price.GetHashCode();
            hash = (13 * hash) + ps.Size.GetHashCode();
            return hash;
        }
    }

}
