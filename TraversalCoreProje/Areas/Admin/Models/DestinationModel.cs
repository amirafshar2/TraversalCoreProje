using EntityLayer.Concrate;

namespace TraversalCoreProje.Areas.Admin.Models
{
    public class DestinationModel
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public IFormFile image { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public string CoverImage { get; set; }
        public IFormFile coverImage { get; set; }
        public string Title1 { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Detail3 { get; set; }
        public string Title3 { get; set; }
        public string Detail4 { get; set; }
        public string Title4 { get; set; }
        public string Detail5 { get; set; }
        public string Title5 { get; set; }
        public string Image2 { get; set; }
        public IFormFile image2 { get; set; }
        public string Image3 { get; set; }
        public IFormFile image3 { get; set; }
    }
}
