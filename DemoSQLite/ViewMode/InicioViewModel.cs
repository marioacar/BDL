using Bogus;
using DemoSQLite.Model;
using DemoSQLite.Repositories;
using DemoSQLite.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoSQLite.ViewMode
{
    public class InicioViewModel : BaseViewModel
    {
        
        public ObservableCollection<Libro> Libros { get; set; }

        public ICommand cmdAgregaContacto { get; set; }
        public ICommand cmdModifcaContacto { get; set; }

        public InicioViewModel()
        {
            Libros = new ObservableCollection<Libro>();
            cmdAgregaContacto = new Command(() => cmdAgregaContactoMetodo());
            cmdModifcaContacto = new Command<Libro>((item) => cmdModifcaContactoMetodo(item));

        }

        private void cmdModifcaContactoMetodo(Libro contacto)
        {
            App.Current.MainPage.Navigation.PushAsync(new MattoContacto(L));
        }

        private void cmdAgregaContactoMetodo()
        {

            Libro libro = new Faker<Libro>()
                .RuleFor(c => c.Avatar, f => f.Person.Avatar)
                .RuleFor(c => c.Nombre, f => f.Name.FirstName())
                .RuleFor(c => c.ApellidoPaterno, f => f.Name.LastName())
                .RuleFor(c => c.ApellidoMaterno, f => f.Name.LastName())
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nombre, c.ApellidoPaterno)).Generate();

            Random rnd = new Random();
            DateTime datetoday = DateTime.Now;

            int rndYear = rnd.Next(1995, datetoday.Year);
            int rndMonth = rnd.Next(1, 12);
            int rndDay = rnd.Next(1, 31);

            DateTime generateDate = new DateTime(rndYear, rndMonth, rndDay);

            Debug.WriteLine($"FECHA ALEATORIA {generateDate}");

            libro.FechaPublicacion = new FechaPublicacion() { FechaPublicacion = generateDate };




            App.Current.MainPage.Navigation.PushAsync(new MattoContacto(libro));

        }

        public void GetAll()

        {
            if (Libros != null)
            {
                Libros.Clear();
                App.LibrosDb.GetAll().ForEach(item => Libros.Add(item));
            }
            else
            {
                Libros = new ObservableCollection<Libro>(App.LibrosDb.GetAll());

            }
            OnPropertyChanged();
        }

    
    }
}
