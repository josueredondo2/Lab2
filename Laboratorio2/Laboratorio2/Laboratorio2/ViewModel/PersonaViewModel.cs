using Laboratorio2.Model;
using Laboratorio2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laboratorio2.ViewModel
{
    class PersonaViewModel: INotifyPropertyChanged
    {
        #region Singleton
        private static PersonaViewModel instance = null;

        private PersonaViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static PersonaViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new PersonaViewModel();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
        #endregion

        #region Instances

        private List<PersonaModel> lstOriginalPersonas = new List<PersonaModel>();

        private ObservableCollection<PersonaModel> _lstPersonas = new ObservableCollection<PersonaModel>();

        public ObservableCollection<PersonaModel> lstPersonas
        {
            get
            {
                return _lstPersonas;
            }
            set
            {
                _lstPersonas = value;
                OnPropertyChanged("lstProducts");
            }
        }

        private string _TextoBuscar = string.Empty;

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }
            set
            {
                _TextoBuscar = value;
                OnPropertyChanged("TextoBuscar");
                FiltrarPersona(_TextoBuscar);
            }
        }

        private string _NuevaPersona = string.Empty;

        public string NuevaPersona
        {
            get
            {
                return _NuevaPersona;
            }
            set
            {
                _NuevaPersona = value;
                OnPropertyChanged("NuevaPersona");
            }
        }

        private PersonaModel _PersonaActual { get; set; }

        public PersonaModel PersonaActual
        {
            get
            {
                return _PersonaActual;
            }
            set
            {
                _PersonaActual = value;
                OnPropertyChanged("PersonaActual");
            }
        }

        private double _TotalVenta = 0;

        public double TotalVenta
        {
            get
            {
                return _TotalVenta;
            }
            set
            {
                _TotalVenta = value;
                OnPropertyChanged("TotalVenta");
                
            }
        }





        private ObservableCollection<ArticuloModel> _lstArticulos = new ObservableCollection<ArticuloModel>();

        public ObservableCollection<ArticuloModel> lstArticulos
        {
            get
            {
                return _lstArticulos;
            }
            set
            {
                _lstArticulos = value;
                OnPropertyChanged("lstArticulos");
            }
        }


        private ObservableCollection<ArticuloModel> _lstArticulosNuevos = new ObservableCollection<ArticuloModel>();

        public ObservableCollection<ArticuloModel> lstArticulosNuevos
        {
            get
            {
                return _lstArticulosNuevos;
            }
            set
            {
                _lstArticulosNuevos = value;
                OnPropertyChanged("lstArticulosNuevos");
            }
        }



        public ICommand AgregarPersonaCommand { get; set; }
        public ICommand BorrarPersonaCommand { get; set; }
        public ICommand VerPersonaCommand { get; set; }
        public ICommand AgregarVentaCommand{ get; set; }
        public ICommand AgregarArticuloCommand { get; set; }

        public ICommand NuevaVentaCommand { get; set; }


        #endregion

        #region Methods

        private void AgregarPersona()
        {
            lstPersonas.Add(new PersonaModel { Nombre = NuevaPersona });
            lstOriginalPersonas.Add(new PersonaModel { Nombre = NuevaPersona });

            NuevaPersona = string.Empty;
        }

        private void AgregarArticulo(int id)
        {
            ArticuloModel Articulo = lstArticulos.Where(x => x.Id == id).FirstOrDefault();
            lstArticulosNuevos.Add(Articulo);
            TotalVenta += Articulo.Precio;
        }

        private void FiltrarPersona(string textoBuscar)
        {
            lstPersonas.Clear();
            lstOriginalPersonas.Where(x => x.Nombre.ToLower().Contains(textoBuscar.ToLower())).ToList().ForEach(x => lstPersonas.Add(x));

        }

        private void BorrarPersona(int id)
        {

            lstOriginalPersonas.RemoveAll(x => x.Id == id);

        }

        private void VerPersona(int id)
        {
            PersonaActual = lstOriginalPersonas.Where(x => x.Id == id).FirstOrDefault();

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new UsuarioDetalle());

        }

        private void AgregarVenta()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new Venta());
        }

        private void NuevaVenta()
        {
            int consecutivo = PersonaActual.LstVentas != null ? PersonaActual.LstVentas.Max(x => x.Id) + 1 : 1;

            if (PersonaActual.LstVentas == null)
                PersonaActual.LstVentas = new ObservableCollection<VentasModel>();

            PersonaActual.LstVentas.Add(new VentasModel
            {
                Id = consecutivo,
                Descripcion = "Nueva venta",
                Fecha = DateTime.Now,
                Monto = TotalVenta,
                Tipo = 1,
                ArticuloId = lstArticulosNuevos
            });

            lstArticulosNuevos.Clear();
            TotalVenta = 0;

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new UsuarioDetalle());
        }



        private async Task InitClass()
        {

            lstPersonas = await PersonaModel.ObtenerPersonas();

            lstOriginalPersonas = lstPersonas.ToList();

            lstArticulos = await ArticuloModel.ObtenerArticulos();
        }

        private void InitCommands()
        {
            AgregarPersonaCommand = new Command(AgregarPersona);
            BorrarPersonaCommand = new Command<int>(BorrarPersona);
            VerPersonaCommand = new Command<int>(VerPersona);
            AgregarVentaCommand = new Command(AgregarVenta);
            AgregarArticuloCommand = new Command<int>(AgregarArticulo);
            NuevaVentaCommand = new Command(NuevaVenta);
        }

        #endregion


        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

