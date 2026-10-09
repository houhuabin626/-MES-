using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Security.Principal;
using 汇制造MES系统.Models;

namespace 汇制造MES系统.SqlHelps
{
    public class UserHelp
    {
        private static IConfiguration builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
     
        public static string? ConnectionString = builder.GetConnectionString("StoreConnet");



        public bool Login(User user)
        {
            using (SqlConnection sql = new SqlConnection(ConnectionString))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from VUser where Account=@Account and Password=@Password", sql);
                SqlParameter[] parameters = { new SqlParameter("@Account", user.Account), new SqlParameter("@Password", user.Password) };
                cmd.Parameters.AddRange(parameters);
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                if (a > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public List<VUser> GetUsers(UserInfo user)
        {
            using (SqlConnection sql = new SqlConnection(ConnectionString))
            {
                sql.Open();
                string sql0 = "select * from VUser where 1=1 ";
                if (user.Account!=null)
                {
                    sql0 += " and Account like @Account ";
                }

                if (user.UserType!=null&&user.UserType!="全部")
                {
                    sql0 += " and UserTypeName=@UserType "; 
                }
                if (user.StatusName!=null && user.StatusName!= "全部")
                {
                    sql0 += " and StatusName=@StatusName ";
                }
                SqlParameter[] sqlParameters = { new SqlParameter("@Account","%"+user.Account+"%"), new SqlParameter("@UserType",user.UserType), new SqlParameter("StatusName",user.StatusName) };
                SqlCommand cmd = new SqlCommand(sql0, sql);
                cmd.Parameters.AddRange(sqlParameters);
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlData.Fill(dataSet);
                return dataSet.Tables[0].AsEnumerable().Skip(((user.NowPage - 1) * user.PageSize)).Take(user.PageSize).ToList().Select(row => new VUser {
                    UserId = row.Field<int>("UserId"),
                    Account = row.Field<string>("Account"),
                    Password = row.Field<string>("Password"),
                    UserTypeId = row.Field<int?>("UserTypeId")??0,
                    UserTypeName = row.Field<string>("UserTypeName"),
                    Remark = row.Field<string>("Remark"),
                    Status = row.Field<short?>("Status")??0,
                    StatusName=row.Field<string>("StatusName"),
                    CreateUserId=row.Field<int?>("CreateUserId")??0,
                    CreateUserName=row.Field<string>("CreateUserName"),
                    CreateTime=row.Field<DateTime?>("CreateTime")??DateTime.MinValue,
                    LastUpdateUserId=row.Field<int?>("LastUpdateUserId"),
                    LastUpdateUserName=row.Field<string>("LastUpdateUserName"),
                    LastUpdateTime=row.Field<DateTime?>("LastUpdateTime")

                }).ToList();
            }

        }
    }
}
