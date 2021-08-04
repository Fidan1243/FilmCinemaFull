using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp12.Command;
using WpfApp12.Models;
using WpfApp12.Repostory;
using WpfApp12.Views;

namespace WpfApp12.ViewModels
{
    public class MainViewModel
    {
        public Window1 MainWindow { get; set; }
        public GuestViewModel Model { get; set; }
        public AdminViewModel ModelU { get; set; }

        public ObservableCollection<Film> Films { get; set; }
        public List<User> Users { get; set; }
        public List<User> Guests { get; set; }
        public List<int> OrderedPlaces { get; set; } = new List<int>();
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand SignUpCommand { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LoginUN { get; set; }
        public string LoginPassW { get; set; }
        public string SignPassW { get; set; }
        public string SignUN { get; set; }
        public RelayCommand GuestClick { get; set; }
        public bool IsAdmin { get; set; } = true;
        public MainViewModel()
        {
            Repo repos = new Repo();
            Users = new List<User>();
            Users.Add(repos.GetAllAdmin());
            Guests = new List<User>();
            Guests.Add(repos.GetAllGuest());
            Films = repos.GetAll();
            LoginCommand = new RelayCommand((e) =>
            {
                if (IsAdmin)
                {
                    var user = Users.SingleOrDefault((e1) => e1.Email == LoginUN && e1.Password == LoginPassW);
                    if (user != null)
                    {
                        var vieww = new UserPage();
                        ModelU = new AdminViewModel();
                        ModelU.Page = vieww;
                        ModelU.MainPage = this;
                        ModelU.FilmList = Films;
                        vieww.DataContext = ModelU;

                        MainWindow.Hide();
                        vieww.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Wrong password or mail");
                    }
                }
                else
                {
                    var user = Guests.SingleOrDefault((e1) => e1.Email == LoginUN && e1.Password == LoginPassW);
                    if (user != null)
                    {

                        var view = new GuestPage();
                        Model = new GuestViewModel();
                        Model.MainPage = this;
                        Model.FirstFilm = Films.ToList()[0];
                        Model.Page = view;
                        Model.FilmList = Films;
                        view.DataContext = Model;

                        MainWindow.Hide();
                        view.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password or mail");
                    }
                }
            });
            SignUpCommand = new RelayCommand((e) =>
            {
                var User = new User
                {
                    Email = SignUN,
                    Password = SignPassW,
                    Name = Name,
                    Surname = Surname
                };
                if (IsAdmin)
                {
                    Users.Add(User);
                }
                else
                {
                    Guests.Add(User);
                }
                MessageBox.Show("Added to system");
            });
        }
    }
}
