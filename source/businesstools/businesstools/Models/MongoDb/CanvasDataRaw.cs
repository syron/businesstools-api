using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using businesstools.Models.MongoDb;

namespace businesstools.Models.MongoDb
{
    public class CanvasDataRaw
    {
        public CanvasDataRaw()
        {
        }

        public ObjectId _id { get; set; }
        public string CanvasId { get {
                return _id.ToString(); 
            } }
        public string Name { get; set; }
        public string DesignedFor { get; set; }
        public string BelongsTo { get; set; }
        public CanvasCategoryRaw KeyResources { get; set; }
        public CanvasCategoryRaw Channels { get; set; }
        public CanvasCategoryRaw CostStructure { get; set; }
        public CanvasCategoryRaw CustomerRelationships { get; set; }
        public CanvasCategoryRaw CustomerSegments { get; set; }
        public CanvasCategoryRaw KeyActivities { get; set; }
        public CanvasCategoryRaw KeyPartners { get; set; }
        public CanvasCategoryRaw RevenueStreams { get; set; }
        public CanvasCategoryRaw ValuePropositions { get; set; }
    }
}
