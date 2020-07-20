using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domains
{
    public class Product
    {
        public virtual Guid Id { get; set; }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual string QuantityPerUnit { get; set; }

        public virtual string Unit { get; set; }

        public virtual decimal SellPrice { get; set; }

        public virtual decimal BuyPrice { get; set; }

        public virtual string Remark { get; set; }
    }
}
