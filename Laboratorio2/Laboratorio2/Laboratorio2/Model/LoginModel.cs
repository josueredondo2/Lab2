using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratorio2.Model
{
    public class LoginModel
    {
        public string Id { get; set; }

        public string Pass { get; set; }

        public LoginModel()
        {
            
        }

        public static async Task<List<LoginModel>> ObtenerUsuarios()
        {

            List<LoginModel> lstUsuarios = new List<LoginModel>();


            lstUsuarios.Add(new LoginModel { Id = "1", Pass = "123" });
            lstUsuarios.Add(new LoginModel { Id = "2", Pass = "123" });
            lstUsuarios.Add(new LoginModel { Id = "3", Pass = "123" });
            lstUsuarios.Add(new LoginModel { Id = "4", Pass = "123" });
            lstUsuarios.Add(new LoginModel { Id = "5", Pass = "123" });
            lstUsuarios.Add(new LoginModel { Id = "6", Pass = "123" });
            lstUsuarios.Add(new LoginModel { Id = "7", Pass = "123" });
            lstUsuarios.Add(new LoginModel { Id = "8", Pass = "123" });
            lstUsuarios.Add(new LoginModel { Id = "9", Pass = "123" });
            lstUsuarios.Add(new LoginModel { Id = "10",Pass = "123" });


            return lstUsuarios;

        }


    }
}
