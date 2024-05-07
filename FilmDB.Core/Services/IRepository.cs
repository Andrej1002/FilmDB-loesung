using FilmDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDB.Core.Services;

public interface IRepository
{
    List<Film> GetAll();

    void AddDemoData();
}
