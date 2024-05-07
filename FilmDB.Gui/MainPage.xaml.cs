using FilmDB.Core.ViewModels;

namespace FilmDB.Gui;

public partial class MainPage : ContentPage
{
    

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;

    }

    
}
