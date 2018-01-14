using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace businesstools.Models
{
    public class CanvasCategory
    {
        public CanvasCategory()
        {
        }

        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SingularName { get; set; }
        public IList<CanvasDataItem> Items { get; set; }
    }
}
