using DemoSQLite.Model;
using DemoSQLite.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoSQLite.ViewMode
{
    public class MattoLibroViewModel
    {

        public Libro Libro { get; set; }


        public ICommand cmdGrabaContacto { get; set; }
        public MattoLibroViewModel(Libro libro)
        {

            Libro = libro;

            cmdGrabaContacto = new Command<Libro>((item) => cmdGrabaContactoMetodo(item));


        }

        private void cmdGrabaContactoMetodo(Libro libro)
        {
            App.LibrosDb.InsertOrUpdate(libro);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
