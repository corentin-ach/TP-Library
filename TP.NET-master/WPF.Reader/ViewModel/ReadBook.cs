using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    class ReadBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public ICommand GoBack { get; init; } = new RelayCommand(x => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(x); });

        // A vous de jouer maintenant
        public Book CurrentBook { get; init; }

        public ReadBook(Book book)
        {
            CurrentBook = book;
            // FullBook avec contenu = getBook() 
        }

    }
    

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    class InDesignReadBook : ReadBook
    {
        public InDesignReadBook() : base(new Book() /*{ Title = "Test Book" }*/) 
        {
        }
    }
}
