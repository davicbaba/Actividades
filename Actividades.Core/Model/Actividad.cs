using Actividades.Core.Exceptions;
using Actividades.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.Model
{
    /// <summary>
    /// Representa una actividad a realizar
    /// </summary>
    public class Actividad : IValidEntity
    {
        private Estado _Estado { get; set; }

        /// <summary>
        /// Identificador unico de la actividad
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titulo de la actividad
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descripcion de la actividad
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha en que se completo la actividad
        /// </summary>
        public DateTime? FechaCambioEstado { get; set; }

        /// <summary>
        /// Fecha en que la actividad se elimino
        /// </summary>
        public DateTime? FechaBorrado { get; set; }

        /// <summary>
        /// Indica si la actividad a sido finalizada
        /// </summary>
        public bool Finalizada { get; set; }

        /// <summary>
        /// Orden de presentacion de la actividad
        /// </summary>
        public int Orden { get; set; }

        /// <summary>
        /// Identificador unico del estado
        /// </summary>
        public string IdEstado { get;  private set; }

        /// <summary>
        /// Estado en que se encuentra la actividad
        /// </summary>
        public Estado Estado { get => _Estado; set => ModificarEstado(value); }

        /// <summary>
        /// Multimedias anexa a la actividad
        /// </summary>
        public List<Multimedia> Multimedias { get; set; }

        /// <summary>
        /// Fecha de inicio de la actividad
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha en la que finalizara la actividad
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Identificador del usuario al que pertenece la actividad
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// Modifica el estado de una actividad
        /// </summary>
        /// <param name="estado"></param>
        private void ModificarEstado(Estado estado)
        {
            if (estado == null)
                throw new ArgumentException($"El estado a agregar no debe ser nulo");

            FechaCambioEstado = DateTime.Now;
            _Estado = estado;
            
        }

        /// <summary>
        /// Obtener la duracion de una actividad
        /// </summary>
        public TimeSpan GetDuracionActividad()
        {
            return FechaFin - FechaInicio;
        }

        public void IsValid()
        {
            if (FechaInicio > FechaFin)
                throw new EntityException("La fecha inicio de la actividad no debe ser mayor a la fecha final");

        }
    }

    
}
