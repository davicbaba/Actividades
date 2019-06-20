using Actividades.Core.DTO.Output.Actividad;
using Actividades.UIShared.Provider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Actividades.UIForms.ViewModel
{
    public class ActividadesViewModel : BaseViewModel
    {
        private RequestProvider _requestProvider;
        private ObservableCollection<ActividadOutput> _Actividades;
        private bool _IsRefreshing;

        public ObservableCollection<ActividadOutput> Actividades
        {
            set => this.SetValue(ref _Actividades, value);
            get => _Actividades;
        }

        public bool IsRefreshing
        {
            set => this.SetValue(ref _IsRefreshing, value);
            get => _IsRefreshing;
        }

        public ActividadesViewModel()
        {
            _requestProvider = new RequestProvider();
            this.IsRefreshing = true;
            CargarActividades();
        }

        private async void CargarActividades()
        {
            List<ActividadOutput> actividades = await GetActividades();

            this.Actividades = new ObservableCollection<ActividadOutput>(actividades);

            this.IsRefreshing = false;
        } 

        private async Task<List<ActividadOutput>> GetActividades()
        {
            await Task.Delay(4000);

            List<ActividadOutput> actividades = new List<ActividadOutput>()
            {
                new ActividadOutput()
                {
                    Titulo = "Lavar",
                    Descripcion =  "Ve a lavar",
                    FechaInicio = DateTime.Now,
                    FechaFin = DateTime.Now.AddMinutes(10),
                    IdUsuario = "dcruz",
                    Multimedias = new List<Core.DTO.Output.Multimedia.MultimediaOutput>()
                },new ActividadOutput()
                {
                    Titulo = "Jugar",
                    Descripcion =  "Jugar",
                    FechaInicio = DateTime.Now,
                    FechaFin = DateTime.Now.AddMinutes(10),
                    IdUsuario = "dcruz",
                    Multimedias = new List<Core.DTO.Output.Multimedia.MultimediaOutput>()
                },new ActividadOutput()
                {
                    Titulo = "Tarea de dibujo tecnico",
                    Descripcion =  "Muy importante antes de las 7",
                    FechaInicio = DateTime.Now,
                    FechaFin = DateTime.Now.AddMinutes(10),
                    IdUsuario = "dcruz",
                    Multimedias = new List<Core.DTO.Output.Multimedia.MultimediaOutput>()
                },new ActividadOutput()
                {
                    Titulo = "Actividades varias",
                    Descripcion =  null,
                    FechaInicio = DateTime.Now,
                    FechaFin = DateTime.Now.AddMinutes(10),
                    IdUsuario = "dcruz",
                    Multimedias = new List<Core.DTO.Output.Multimedia.MultimediaOutput>()
                },new ActividadOutput()
                {
                    Titulo = "Jugar con la frida",
                    Descripcion =  "Jugar mucho porque se lo merece",
                    FechaInicio = DateTime.Now,
                    FechaFin = DateTime.Now.AddMinutes(10),
                    IdUsuario = "dcruz",
                    Multimedias = new List<Core.DTO.Output.Multimedia.MultimediaOutput>()
                }
            };

            return actividades;
        }
    }
}
