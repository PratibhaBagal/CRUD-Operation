
using Microsoft.EntityFrameworkCore;
using Mytask.Models;

namespace Mytask.Data
{
    public class MyDBContext:DbContext
    {

        public MyDBContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<User> Users { get; set; }
        
 }
    
}
