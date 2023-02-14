using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace SimpleWeb.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        private readonly string MESSAGE_NOT_FOUND = "User Not Registered.";

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetValue<string>("ConnectionStrings:dbConn");
        }

        [HttpPost]
        public string Login(login login)
        {
            string msg = string.Empty;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT username FROM public.login l INNER JOIN public.users u ON l.id = u.loginid " +
                    "WHERE l.username = '" + login.username + "' " +
                    "AND l.password = '" + login.password + "'";

                try
                {
                    var cmd = new NpgsqlCommand(sql, conn);
                    var dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        msg = dataReader.GetString(0) + " welcome back!";
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
            return string.IsNullOrEmpty(msg) ? MESSAGE_NOT_FOUND : msg;
        }
    }
}
