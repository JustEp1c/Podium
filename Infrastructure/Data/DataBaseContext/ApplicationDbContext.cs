using Application.Data.DataBaseContext;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DataBaseContext;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Topic> Topics =>  Set<Topic>();
}