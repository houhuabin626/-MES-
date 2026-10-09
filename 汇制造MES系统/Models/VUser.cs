using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 汇制造MES系统.Models
{
    public  class VUser:BaseModel
    {
        public int UserId {  get; set; }
        public string? Account {  get; set; }
        public string? Password {  get; set; }
        public int UserTypeId { get; set; }
        public string? UserTypeName {  get; set; }
        public string? StatusName {  get; set; }
  
        public string? CreateUserName {  get; set; }
        public string? LastUpdateUserName {  get; set; }



    }
}
