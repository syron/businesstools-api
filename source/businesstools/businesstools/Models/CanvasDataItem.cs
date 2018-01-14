using System;
using MongoDB.Bson;

namespace businesstools.Models
{
    public class CanvasDataItem
    {
        public CanvasDataItem()
        {
        }

        public ObjectId _id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime Created { get; set; }
    }
}
