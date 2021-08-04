using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp12.Command;
using WpfApp12.Models;
using WpfApp12.Views;

namespace WpfApp12.ViewModels
{
    public class GuestViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public GuestPage Page { get; set; }
        public MainViewModel MainPage { get; set; }
        private ObservableCollection<Film> filmList;

        public ObservableCollection<Film> FilmList
        {
            get { return filmList; }
            set { filmList = value; OnPropertyChanged(); }
        }

        private Film firstFilm;

        public Film FirstFilm
        {
            get { return firstFilm; }
            set { firstFilm = value; OnPropertyChanged(); }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public RelayCommand ExitClick { get; set; }
        public RelayCommand Next { get; set; }
        public RelayCommand Prev { get; set; }
        public RelayCommand OrderCommand { get; set; }
        public int Index { get; set; } = 0;

        public GuestViewModel()
        {
            OrderCommand = new RelayCommand((e) =>
            {
                for (int i = 0; i < 24; i++)
                {
                    if (FirstFilm.Ordered[i].isChecked)
                    {
                        FirstFilm.Ordered[i].isReserved = false;

                    }
                }
                var index = FilmList.ToList().FindIndex((f) => FirstFilm.Name == f.Name);
                FilmList[index] = FirstFilm;
                MainPage.Films = FilmList;
                Page.Close();
                MainPage.MainWindow.ShowDialog();
            });
            ExitClick = new RelayCommand((e) =>
            {
                MainPage.Films = FilmList;
                Page.Close();
                MainPage.MainWindow.ShowDialog();
            });
            Next = new RelayCommand((e) =>
            {
                Index++;
                FirstFilm = FilmList[Index];
            }, (f) =>
             {
                 if (Index + 1 > FilmList.Count-1)
                 {
                     return false;
                 }
                 else
                 {
                     return true;
                 }
             });
            Prev = new RelayCommand((e) =>
            {
                Index--;
                FirstFilm = FilmList[Index];
            }, (f) =>
            {
                if (Index - 1 < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });
        }

    }
}
