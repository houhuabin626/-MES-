using Microsoft.AspNetCore.Mvc;
using System.Data;
using 汇制造MES系统.Models;
using 汇制造MES系统.SqlHelps;

namespace 汇制造MES系统.Controllers
{
   [ApiController]
    [Route("[Controller]")]
    public class UserController : Controller
    {
        UserHelp userHelp;
        public UserController(UserHelp user)
        {

            userHelp = user;

        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User user)
        {
            if (userHelp.Login(user))
            {
                return Ok(new { Code = 200, msg = "登陆成功",Data=user });
            }
            else
            {
                return NotFound(new { Code = 404, msg = "登陆失败" });
            }

        }

        [HttpPost("GetUsers")]
        public IActionResult GetUsers([FromBody] UserInfo user ) 
        {
            List<VUser> result= userHelp.GetUsers(user);
            return Ok(new { Code = 200 ,msg="查询成功",Date= result });
        }
    }
}
