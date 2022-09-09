using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota 
    {
        /// <summary>
        /// Referencia al contexto de Mascota
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }

        /// Metodo crear un Mascota en la BD 
        public Mascota AddMascota(Mascota mascota)
        {
            var mascotaAdicionado = _appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionado.Entity;
        }

      /// Metodo actulizar un Mascota en la BD 
        public Mascota UpdateMascota(Mascota mascota)
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(m => m.Id == mascota.Id);
            if (mascotaEncontrado != null)
            {
                mascotaEncontrado.Nombre = mascota.Nombre;
                mascotaEncontrado.Color = mascota.Color;
                mascotaEncontrado.Especie = mascota.Especie;
                mascotaEncontrado.Raza = mascota.Raza;
                //mascotaEncontrado.HistoriaId = mascota.HistoriaId;
                //mascotaEncontrado.DuenoId = mascota.DuenoId;
                //mascotaEncontrado.VeterinarioId = mascota.VeterinarioId;
                _appContext.SaveChanges();
            }
            return mascotaEncontrado;
        }    

        /// Metodo eliminar un Mascota en la BD 
        public void DeleteMascota(int idMascota)
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrado == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrado);
            _appContext.SaveChanges();
        }
       
       /// Metodos consutar todas las Mascotas en la BD 
       public IEnumerable<Mascota> GetAllMascotas_()
        {
            return _appContext.Mascotas;
        }

        /// Metodo consutar una Mascota por un ID en la BD 
        public Mascota GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
        }

        /// Metodo consutar todos los Mascotas en la BD 
         public IEnumerable<Mascota> GetAllMascotas()
        {
            return GetAllMascotas_();
        }

        /// Metodo consutar la Mascota con filtros  en la BD 
        public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro)
        {
            var mascotas = GetAllMascotas(); // Obtiene todos las Mascotas
            if (mascotas != null)  //Si se tienen Mascotas
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascotas = mascotas.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return mascotas;
        }
   
    }
}