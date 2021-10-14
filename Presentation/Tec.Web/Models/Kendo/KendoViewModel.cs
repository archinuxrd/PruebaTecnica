using System.Collections.Generic;
using System.Linq;

namespace Tec.Web.Models.Kendo
{
    public class KendoViewModel<TEntity> where TEntity : class
    {
        public ICollection<TEntity> Items { get; set; }

        public int ItemCount => Items.Count();
    }
}