using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using WpfApp12.API;
using WpfApp12.Command;
using WpfApp12.Models;
using WpfApp12.Views;

namespace WpfApp12.ViewModels
{
    public class AdminViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public UserPage Page { get; set; }
        public MainViewModel MainPage { get; set; }
        public Edit1ViewModel ModelExist { get; set; }

        private ObservableCollection<Film> filmList;

        public ObservableCollection<Film> FilmList
        {
            get { return filmList; }
            set { filmList = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Film> listtt;

        public ObservableCollection<Film> Listtt
        {
            get { return listtt; }
            set { listtt = value; OnPropertyChanged(); }
        }

        public string Searched { get; set; }
        private Visibility visibility = Visibility.Collapsed;

        public Visibility Visibility
        {
            get { return visibility; }
            set { visibility = value; OnPropertyChanged(); }
        }

        private Visibility visibility2 ;

        public Visibility Visibility2
        {
            get { return visibility2; }
            set { visibility2 = value; OnPropertyChanged(); }
        }

        private Visibility visibility3 = Visibility.Collapsed;

        public Visibility Visibility3
        {
            get { return visibility3; }
            set { visibility3 = value; OnPropertyChanged(); }
        }

        private Visibility visibility4 = Visibility.Collapsed;

        public Visibility Visibility4
        {
            get { return visibility4; }
            set { visibility4 = value; OnPropertyChanged(); }
        }
        private string filmName;

        public string FilmName
        {
            get { return filmName; }
            set { filmName = value; OnPropertyChanged(); }
        }
        private string filmGenre;

        public string FilmGenre
        {
            get { return filmGenre; }
            set { filmGenre = value; OnPropertyChanged(); }
        }
        private string filmRating;

        public string FilmRating
        {
            get { return filmRating; }
            set { filmRating = value; OnPropertyChanged(); }
        }
        public RelayCommand ExitClick { get; set; }
        public RelayCommand EditOpen { get; set; }

        public RelayCommand SearchClick { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand EditCommand2 { get; set; }
        public bool IsInEdit { get; set; } = false;
        public RelayCommand BackClick { get; set; }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public AdminViewModel()
        {
            EditCommand2 = new RelayCommand((e) =>
            {
                if (!IsInEdit)
                {

                var s = e as Film;
                var view = new EditExistingFilm();
                ModelExist = new Edit1ViewModel();
                ModelExist.AdminModel = this;
                ModelExist.EditedFilm = s;
                ModelExist.EditPage = view;
                view.DataContext = ModelExist;
                    IsInEdit = true;
                view.ShowDialog();
                }
            });
            EditOpen = new RelayCommand((e) =>
            {
                IsInEdit = false;
            },(s)=> 
            {
                if (!IsInEdit)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });
            BackClick = new RelayCommand((e) =>
            {
                Visibility = Visibility.Collapsed;
                Visibility2 = Visibility.Visible;
                Visibility3 = Visibility.Collapsed;
            });
            ExitClick = new RelayCommand((e) => 
            {
                MainPage.Films = FilmList;
                Page.Close();
                MainPage.MainWindow.ShowDialog();
            });
            SearchClick = new RelayCommand((e) =>
            {
                OMDB db = new OMDB();
                Listtt = db.Search(Searched);
                Visibility = Visibility.Visible;
                Visibility2 = Visibility.Collapsed;
                Visibility3 = Visibility.Visible;
            });
        }
    }
}
