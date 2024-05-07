using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmDB.Core.Models;
using FilmDB.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDB.Core.ViewModels;

public partial class MainViewModel(IRepository repository, IRandomMovie randomMovie) : ObservableObject
{
    private IRepository _repository = repository;
    private IRandomMovie randomMovie = randomMovie;


    [ObservableProperty]
    ObservableCollection<Film> _filmCollection = new ObservableCollection<Film>();

    [ObservableProperty]
    Film _randomFilm = null;


    [RelayCommand]
    void Load()
    {
        this.FilmCollection.Clear();

        List<Film> films = _repository.GetAll();  
        
        if (films.Count == 0)
        {
            _repository.AddDemoData();
            films = _repository.GetAll();
        }


        foreach (Film film in films)
        {
            FilmCollection.Add(film);
        }

    }

    [RelayCommand]
    void Random()
    {
        // this.RandomFilm = FilmCollection.ElementAt(0);
        this.RandomFilm = _randomFilm.SelectRandomFilm();
    }


}
