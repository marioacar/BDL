using DemoSQLite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Repositories
{
    public class ActaNacimientoRespository
    {

        SQLiteConnection connection;

        public ActaNacimientoRespository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<ActaNacimiento>();
        }


        public void Init()
        {
            connection.CreateTable<ActaNacimiento>();
        }
        public void InsertOrUpdate(ActaNacimiento acta)
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

        public ActaNacimiento GetById(int Id)
        {
            return connection.Table<ActaNacimiento>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();



        }

        public List<ActaNacimiento> GetAll()
        {

            return connection.Table<ActaNacimiento>().ToList();
        }


        public void DeleteItem(int Id)
        {
            ActaNacimiento acta = GetById(Id);
            connection.Delete(acta);
        }

    }
}
