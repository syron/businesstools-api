using System;
using System.Collections.Generic;

namespace businesstools.Models
{
    public class CanvasCategory
    {
        public CanvasCategory()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SingularName { get; set; }
        public IList<CanvasDataItem> Items { get; set; }
    }
}
