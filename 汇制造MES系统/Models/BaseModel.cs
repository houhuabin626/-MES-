using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 汇制造MES系统.Models
{
    public  class BaseModel
    {
        public string? Remark {  get; set; }
        public short? Status {  get; set; }
        public int? CreateUserId {  get; set; }
        public DateTime CreateTime { get; set; }
        public int? LastUpdateUserId { get; set; }
        public DateTime? LastUpdateTime { get; set; }


    }
}
