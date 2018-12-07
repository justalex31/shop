using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Core.Collection
{
    [Serializable]
    public class Cart : Exception, ISerializable
    {
        public List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Product.ID == product.ID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public Cart() { }

        public void RemoveLine(Product product) => lineCollection.RemoveAll(l => l.Product.ID == product.ID);

        public decimal ComputeTotalValue() => lineCollection.Sum(e => Convert.ToDecimal(e.Product.Price) * e.Quantity);

        public void Clear() => lineCollection.Clear();

        public string ErrorMessage { get; set; }

        public Cart(SerializationInfo info, StreamingContext context)
        {
            if (info != null)
                this.ErrorMessage = info.GetString("ErrorMessage");
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
                info.AddValue("ErrorMessage", this.ErrorMessage);
        }

        public IEnumerable<CartLine> Lines => lineCollection;

    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
