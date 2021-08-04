using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp12.Models;

namespace WpfApp12.API
{
    public class OMDB
    {
        HttpClient http = new HttpClient();



        public dynamic Data { get; set; }
        public dynamic SingleData { get; set; }
        public ObservableCollection<Film> Search(string Searched)
        {
            ObservableCollection<Film> film = new ObservableCollection<Film>();
            Film film1;
            HttpResponseMessage response = new HttpResponseMessage();
            response =
                                  http.GetAsync($@"http://www.omdbapi.com/?apikey=118ae76b&s={Searched}&plot=full").Result;
            var str = response.Content.ReadAsStringAsync().Result;
            Data = JsonConvert.DeserializeObject(str);

            foreach (var item in Data.Search)
            {
                response =
                                      http.GetAsync($@"http://www.omdbapi.com/?apikey=118ae76b&t={item.Title}&plot=full").Result;
                str = response.Content.ReadAsStringAsync().Result;
                SingleData = JsonConvert.DeserializeObject(str);


                //http://www.omdbapi.com/?apikey=118ae76b&t=Jaws&plot=full
                //{Data.Search[i].Title}
                film1 = new Film
                {
                    Name = SingleData.Title,
                    ImagePath = SingleData.Poster,
                    Genre = SingleData.Genre,
                    Rating = SingleData.imdbRating
                };
                film.Add(film1);
            }

            return film;
        }
    }
}
