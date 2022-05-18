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
        private static FechaPublicacionRepo _FechaPublicacionDb;
        public static FechaPublicacionRepo FechaPublicacionDb
        {
            get
            {
                if (_FechaPublicacionDb == null)
                {
                    _FechaPublicacionDb = new FechaPublicacionRepo();
                }
                return _FechaPublicacionDb;

            }
        }

        private static LibroRepo _LibroDb;
        public static LibroRepo LibrosDb
        {
            get
            {
                if (_LibroDb == null)
                {
                    _LibroDb = new LibroRepo();
                }
                return _LibroDb;

            }
        }

        #endregion
        public App()
        {


            InitializeComponent();

            FechaPublicacionDb.Init();
            LibrosDb.Init();

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
