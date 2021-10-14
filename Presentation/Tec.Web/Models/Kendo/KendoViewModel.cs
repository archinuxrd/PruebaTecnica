using System.Collections.Generic;
using System.Linq;

namespace Tec.Web.Models.Kendo
{
    public class Kendo<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Items { get; set; }

        public int ItemCount { 
            get {
                return this.Items.Count();
            }
        }
    }
}