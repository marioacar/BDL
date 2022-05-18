using DemoSQLite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Repositories
{
     public class FechaPublicacionRepo
    {
        SQLiteConnection connection;

        public FechaPublicacionRepo()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<FechaPublicacion>();
        }


        public void Init()
        {
            connection.CreateTable<FechaPublicacion>();
        }
        public void InsertOrUpdate(FechaPublicacion acta)
        {
            if (acta.Id == 0)
            {

                connection.Insert(acta);

            }
            else
            {

                connection.Update(acta);

            }
        }

        public FechaPublicacion GetById(int Id)
        {
            return connection.Table<FechaPublicacion>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();



        }

        public List<FechaPublicacion> GetAll()
        {

            return connection.Table<FechaPublicacion>().ToList();
        }


        public void DeleteItem(int Id)
        {
            FechaPublicacion acta = GetById(Id);
            connection.Delete(acta);
        }

    }
}

