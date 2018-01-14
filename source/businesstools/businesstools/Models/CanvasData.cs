using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace businesstools.Models
{
    public class CanvasData
    {
        public CanvasData()
        {
        }

        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string DesignedFor { get; set; }
        public CanvasCategory KeyResources { get; set; }
        public CanvasCategory Channels { get; set; }
        public CanvasCategory CostStructure { get; set; }
        public CanvasCategory CustomerRelationships { get; set; }
        public CanvasCategory CustomerSegments { get; set; }
        public CanvasCategory KeyActivities { get; set; }
        public CanvasCategory KeyPartners { get; set; }
        public CanvasCategory RevenueStreams { get; set; }
        public CanvasCategory ValuePropositions { get; set; }
    }
}
