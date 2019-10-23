using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using CRUD_School.Model;
using System.Threading.Tasks;

namespace CRUD_School.Services
{
    public class DbFilePath
    {
        SQLiteAsyncConnection DB;
        public DbFilePath()
        {
            var FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "School.db");
            DB = new SQLiteAsyncConnection(FilePath);
            DB.CreateTableAsync<AlumnosModel>().Wait();
        }

        public Task<int> AddAlumno(AlumnosModel alumno)
        {
            return DB.InsertAsync(alumno);
        }

        public Task<int> UpdateAlumno(AlumnosModel alumno)
        {
            return DB.UpdateAsync(alumno);
        }

        public Task<int> DeleteAlumno(AlumnosModel alumno)
        {
           return DB.DeleteAsync(alumno);
        }

        public Task<List<AlumnosModel>> GetAlumnos()
        {
            return DB.Table<AlumnosModel>().ToListAsync();
        }

    }
}
