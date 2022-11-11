using Club_in_API.UserType.Model;
using Microsoft.EntityFrameworkCore;

namespace Club_in_API.UserType.ApplicationDBContext
{
    public class UserTypeContext : DbContext
    {
        public UserTypeContext(DbContextOptions<UserTypeContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
