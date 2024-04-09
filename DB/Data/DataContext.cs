using Microsoft.EntityFrameworkCore;
using Entities;

namespace DB.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<TransactionHistory> TransactionHistory { get; set; } = null!;
}
