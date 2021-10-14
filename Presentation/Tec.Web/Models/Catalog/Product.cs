using System;
using System.Collections.Generic;
using Tec.Web.Core;

namespace Tec.Web.Models.Catalog
{
    public partial class Product : BaseEntity
    {
        #region Ctor
        public Product()
        {
            Combinations = new List<Combination>();
        }
        #endregion

        #region Properties
        public string Sku { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        #endregion

        #region Navigation
        public ICollection<Combination> Combinations { get; set; }
        #endregion
    }
}