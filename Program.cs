using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
         private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
         private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
         private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        //private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        //private static IRepositorioVisitaPyP _repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos vamos a empezar a trabajar con las tablas");
            
             //AddDueno();
            //BuscarDueno(1);
            //ListarDuenos();
            //ListarDuenosFiltro(); 
             //AddVeterinario();
            //BuscarVeterinario(13);
            //ListarVeterinarios();
            //ListarVeterinariosFiltro();
             //AddMascota();
             //BuscarMascota(1);
             ListarMascotas();
             //ListarMascotasFiltro();
            //AddHistoria();
        }

        /// Metodo crear un Dueño en la BD 
        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Nombres = "Calor",
                Apellidos = "Gomez", 
                Direccion = "Carrera 45 No. 110 - 21",
                Telefono = "31842534112",
                Correo = "carlosc@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

        /// Metodos consutar un Dueño en la BD 
        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos+" "+dueno.Direccion+" "+dueno.Telefono+" "+dueno.Correo);
        }

        /// Metodos consutar todos los Dueños en la BD 
         private static void ListarDuenos()
        {
            var duenosM = _repoDueno.GetAllDuenos();
            foreach (Dueno p in duenosM)
            {
                Console.WriteLine(p.Id + " " + p.Nombres + " " + p.Apellidos + " " + p.Direccion + " " + p.Telefono + " " + p.Correo);
            }        
        }

       /// Metodos consutar el Dueño con filtros  en la BD 
        private static void ListarDuenosFiltro()
        {
            var duenosM = _repoDueno.GetDuenosPorFiltro("C");
            foreach (Dueno p in duenosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }
        }

        /// Metodo crear un Veterinario en la BD 
         private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombres = "El Chavo",
                Apellidos = "Restrepo", 
                Direccion = "Calle 30 # 16-30",
                Telefono = "3202134578",
                TarjetaProfesional = "TP0002"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        /// Metodos consutar un Veterinario en la BD 
        private static void BuscarVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }

        /// Metodos consutar todos los Veterinarios en la BD 
         private static void ListarVeterinarios()
        {
            var veterinariosM = _repoVeterinario.GetAllVeterinarios();
            foreach (Veterinario p in veterinariosM)
            {
                Console.WriteLine(p.Id + " " + p.Nombres + " " + p.Apellidos + " " + p.Direccion + " " + p.Telefono + " " + p.TarjetaProfesional);
            }        
        }

        /// /// Metodos consutar el Veterinario con filtros  en la BD 
        private static void ListarVeterinariosFiltro()
        {
            var veterinariosM = _repoVeterinario.GetVeterinariosPorFiltro("l");
            foreach (Veterinario p in veterinariosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }
        }

       /// Metodo crear una Mascota  en la BD 
        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "Natacha",
                Color = "Blanca", 
                Especie = "Gato",
                Raza = "Angora",
            };
            _repoMascota.AddMascota(mascota);
        }

        /// Metodos consutar una Mascota en la BD 
        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie);
        }

        /// Metodos consutar todos las Mascotas en la BD 
         private static void ListarMascotas()
        {
            var mascotasM = _repoMascota.GetAllMascotas();
            foreach (Mascota p in mascotasM)
            {
                Console.WriteLine(p.Id + " " + p.Nombre + " " + p.Color + " " + p.Especie + " " + p.Raza);
            }        
        }
        /// Metodos consutar la mascota con filtros  en la BD 
        private static void ListarMascotasFiltro()
        {
            var mascotasM = _repoMascota.GetMascotasPorFiltro("N");
            foreach (Mascota p in mascotasM)
            {
                Console.WriteLine(p.Nombre + " " + p.Color+ " " + p.Especie);
            }
        }
        /*private static void AddHistoria()
        {
            var historia = new Historia
            {
                FechaInicial = new DateTime(1990, 04, 12)
                
            };
            _repoHistoria.AddHistoria(historia);
        }*/
    }
}