using DemoSQLite.Model;
using DemoSQLite.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoSQLite.ViewMode
{
    public class MattoContactoViewModel
    {

        public Contacto Contacto { get; set; }

      
        public ICommand cmdGrabaContacto { get; set;  }
        public MattoContactoViewModel(Contacto contacto)
        {

            Contacto = contacto;

            cmdGrabaContacto = new Command<Contacto>((item)=> cmdGrabaContactoMetodo(item));


        }

        private void cmdGrabaContactoMetodo(Contacto contacto)
        {
            App.ContactoDb.InsertOrUpdate(contacto);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
