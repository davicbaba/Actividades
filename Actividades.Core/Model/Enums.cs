using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.Model
{
    /// <summary>
    /// Prioridad que tiene la actividad
    /// </summary>
    public enum Prioridad
    {
        /// <summary>
        /// Indica que la prioridad de la actividad es baja
        /// </summary>
        Baja = 1,

        /// <summary>
        /// Indica que la prioridad de la actividad es media
        /// </summary>
        Media = 2,

        /// <summary>
        /// Indica que la prioridad de la actividad es alta
        /// </summary>
        Alta = 3,

        /// <summary>
        /// Indica que la prioridad de la actividad es critica
        /// </summary>
        Critica = 4
    }

    /// <summary>
    /// Indica el estado en que se encuentra la actividad
    /// </summary>
    public enum Estado
    {
        /// <summary>
        /// La actividad esta abierta
        /// </summary>
        Abierto = 1,

        /// <summary>
        /// La actividad se cerro
        /// </summary>
        Cerrado = 2,

        /// <summary>
        /// La actividad se elimino
        /// </summary>
        Eliminado = 3
    }
}
