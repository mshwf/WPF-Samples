﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomComboBox
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Movies2 = new List<string>
            {
                "String1",
                "String2",
                "String3",
                "String4",
                "String5",
                "String6"
            };
            Movies = new List<Movie>
            {
                new Movie{Id=1, Title="The Dark Knight" },
                new Movie{Id=2, Title="The Big Lebowski" },
                new Movie{Id=3, Title="The Shawshank Redemption" },
                new Movie{Id=4, Title="Schindler's List" },
                new Movie{Id=5, Title="Pulp Fiction" },
                new Movie{Id=6, Title="Fight Club" }
            };

            OnWatchNow = new WatchNowCommand(ShowMovie);
        }

        private void ShowMovie(object parameter)
        {
            if (parameter != null)
            {

                if (parameter is string s)
                    SelectedMovie = s;
                else if (parameter is Movie m)
                    SelectedMovie = m.Title;
            }
        }

        public List<Movie> Movies { get; set; }
        public List<string> Movies2 { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public ICommand OnWatchNow { get; set; }
        string selectedMovie;
        public string SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMovie)));
            }
        }
    }

    public class WatchNowCommand : ICommand
    {
        Action<object> _execut;
        public WatchNowCommand(Action<object> execute)
        {
            _execut = execute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) =>
            _execut(parameter);

    }
}
