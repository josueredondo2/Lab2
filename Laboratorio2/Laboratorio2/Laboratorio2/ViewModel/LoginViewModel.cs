using Laboratorio2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Laboratorio2.View;
using System.Threading.Tasks;

namespace Laboratorio2.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        #region Singleton
        private static LoginViewModel instance = null;

        private LoginViewModel()
        {
            InitCommands();
        }

        public static LoginViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new LoginViewModel();
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

        #region Propiedades
        private string _IdUsuario;

        public string IdUsuario
        {
            get => _IdUsuario;
            set
            {
                _IdUsuario = value;
                OnPropertyChanged("IdUsuario");
            }
        }

        private string _Pass;

        public string Pass
        {
            get => _Pass;
            set
            {
                _Pass = value;
                OnPropertyChanged("Pass");
            }
        }

        private string _Resultado;

        public string Resultado
        {
            get => _Resultado;
            set
            {
                _Resultado = value;
                OnPropertyChanged("Resultado");
            }
        }

        private Color _Color;

        public Color Color
        {
            get => _Color;
            set
            {
                _Color = value;
                OnPropertyChanged("Color");
            }
        }


        #endregion

        #region Metodos


        private void InitCommands()
        {  
            LoginCommand = new Command(Login);
        }

        private void Login()
        {
            
            LoginModel login = LoginModel.ObtenerUsuarios().Result.Where(x => x.Id == IdUsuario && x.Pass == Pass).FirstOrDefault();

            if (login != null)
            {
                NavigationPage navigation = new NavigationPage(new HomePage());

                App.Current.MainPage = new MasterDetailPage
                {
                    Master = new HomeMenu(),
                    Detail = navigation
                };
            }
            else
            {
                Resultado = "Usuario o contraseña incorrecta.";
            }
        }

        public ICommand LoginCommand { get; set; }

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
