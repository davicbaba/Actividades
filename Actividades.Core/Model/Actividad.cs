using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.Model
{
    /// <summary>
    /// Representa una actividad a realizar
    /// </summary>
    public class Actividad
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
        /// Fecha en que se vence la actividad
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Fecha en que se completo la actividad
        /// </summary>
        public DateTime? FechaCambioEstado { get; set; }

        /// <summary>
        /// Fecha en que la actividad se elimino
        /// </summary>
        public DateTime? FechaBorrado { get; set; }

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
        public List<Multimedia> Multimedia { get; set; }

        private void ModificarEstado(Estado estado)
        {
            if (estado == null)
                throw new ArgumentException($"El estado a agregar no debe ser nulo");

            FechaCambioEstado = DateTime.Now;
            _Estado = estado;
            
        }
    }

    
}
