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
        
        public ObservableCollection<Contacto> Contactos { get; set; }

        public ICommand cmdAgregaContacto { get; set; }
        public ICommand cmdModifcaContacto { get; set; }

        public InicioViewModel()
        {
            Contactos = new ObservableCollection<Contacto>();
            cmdAgregaContacto = new Command(() => cmdAgregaContactoMetodo());
            cmdModifcaContacto = new Command<Contacto>((item) => cmdModifcaContactoMetodo(item));

        }

        private void cmdModifcaContactoMetodo(Contacto contacto)
        {
            App.Current.MainPage.Navigation.PushAsync(new MattoContacto(contacto));
        }

        private void cmdAgregaContactoMetodo()
        {

            Contacto contacto = new Faker<Contacto>()
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

            contacto.ActaNacimiento = new ActaNacimiento() { FechaNacimiento = generateDate };




            App.Current.MainPage.Navigation.PushAsync(new MattoContacto(contacto));

        }

        public void GetAll()

        {
            if (Contactos != null)
            {
                Contactos.Clear();
                App.ContactoDb.GetAll().ForEach(item => Contactos.Add(item));
            }
            else
            {
                Contactos = new ObservableCollection<Contacto>(App.ContactoDb.GetAll());

            }
            OnPropertyChanged();
        }

    
    }
}
