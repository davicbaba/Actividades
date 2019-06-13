using Actividades.Core.Model;
using NUnit.Framework;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Test.Model
{
    public class UsuarioTest
    {
        [Test]
        public void IntentarAgregarActividad_HorarioDisponible_AgregadoCorrectamente()
        {
            //Preparacion
            Actividad actividad = GetActividad();

            Usuario usuario = GetUsuario();

            //Ejecucion
            bool agregado = usuario.IntentarAgregarActividad(actividad);

            //Prueba
            Assert.AreEqual(agregado, true);
        }

        [Test]
        public void IntentarAgregarActividad_HorarioDisponible_UsuarioConUnaActividad()
        {
            //Preparacion
            Actividad actividad = GetActividad();

            Usuario usuario = GetUsuario();

            //Ejecucion
            usuario.IntentarAgregarActividad(actividad);

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

            usuario.IntentarAgregarActividad(actividad);

            //Ejecucion
            bool agregado = usuario.IntentarAgregarActividad(actividad);

            //Prueba
            Assert.AreEqual(agregado, false);
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

            usuario.IntentarAgregarActividad(comer);
            usuario.IntentarAgregarActividad(trabajar);
            usuario.IntentarAgregarActividad(hacerTareas);

            Actividad tareaInesperada = comer;

            tareaInesperada.FechaFin.AddMinutes(45);

            //Ejecucion
            bool agregado = usuario.IntentarAgregarActividad(tareaInesperada, true);

            //Prueba
            Assert.AreEqual(agregado, true);
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

            usuario.IntentarAgregarActividad(comer);
            usuario.IntentarAgregarActividad(trabajar);
            usuario.IntentarAgregarActividad(hacerTareas);

            Actividad tareaInesperada = comer;

            tareaInesperada.FechaFin.AddMinutes(45);

            long totalTicksAntes = comer.GetDuracionActividad().Ticks +
                              hacerTareas.GetDuracionActividad().Ticks +
                              trabajar.GetDuracionActividad().Ticks +
                              tareaInesperada.GetDuracionActividad().Ticks;

            //Ejecucion
            bool agregado = usuario.IntentarAgregarActividad(tareaInesperada, true);

            long totalTicksDespues = usuario.Actividades.Sum(x => x.GetDuracionActividad().Ticks);

            //Prueba
            Assert.AreEqual(totalTicksAntes, totalTicksDespues);
        }

        private Actividad GetActividad()
        {
            return new Actividad()
            {
                Id = 1,
                Descripcion = "Realizar actividad de dibujo tecnico",
                Titulo = "Actividad dibujo tecnico",
                Orden = 1,
                Finalizada = false,
                FechaCambioEstado = DateTime.Now
            };
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
