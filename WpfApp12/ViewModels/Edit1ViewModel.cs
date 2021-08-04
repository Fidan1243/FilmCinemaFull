using System;
using System.Collections.Generic;
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
    public class Edit1ViewModel: INotifyPropertyChanged
    {
        public EditExistingFilm EditPage { get; set; }
        public AdminViewModel AdminModel { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        private Film editing;

        public Film EditedFilm
        {
            get { return editing; }
            set { editing = value; OnPropertyChanged(); }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Edit1ViewModel()
        {
            SaveCommand = new RelayCommand((e) =>
            {
                var s = AdminModel.FilmList.IndexOf(EditedFilm);
                if (s == -1)
                {
                    AdminModel.FilmList.Add(EditedFilm);
                }
                EditPage.Close();
            });
            DeleteCommand = new RelayCommand((e) =>
            {
                var s = AdminModel.FilmList.IndexOf(EditedFilm);
                if (s != -1)
                {
                    AdminModel.FilmList.RemoveAt(s);
                }
                EditPage.Close();
            });
            CancelCommand = new RelayCommand((e) =>
            {
                EditPage.Close();
            });
        }


    }
}
