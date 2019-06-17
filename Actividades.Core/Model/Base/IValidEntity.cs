using Actividades.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.Model.Base
{
    /// <summary>
    /// Representa una entidad que tiene reglas de negocio que deben ser cumplidas antes de ser almacenada en la base de datos.
    /// </summary>
    public interface IValidEntity
    {
        /// <summary>
        /// Realiza todas las validaciones de negocio de la entidad
        /// </summary>
        /// <exception cref="EntityException">Si es encuentra alguna regla de negocio quebrantada.</exception>
        /// <returns></returns>
        void IsValid();

    }
}
