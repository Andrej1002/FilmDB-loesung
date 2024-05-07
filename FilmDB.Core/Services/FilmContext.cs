using FilmDB.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDB.Core.Services;

public class FilmContext : DbContext
{
    public DbSet<Film> Films { get; set; }

    private readonly string _path = string.Empty;

    public FilmContext(string path)
    {
        _path = path;
        SQLitePCL.Batteries_V2.Init();
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Filename={_path}");
    }
}
