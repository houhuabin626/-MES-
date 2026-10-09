namespace 汇制造MES系统.Models
{
    public class User:BaseModel
    {

       
        public int UserId { get; set; }

        
        public string? Account { get; set; }

      
        public string? Password { get; set; }

      
        public int? UserTypeId { get; set; }

    }
}
