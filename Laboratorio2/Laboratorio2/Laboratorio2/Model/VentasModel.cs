using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Laboratorio2.Model
{
    public class VentasModel
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public double Monto { get; set; }

        public string Descripcion { get; set; }

        public int Tipo { get; set; }

        public ObservableCollection<ArticuloModel> ArticuloId { get; set; }

    }
}
