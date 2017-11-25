using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2.Model
{

    public class ArticuloModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public ArticuloModel()
        {

        }


        public static async Task<ObservableCollection<ArticuloModel>> ObtenerArticulos()
        {

            ObservableCollection<ArticuloModel> lstVentas = new ObservableCollection<ArticuloModel>();


            lstVentas.Add(new ArticuloModel { Id = 1, Nombre  = "Articulo 1",Precio= 6000 });
            lstVentas.Add(new ArticuloModel { Id = 2, Nombre  = "Articulo 2",Precio= 5000 });
            lstVentas.Add(new ArticuloModel { Id = 3, Nombre  = "Articulo 3",Precio= 60000 });
            lstVentas.Add(new ArticuloModel { Id = 4, Nombre  = "Articulo 4", Precio = 26000 });
            lstVentas.Add(new ArticuloModel { Id = 5, Nombre  = "Articulo 5", Precio = 896000 });
            lstVentas.Add(new ArticuloModel { Id = 6, Nombre  = "Articulo 6", Precio = 100000 });
            lstVentas.Add(new ArticuloModel { Id = 7, Nombre  = "Articulo 7", Precio = 600500 });
            lstVentas.Add(new ArticuloModel { Id = 8, Nombre  = "Articulo 8", Precio = 96000 });
            lstVentas.Add(new ArticuloModel { Id = 9, Nombre  = "Articulo 9", Precio = 725000 });
            lstVentas.Add(new ArticuloModel { Id = 10,Nombre  = "Articulo 10", Precio = 656000 });
            lstVentas.Add(new ArticuloModel { Id = 11,Nombre  = "Articulo 11", Precio = 266000 });
            lstVentas.Add(new ArticuloModel { Id = 12,Nombre  = "Articulo 12", Precio = 98000 });
            lstVentas.Add(new ArticuloModel { Id = 13,Nombre  = "Articulo 13", Precio = 55000 });
            lstVentas.Add(new ArticuloModel { Id = 14,Nombre  = "Articulo 14", Precio = 66000 });
            lstVentas.Add(new ArticuloModel { Id = 15,Nombre  = "Articulo 15", Precio = 800000 });
            
            return lstVentas;

        }

    }   

 

}
