using System;
using Tec.Web.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tec.Web.Models.Catalog
{
    public class Combination : BaseEntity
    {
        #region Properties
        public string Color { get; set; }

        [Range(typeof(int), "0", "9999")]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal UnitPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        #endregion

        #region Navigation
        public Product Product { get; set; }
        #endregion
    }
}