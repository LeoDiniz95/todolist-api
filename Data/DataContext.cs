using Microsoft.EntityFrameworkCore;
using todolist_api.Models;

namespace todolist_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<ItemDM> ItemDMs { get; set; }
    }
}
