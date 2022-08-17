﻿using PM2_T1P3.Models;
using PM2_T1P3.Services;
using PM2_T1P3.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PM2_T1P3.ViewModels
{
    public class ListViewModels : BaseViewModels
    {
        private List<Empleado> _listaEmpleados;
        EmpleadoServices empleadoServices;

        public List<Empleado> ListaEmpleados
        {
            get { return _listaEmpleados; }
            set
            {
                _listaEmpleados = value;
                OnPropertyChanged();
            }
        }

        public ListViewModels()
        {
            empleadoServices = new EmpleadoServices();

            EditarEmpleadoCommand = new Command<Empleado>(async (Empleado) => await EditarEmpleado(Empleado));
            EliminarEmpleadoCommand = new Command<Empleado>(async (Empleado) => await EliminarEmpleado(Empleado));
        }

        private async Task EliminarEmpleado(Empleado empleado)
        {
            bool response = await empleadoServices.DeleteEmpleado(empleado.Key);

            if (response)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Eliminado Correctamente", "Ok");
                CargarDatos();
            }
            else
                await Application.Current.MainPage.DisplayAlert("Aviso", "Se produjo un error al eliminar", "Ok");
            
        }

        private async Task EditarEmpleado(Empleado empleado)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AddPage("Editar", empleado));
        }

        public async void CargarDatos()
        {
            ListaEmpleados = await empleadoServices.ListarEmpleados();
            if (ListaEmpleados.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "No hay empleados registrados", "Ok");
            }
        }

        public ICommand EditarEmpleadoCommand { get; set; }
        public ICommand EliminarEmpleadoCommand { get; set; }
    }
}
