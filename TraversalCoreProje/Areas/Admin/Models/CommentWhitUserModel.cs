namespace TraversalCoreProje.Areas.Admin.Models
{
    public class CommentWhitUserModel
    {
        public int id { get; set; }
        public string CommentUser { get; set; }
        public string CommentContent { get; set; }
        public bool status { get; set; }
        public DateTime CommentData { get; set; }
        public int Userid { get; set; }
        public int Destinitonid { get; set; }
        public string UserImage { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
    }
}
