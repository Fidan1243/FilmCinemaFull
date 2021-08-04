using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp12.Models;

namespace WpfApp12.Repostory
{
    public class Repo
    {
        public ObservableCollection<Film> GetAll()
        {
            return new ObservableCollection<Film>
            {
                new Film
                {
                    Name = "The Conjuring",
                    ImagePath = "Image/poster1.jpg",
                    Genre = "Horror",
                    Rating = "8.1",
                    Time = "112"
                },
                new Film
                {
                    Name = "Scream 4",
                    ImagePath = "Image/poster2.jpg",
                    Genre = "Horror",
                    Rating = "7.8",
                    Time = "111m"
                },
                new Film
                {
                    Name = "The Shawshank Redemption",
                    ImagePath = "Image/poster3.jpg",
                    Genre = "Drama,Crime",
                    Rating = "9.1",
                    Time = "142m"
                }
            };
        }
        public List<OrderedP> GetAllOrdered()
        {
            List<OrderedP> places = new List<OrderedP>();
            for (int i = 0; i < 24; i++)
            {
                places.Add(new OrderedP { Name = (i + 1).ToString() });
            }
            return places;
        }
        public User GetAllAdmin()
        {
            return new User
            {
                Email = "admin@gmail.com",
                Password = "admin"
            };
        }
        public User GetAllGuest()
        {
            return new User
            {
                Email = "g@gmail.com",
                Password = "guest"
            };
        }
    }
}
