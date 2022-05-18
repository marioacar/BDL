using DemoSQLite.Model;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DemoSQLite.Repositories
{
    public class LibroRepo
    {

        SQLiteConnection connection;
        public LibroRepo()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Libro>();
        }

        public void Init()
        {
            connection.CreateTable<Libro>();
        }
        public void InsertOrUpdate(Libro Libro)
        {
            if (Libro.Id == 0)
            {
                Debug.WriteLine($"Id antes de registrar {Libro.Id}");
                connection.InsertWithChildren(Libro);
                Debug.WriteLine($"Id despues de registrar {Libro.Id}");
            }
            else
            {
                Debug.WriteLine($"Id antes de actualizar {Libro.Id}");
                connection.Update(Libro);
                App.FechaPublicacionDb.InsertOrUpdate(Libro.fechaPublicacion);
                Debug.WriteLine($"Id despues de actualizar {Libro.Id}");
            }
        }

        public Libro GetById(int Id)
        {
            return connection.Table<Libro>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();



        }

        public List<Libro> GetAll()
        {

            return connection.GetAllWithChildren<Libro>().ToList();
        }


        public void DeleteItem(int Id)
        {
            Libro contacto = GetById(Id);
            connection.Delete(contacto);
        }

    }
}

