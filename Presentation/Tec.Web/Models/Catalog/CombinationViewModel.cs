using Tec.Web.Core;

namespace Tec.Web.Models.Catalog
{
    public partial class CombinationViewModel : BaseEntityViewModel
    {
        #region Properties
        public string Color { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        
        public int ProductId { get; set; }
        #endregion
    }
}