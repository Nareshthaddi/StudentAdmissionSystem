using Microsoft.EntityFrameworkCore;

namespace StudentApi.Models
{
    public class studentDbcontext : DbContext
    {
        public studentDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StudentField> students { get; set; }   
    }
}
