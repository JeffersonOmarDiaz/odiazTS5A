
using odiazTS5A.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odiazTS5A.Repository
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;

        //mensaje a mostrar
        public string StatusMessage { get; set; }

        //todo: add variable for the sqlite connection

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Person>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();

                //validar que se igrese el nombre
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre requerido");
                Person person = new Person() { Name = name};
                result = conn.Insert(person);
                StatusMessage = string.Format("{0} record(s) added (Nombre: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public List<Person> GetAllPeople() 
        {
            try
            {
                Init();
                return conn.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }

        public void UpdatePerson(int id, string newName)
        {
            try
            {
                Init();

                // validad que se ingrese el nuevo nombre
                if (string.IsNullOrEmpty(newName)) throw new Exception("Nombre requerido");

                // buscar a la persona por id
                var person = conn.Get<Person>(id);
                if (person == null)
                    throw new Exception("Persona no encontrada");

                person.Name = newName;

                // actualizar el nombre en la base de datos
                conn.Update(person);
                StatusMessage = string.Format("Record updated (ID: {0}, Nuevo Nombre: {1})", id, newName);

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update record (ID: {0}). Error: {1}", id, ex.Message);
            }
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init(); // Inicializar conexión

                // Buscar la persona por ID
                var person = conn.Get<Person>(id);
                if (person == null)
                    throw new Exception("Persona no encontrada");

                // Eliminar de la base de datos
                conn.Delete(person);
                StatusMessage = string.Format("Record deleted (ID: {0})", id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete record (ID: {0}). Error: {1}", id, ex.Message);
            }
        }

    }
}
