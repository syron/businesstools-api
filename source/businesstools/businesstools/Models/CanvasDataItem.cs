using System;
namespace businesstools.Models
{
    public class CanvasDataItem
    {
        public CanvasDataItem()
        {
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime Created { get; set; }
    }
}
