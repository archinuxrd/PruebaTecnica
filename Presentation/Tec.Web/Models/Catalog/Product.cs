using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tec.Web.Models.Catalog
{
    public class Product
    {
        #region Ctor
        public Product()
        {
            ProductCombinations = new List<ProductCombination>();
        }
        #endregion

        #region Properties
        public int Id { get; set; }

        public string Sku { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        #endregion

        #region Navigation
        public virtual ICollection<ProductCombination> ProductCombinations { get; set; }
        #endregion
    }
}