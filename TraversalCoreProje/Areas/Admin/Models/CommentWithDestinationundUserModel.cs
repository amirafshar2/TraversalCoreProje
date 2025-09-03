namespace TraversalCoreProje.Areas.Admin.Models
{
    public class CommentWithDestinationundUserModel
    {
        public int id { get; set; }
        public string CommentUser { get; set; }
        public string CommentContent { get; set; }
        public bool status { get; set; }
        public DateTime CommentData { get; set; }
        public int DestinationID { get; set; }
        public string DesCity { get; set; }
        public string DesImage { get; set; }
        public int UserID { get; set; }
        public string UserImage { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
    }
}
