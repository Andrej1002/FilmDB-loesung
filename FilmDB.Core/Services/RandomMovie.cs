using FilmDB.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDB.Core.Services;

public class RandomMovie(string path) : IRandomMovie
{
    private string _path = path;

    public Film? SelectRandomFilm()
    {
        try
        {
            using (var context = new FilmContext(_path))
            {
                var films = context.Films
                    .FromSql($"SELECT * FROM Films").ToList();

                Random gen = new Random();
                int auswahl = gen.Next(0, films.Count);

                return films.ElementAt(auswahl);
            }

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return null;
        }
    }
}
