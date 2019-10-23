using CRUD_School.Model;
using CRUD_School.Services;
using CRUD_School.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRUD_School.ViewModel
{
    public class NewAlumnosViewModel
    {
        public DbFilePath dbFilePath { get; set; }
        public AlumnosModel AlumnoSelected { get; set; }
        public Command SaveCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public  string FechaNacimiento { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public int NumeroMovil { get; set; }
        public int Edad { get; set; }

        public NewAlumnosViewModel()
        {
            AlumnoSelected = null;
            dbFilePath = new DbFilePath();
            SaveCommand = new Command(Save);
            DeleteCommand = new Command(Delete);

        }

        public NewAlumnosViewModel(AlumnosModel alumno) : this()
        {
            AlumnoSelected = alumno;
            if(AlumnoSelected != null)
            {
                Nombres = alumno.Nombres;
                Apellidos = alumno.Apellidos;
                FechaNacimiento = alumno.FechaNacimiento;
                Grado = alumno.Grado;
                Seccion = alumno.Seccion;
                NumeroMovil = alumno.NumeroMovil;
                Edad = alumno.Edad;
            }
        }

        async void Delete()
        {
            var RespuestaDB = await dbFilePath.DeleteAlumno(AlumnoSelected);
            if(RespuestaDB == 1)
            {
                await App.Current.MainPage.DisplayAlert("Info", "Elimindado", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new InicioAlumnosView());
            }
        }

        async void Save()
        {
            if(AlumnoSelected != null)
            {
                AlumnoSelected.Nombres = Nombres;
                AlumnoSelected.Apellidos = Apellidos;
                AlumnoSelected.FechaNacimiento = FechaNacimiento;
                AlumnoSelected.Grado = Grado;
                AlumnoSelected.Seccion = Seccion;
                AlumnoSelected.NumeroMovil = NumeroMovil;
                AlumnoSelected.Edad = Edad;
                var RespuestaBD = await dbFilePath.UpdateAlumno(AlumnoSelected);
                if(RespuestaBD == 1)
                {
                    await App.Current.MainPage.DisplayAlert("Info", "Registro guardado", "ok");
                    await App.Current.MainPage.Navigation.PushAsync(new InicioAlumnosView());
                }
                else
                {
                    var NewAlumno = new AlumnosModel();
                    NewAlumno.Nombres = Nombres;
                    NewAlumno.Apellidos = Apellidos;
                    NewAlumno.FechaNacimiento = FechaNacimiento;
                    NewAlumno.Grado = Grado;
                    NewAlumno.Seccion = Seccion;
                    NewAlumno.NumeroMovil = NumeroMovil;
                    NewAlumno.Edad = Edad;
                    var ResultadoDB = await dbFilePath.AddAlumno(NewAlumno);
                    if(ResultadoDB == 1)
                    {
                        await App.Current.MainPage.DisplayAlert("Info", "Registrado", "OK");
                        await App.Current.MainPage.Navigation.PushAsync(new InicioAlumnosView());
                    }
                }
            }
        }
        
    }
}
