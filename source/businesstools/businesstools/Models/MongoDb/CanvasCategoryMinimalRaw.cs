using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace businesstools.Models.MongoDb
{
    public class CanvasCategoryMinimalRaw
    {
        public CanvasCategoryMinimalRaw()
        {
        }

        public IList<CanvasDataItem> Items { get; set; }
    }
}
