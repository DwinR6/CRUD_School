using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CRUD_School.Model;
using CRUD_School.Services;
using CRUD_School.View;
using Xamarin.Forms;

namespace CRUD_School.ViewModel
{
    class InicioAlumnosViewModel : Base
    {
        private ObservableCollection<AlumnosModel> _Alumnos;

        public ObservableCollection<AlumnosModel> Alumnos
        {
            get { return _Alumnos; }
            set { _Alumnos = value; OnPropertyChanged(); }
        }
        public Command AddAlumnoCommand { get; set; }
        public Command DetailAlumnoCommand { get; set; }
        public AlumnosModel AlumnoSelected { get; set; }

        public InicioAlumnosViewModel()
        {
            GetAlumnos();
            AddAlumnoCommand = new Command(Save);
            DetailAlumnoCommand = new Command(Detail);

        }

        async void Detail()
        {
            var Pagina = new NewAlumnosView();
            Pagina.BindingContext = new NewAlumnosViewModel(AlumnoSelected);
            await App.Current.MainPage.Navigation.PushAsync(Pagina);
        }

        async void Save()
        {
            var Pagina = new NewAlumnosView();
            await App.Current.MainPage.Navigation.PushAsync(Pagina);
        }

        async void GetAlumnos()
        {
            var con = new DbFilePath();
            var Resultado = await con.GetAlumnos();
            Alumnos = new ObservableCollection<AlumnosModel>(Resultado);
        }

    }
}
