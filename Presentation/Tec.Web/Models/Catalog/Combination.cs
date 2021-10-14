using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tec.Web.Models.Catalog
{
    public class Combination
    {
        #region Properties
        public int Id { get; set; }

        public string Color { get; set; }

        [Range(typeof(int), "0", "9999")]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal UnitPrice { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        #endregion

        #region Navigation
        public virtual Product Product { get; set; }
        #endregion
    }
}