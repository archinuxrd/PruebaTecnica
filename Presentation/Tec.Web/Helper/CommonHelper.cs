using System.Drawing;
using System.Reflection;
using Tec.Web.Models.Catalog;
using System.Collections.Generic;

namespace Tec.Web.Helper
{
    public static class CommonHelper
    {
        public static List<ColorViewModel> GetAllColors()
        {
            List<ColorViewModel> colors = new List<ColorViewModel>();
            foreach (PropertyInfo property in typeof(Color).GetProperties())
            {
                if (property.PropertyType == typeof(Color))
                {
                    var color = (Color)property.GetValue(null);
                    colors.Add(new ColorViewModel
                    {
                        Key = color.Name,
                        Name = color.Name,
                    });
                }
            }
            return colors;
        }
    }
}