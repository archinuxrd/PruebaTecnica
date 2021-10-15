using Tec.Web.Core;
using System.Collections.Generic;

namespace Tec.Web.Models.Catalog
{
    public class ProductViewModel : BaseEntityViewModel
    {
        public ProductViewModel()
        {
            Combinations = new List<Combination>();
        }
        #region Properties
        public string Sku { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        #endregion
        
        #region Navigation
        public ICollection<Combination> Combinations { get; set; }
        #endregion
    }
}
