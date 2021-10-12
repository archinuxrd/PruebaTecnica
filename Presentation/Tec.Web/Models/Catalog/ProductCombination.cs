using System;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace Tec.Web.Models.Catalog
{
    public class ProductCombination
    {
        #region Properties
        public int Id { get; set; }

        public string Color { get; set; }

        [Range(typeof(int), "0", "9999")]
        public int Quantity { get; set; }

        //[Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get; set; }

        //[ForeignKey("Product")]
        public int ProductId { get; set; }
        #endregion

        #region Navigation
        public virtual Product Product { get; set; }
        #endregion
    }
}