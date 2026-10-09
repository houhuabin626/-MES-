namespace 汇制造MES系统.Models
{
    public class UserInfo
    {
        public string? Account {  get; set; }
        public string?  UserType { get; set; } 
        public string? StatusName {  get; set; }

        public int NowPage {  get; set; }
        public int PageSize {  get; set; }


    }
}
