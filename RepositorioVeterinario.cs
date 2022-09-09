using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        /// <summary>
        /// Referencia al contexto de Veterinario
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        /// Metodo crear un Veterinario en la BD 
        public  Veterinario AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado = _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

         /// Metodo actulizar un Veterinario en la BD 
        public Veterinario UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == veterinario.Id);
            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombres = veterinario.Nombres;
                veterinarioEncontrado.Apellidos = veterinario.Apellidos;
                veterinarioEncontrado.Direccion = veterinario.Direccion;
                veterinarioEncontrado.Telefono = veterinario.Telefono;
                veterinarioEncontrado.TarjetaProfesional = veterinario.TarjetaProfesional;
                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }     

        /// Metodo eliminar un Veterinario en la BD 
        public void DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == idVeterinario);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }
       
       /// Metodos consutar el Veterinario en la BD 
       public IEnumerable<Veterinario> GetAllVeterinarios_()
        {
            return _appContext.Veterinarios;
        }

        /// Metodos consutar un Veterinario en la BD 
        public Veterinario GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(v => v.Id == idVeterinario);
        }

        /// Metodos consutar todos los Veterinarios en la BD 
         public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            return GetAllVeterinarios_();
        }

        /// Metodos consutar el Veterinario con filtros  en la BD 
        public IEnumerable<Veterinario> GetVeterinariosPorFiltro(string filtro)
        {
            var veterinarios = GetAllVeterinarios(); // Obtiene todos los Veterinarios
            if (veterinarios != null)  //Si se tienen Veterinarios
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    veterinarios = veterinarios.Where(s => s.Nombres.Contains(filtro));
                }
            }
            return veterinarios;
        }
   
    }
}