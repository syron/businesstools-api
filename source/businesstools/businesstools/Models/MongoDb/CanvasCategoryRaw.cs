using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace businesstools.Models.MongoDb
{
    public class CanvasCategoryRaw
    {
        public CanvasCategoryRaw()
        {
        }

        public IList<CanvasDataItem> Items { get; set; }
    }
}
