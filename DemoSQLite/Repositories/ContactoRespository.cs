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
    public class ContactoRespository
    {

        SQLiteConnection connection;
        public ContactoRespository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Contacto>();            
        }

        public void Init()
        {
            connection.CreateTable<Contacto>();
        }
        public void InsertOrUpdate(Contacto contacto)
        {
            if (contacto.Id == 0)
            {
                Debug.WriteLine($"Id antes de registrar {contacto.Id}");
                connection.InsertWithChildren(contacto);               
                Debug.WriteLine($"Id despues de registrar {contacto.Id}");
            }
            else
            {
                Debug.WriteLine($"Id antes de actualizar {contacto.Id}");
                connection.Update(contacto);
                App.ActaNacimientoDb.InsertOrUpdate(contacto.ActaNacimiento);
                Debug.WriteLine($"Id despues de actualizar {contacto.Id}");
            }
        }

        public Contacto GetById( int Id)
        {
            return connection.Table<Contacto>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();



        }

        public List<Contacto> GetAll()
        {

            return connection.GetAllWithChildren<Contacto>().ToList();
        }


        public void DeleteItem(int Id)
        { 
            Contacto contacto = GetById(Id);
            connection.Delete(contacto);
        }

    }
}
