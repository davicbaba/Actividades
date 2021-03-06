﻿using Actividades.Core.Model;
using NUnit.Framework;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Actividades.Core.Exceptions;

namespace Actividades.Test.Model
{
    public class UsuarioTest
    {
        private List<Actividad> ActividadesGeneradas = new List<Actividad>();

        [Test]
        public void IntentarAgregarActividad_HorarioDisponible_AgregadoCorrectamente()
        {
            //Preparacion
            Actividad actividad = GetActividad();

            Usuario usuario = GetUsuario();

            //Prueba
            Assert.DoesNotThrow(() => usuario.IntentarGuardarActividad(actividad));
        }

        [Test]
        public void IntentarAgregarActividad_HorarioDisponible_UsuarioConUnaActividad()
        {
            //Preparacion
            Actividad actividad = GetActividad();

            Usuario usuario = GetUsuario();

            //Ejecucion
            usuario.IntentarGuardarActividad(actividad);

            //Prueba
            Assert.AreEqual(usuario.Actividades.Count, 1);
        }

        [Test]
        public void IntentarAgregarActividad_HorarioNoDisponible_ActividadNoAgregada()
        {
            //Preparacion
            Actividad actividad = GetActividad();

            actividad.FechaInicio = DateTime.Now;

            actividad.FechaFin = DateTime.Now.AddHours(1);

            Usuario usuario = GetUsuario();

            usuario.IntentarGuardarActividad(actividad);

            //Prueba
            Assert.Throws<EntityException>(() => usuario.IntentarGuardarActividad(actividad));
        }


        [Test]
        public void IntentarAgregarActividad_ForzarHorario_ActividadAgregada()
        {
            //Preparacion
            Actividad comer = GetActividad();

            comer.FechaInicio = DateTime.Now;

            comer.FechaFin = DateTime.Now.AddHours(1);

            Actividad trabajar = GetActividad();

            trabajar.FechaInicio = comer.FechaFin.AddHours(1);
            trabajar.FechaFin = trabajar.FechaInicio.AddHours(2);

            Actividad hacerTareas = GetActividad();

            hacerTareas.FechaInicio = trabajar.FechaInicio.AddHours(1);
            hacerTareas.FechaFin = hacerTareas.FechaInicio.AddHours(3);

            Usuario usuario = GetUsuario();

            usuario.IntentarGuardarActividad(comer);
            usuario.IntentarGuardarActividad(trabajar);
            usuario.IntentarGuardarActividad(hacerTareas);

            Actividad tareaInesperada = comer;

            tareaInesperada.FechaFin.AddMinutes(45);

            //Prueba
            Assert.DoesNotThrow(() => usuario.IntentarGuardarActividad(tareaInesperada, true));
        }

        [Test]
        public void IntentarAgregarActividad_ForzarHorario_TiempoEntreCadaActividadNoAfectado()
        {
            //Preparacion
            Actividad comer = GetActividad();

            comer.FechaInicio = DateTime.Now;

            comer.FechaFin = DateTime.Now.AddHours(1);

            Actividad trabajar = GetActividad();

            trabajar.FechaInicio = comer.FechaFin.AddHours(1);
            trabajar.FechaFin = trabajar.FechaInicio.AddHours(2);

            Actividad hacerTareas = GetActividad();

            hacerTareas.FechaInicio = trabajar.FechaInicio.AddHours(1);
            hacerTareas.FechaFin = hacerTareas.FechaInicio.AddHours(3);

            Usuario usuario = GetUsuario();

            usuario.IntentarGuardarActividad(comer);
            usuario.IntentarGuardarActividad(trabajar);
            usuario.IntentarGuardarActividad(hacerTareas);

            Actividad tareaInesperada = GetActividad();

            tareaInesperada.FechaInicio = comer.FechaInicio;
            tareaInesperada.FechaFin = comer.FechaFin;

            tareaInesperada.FechaFin.AddMinutes(45);

            long totalTicksAntes = comer.GetDuracionActividad().Ticks +
                              hacerTareas.GetDuracionActividad().Ticks +
                              trabajar.GetDuracionActividad().Ticks +
                              tareaInesperada.GetDuracionActividad().Ticks;

            //Ejecucion
             usuario.IntentarGuardarActividad(tareaInesperada, true);

            long totalTicksDespues = usuario.Actividades.Sum(x => x.GetDuracionActividad().Ticks);

            //Prueba
            Assert.AreEqual(totalTicksAntes, totalTicksDespues);
        }

        private Actividad GetActividad()
        {
            int max = 1;

            if (ActividadesGeneradas.Any())
            {
                max = ActividadesGeneradas.Max(x => x.Id);
                max++;
            }

            Actividad act = new Actividad()
            {
                Id = max,
                Descripcion = "Realizar actividad de dibujo tecnico",
                Titulo = "Actividad dibujo tecnico",
                Finalizada = false,
                FechaCambioEstado = DateTime.Now
            };

            ActividadesGeneradas.Add(act);
            return act;
        }

        private Usuario GetUsuario()
        {
            return new Usuario()
            {
                Nombres = "Davis",
                Apellidos = "Cruz",
                NotificacionActividadMinutos = 10,
                UserName = ""
            };
        }
    }
}
