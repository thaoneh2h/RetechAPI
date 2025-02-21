using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetechAPI.Models;


namespace RetechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext appDbContext;    
        public UserController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet]
        [Route("GetUsers")]
        public List<User> GetUsers()
        {
            return appDbContext.User.ToList();
        }
        [HttpGet]
        [Route("GetUsersByName")]
        public User GetUser(string name)
        {
            return appDbContext.User.Where(x => x.UserName == name).FirstOrDefault();
        }
        [HttpPost]
        [Route("AddUser")]
        public string AddUser(User user)
        {
            string response = string.Empty;
            appDbContext.User.Add(user);
            appDbContext.SaveChanges();
            return response;
        }
        [HttpPut]
        [Route("UpdateUser")]
        public string UpdateUser(User user)
        {
            appDbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return "User Updated";
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public string DeleteUser(User user)
        {
            appDbContext.User.Remove(user);
            appDbContext.SaveChanges();
            return "User deleted";
        }


    }
}
