using FilmDB.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDB.Core.Services;

public class FilmRepository(string path) : IRepository
{
    private string _path = path;

    public void AddDemoData()
    {
        try
        {
            using (var context = new FilmContext(_path))
            {
                context.Add(new Film("The Dark Knight", 152));
                context.Add(new Film("Inception", 148));
                context.Add(new Film("Der Herr der Ringe: Die zwei Türme", 299));
                context.Add(new Film("Stirb langsam", 132));
                context.Add(new Film("The Matrix", 136));
                
                context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }

    public List<Film> GetAll()
    {
        try
        {
            using (var context = new FilmContext(_path))
            {
                var films = context.Films
                    .FromSql($"SELECT * FROM Films").ToList();

                

                return films;
            }

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return new List<Film>();
        }
    }

    
}
