﻿using Actividades.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actividades.Core.Model
{
    /// <summary>
    /// Representa una usuario del sistema
    /// </summary>
    public class Usuario 
    {
        public Usuario()
        {
            this.Actividades = new List<Actividad>();
        }

        /// <summary>
        /// Usuario con que se autentica en el sistema
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos del usuario
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Indica cada cuanto se deben recibir notificaciones de actividades cuando estas esten por vencer o esten vencidas.
        /// </summary>
        /// <remarks>
        /// Tiempo que corre a partir que la primera notificacion llega.
        /// </remarks>
        public int NotificacionActividadMinutos { get; set; }

        /// <summary>
        /// Actividades del usuario
        /// </summary>
        public List<Actividad> Actividades { get; private set; }

        public void IntentarGuardarActividad(Actividad actividad, bool forzar = false)
        {
            if (actividad == null)
                throw new ArgumentException("La actividad a agregar no debe ser nula");

            bool horarioDisponible = HorarioDisponible(actividad.FechaInicio, actividad.FechaFin);

            if (horarioDisponible == false && forzar == false)
            {
                throw new EntityException("La actividad no se puede agregar porque no hay espacio en la agenda del usuario");
            }

            if (forzar)
            {
                MoverActividades(actividad);
            }

            this.AddOrUpdate(actividad);

        }

        private void AddOrUpdate(Actividad actividad)
        {
            Actividad act = Actividades.FirstOrDefault(x => x.Id == actividad.Id);

            if(act != null)
            {
                act = actividad;
            }
            else
            {
                Actividades.Add(actividad);
            }
        }


        private bool HorarioDisponible(DateTime fechaInicio, DateTime fechaFin)
        {
            return Actividades.Any(x => x.Finalizada == false && (x.FechaInicio >= fechaInicio && x.FechaFin <= fechaFin)) == false;
        }

        private void MoverActividades(Actividad actividad)
        {
            Actividad actividadBloqueadora = Actividades.FirstOrDefault(x => x.Finalizada == false && x.FechaInicio == actividad.FechaInicio && x.FechaFin == actividad.FechaFin);

            if (actividadBloqueadora == null)
                return;

            List<Actividad> actividadesMover = Actividades.Where(x => x.Finalizada == false && x.FechaInicio >= x.FechaInicio).ToList();

            long milisegundosMover = actividad.GetDuracionActividad().Ticks;

            foreach (var actividadMover in actividadesMover)
            {
                actividadMover.FechaInicio =  actividadMover.FechaInicio.AddTicks(milisegundosMover);
                actividadMover.FechaFin = actividadMover.FechaFin.AddTicks(milisegundosMover);
            }
        }

    }
}
