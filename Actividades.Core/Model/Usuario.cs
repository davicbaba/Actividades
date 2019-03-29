using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.Model
{
    /// <summary>
    /// Representa una usuario del sistema
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Usuario con que se autentica en el sistema
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellidos del usuario
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Indica cada cuanto se deben recibir notificaciones de actividades a partir que se recibio la primera notificacion de vencimiento
        /// </summary>
        public int NotificacionActividadMinutos { get; set; }

        /// <summary>
        /// Indica cuando se debe enviar la primera notificacion
        /// </summary>
        public int TiempoPrimeraNotificacionMinutos { get; set; }

    }
}
