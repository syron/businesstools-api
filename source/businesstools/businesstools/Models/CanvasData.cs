using System;
namespace businesstools.Models
{
    public class CanvasData
    {
        public CanvasData()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DesignedFor { get; set; }
        public CanvasCategory KeyResources { get; set; }
        public CanvasCategory channels { get; set; }
        public CanvasCategory costStructure { get; set; }
        public CanvasCategory customerRelationships { get; set; }
        public CanvasCategory customerSegments { get; set; }
        public CanvasCategory keyActivities { get; set; }
        public CanvasCategory keyPartners { get; set; }
        public CanvasCategory revenueStreams { get; set; }
        public CanvasCategory valuePropositions { get; set; }
    }
}
