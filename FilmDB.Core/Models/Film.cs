using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDB.Core.Models;

public class Film
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int Duration { get; set; }

    public Film(int id, string name, int duration)
    {
        this.Id = id;
        this.Name = name;
        this.Duration = duration;
    }

    public Film(string name, int duration)
    {
        this.Name = name;
        this.Duration = duration;
    }
}
