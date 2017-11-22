using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratorio2.Model
{
    public class PersonaModel
    {

        public int Id { get; set; }

        public string FotoPath { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        public string Sexo { get; set; }

        public string Observaciones { get; set; }

        public string NombreCompleto => Nombre + " " + ApellidoPaterno +" "+ApellidoMaterno;

        public ObservableCollection<VentasModel> LstVentas { get; set; }

        public PersonaModel()
        {
        }

        public static async Task<ObservableCollection<PersonaModel>> ObtenerPersonas()
        {

            ObservableCollection<PersonaModel> lstPersonas = new ObservableCollection<PersonaModel>();


            lstPersonas.Add(new PersonaModel { Id = 1, Nombre = "Carlos", ApellidoPaterno = "Bejarano", ApellidoMaterno = "Alpizar", FotoPath = "foto_perfil.png" });
            lstPersonas.Add(new PersonaModel { Id = 2, Nombre = "Yendry", ApellidoPaterno = "Bejarano", ApellidoMaterno = "Alpizar", FotoPath = "foto_perfil.png" });
            lstPersonas.Add(new PersonaModel { Id = 3, Nombre = "Natasha", ApellidoPaterno = "Bejarano", ApellidoMaterno = "Alpizar", FotoPath = "foto_perfil.png" });
            lstPersonas.Add(new PersonaModel { Id = 4, Nombre = "Jose", ApellidoPaterno = "Bejarano", ApellidoMaterno = "Alpizar", FotoPath = "foto_perfil.png" });
            lstPersonas.Add(new PersonaModel { Id = 5, Nombre = "Andres", ApellidoPaterno = "Bejarano", ApellidoMaterno = "Alpizar", FotoPath = "foto_perfil.png" });
            lstPersonas.Add(new PersonaModel { Id = 6, Nombre = "Natalia", ApellidoPaterno = "Bejarano", ApellidoMaterno = "Alpizar", FotoPath = "foto_perfil.png" });
            lstPersonas.Add(new PersonaModel { Id = 7, Nombre = "Benjamin", ApellidoPaterno = "Bejarano", ApellidoMaterno = "Alpizar", FotoPath = "foto_perfil.png" });
            lstPersonas.Add(new PersonaModel { Id = 8, Nombre = "Johan", ApellidoPaterno = "Bejarano", ApellidoMaterno = "Alpizar", FotoPath = "foto_perfil.png" });
            lstPersonas.Add(new PersonaModel { Id = 9, Nombre = "Marcela", ApellidoPaterno = "Bejarano", ApellidoMaterno = "Alpizar", FotoPath = "foto_perfil.png" });
            lstPersonas.Add(new PersonaModel { Id = 10, Nombre = "Irene", ApellidoPaterno = "Bejarano", ApellidoMaterno = "Alpizar", FotoPath = "foto_perfil.png" });

            Thread.Sleep(4000);


            return lstPersonas;

        }


    }
}
