using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace SimpleWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        private readonly string MESSAGE_NOT_FOUND = "User Not Registered.";

        private IRepositoryWrapper _repository;

        public LoginController(IConfiguration configuration, IRepositoryWrapper repository)
        {
            _configuration = configuration;
            connectionString = _configuration.GetValue<string>("ConnectionStrings:dbConn");
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (model is null)
            {
                return BadRequest("Login is null");
            }

            var login = _repository.Login.GetLoginDto(model);
            if (login == null)
            {
                return NotFound("Login not found."); 
            }

            return Ok(login);
        }


        

        //[HttpPost]
        //public string Login2(Login login)
        //{
        //    string msg = string.Empty;

        //    using (var conn = new NpgsqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        var sql = "SELECT username FROM public.login l INNER JOIN public.users u ON l.id = u.loginid " +
        //            "WHERE l.username = '" + login.username + "' " +
        //            "AND l.password = '" + login.password + "'";

        //        try
        //        {
        //            var cmd = new NpgsqlCommand(sql, conn);
        //            var dataReader = cmd.ExecuteReader();

        //            while (dataReader.Read())
        //            {
        //                msg = dataReader.GetString(0) + " welcome back!";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            msg = ex.Message;
        //        }
        //    }
        //    return string.IsNullOrEmpty(msg) ? MESSAGE_NOT_FOUND : msg;
        //}
    }
}
