using DemoSQLite.Repositories;
using DemoSQLite.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoSQLite
{
    public partial class App : Application
    {

        #region Repository
        private static ContactoRespository _ContactoDb;
        public static ContactoRespository ContactoDb
        {
            get
            {
                if (_ContactoDb == null)
                {
                    _ContactoDb = new ContactoRespository();
                }
                return _ContactoDb;

            }
        }

        private static ActaNacimientoRespository _ActaNacimientoDb;
        public static ActaNacimientoRespository ActaNacimientoDb
        {
            get
            {
                if (_ActaNacimientoDb == null)
                {
                    _ActaNacimientoDb = new ActaNacimientoRespository();
                }
                return _ActaNacimientoDb;

            }
        }

        #endregion
        public App()
        {


            InitializeComponent();

            ActaNacimientoDb.Init();
            ContactoDb.Init();

            MainPage = new NavigationPage(new Inicio());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
