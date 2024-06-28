using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ControlSystemContext : DbContext
{
    public ControlSystemContext(DbContextOptions<ControlSystemContext> options) : base(options) { }

    public DbSet<Building> Buildings { get; set; }
    public DbSet<LogEntry> LogEntries { get; set; }
    public DbSet<WorkLog> WorkLogs { get; set; }
    public DbSet<ViolationLog> ViolationLogs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Decision> Decisions { get; set; }
}
