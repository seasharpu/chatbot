namespace chatbotv1.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController(mydbcontext dbContext) : ControllerBase
    {
        private readonly mydbcontext _context = dbContext;

    [HttpGet("{userid}")]
    public async Task<User> getUser(int userid){
        return await _context.Users.FindAsync(userid);
    }

    [httpPost]
    public async Task<iActionResult> newUser(string userName, string password)
    {
        var User = new User() { Name = userName, Password = password };
        _context.users.Add(User);
        await _context.SaveChangesAsync();
        return CreatedAtAction("getUser", new {id = user.id}, user)
    }


    [httpPut("{userid}")]
    public async Task<User> updateUser(int userid, string userName, string password) {
        var User = await getUser(userid);
        User.userName = userName;
        User.password = password;
        await _context.SaveChangesAsync();
        return User;
    }

    //TO DO: delete function, getallusers function
}
}