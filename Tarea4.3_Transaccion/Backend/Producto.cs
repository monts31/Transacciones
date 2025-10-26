using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea4._3_Transaccion.Backend
{
    internal class Producto
    {
        private int id;
        private string nombre;
        private string codigo;
        private string descripcion;
        private int stock;
        private decimal precio;
        private string estado;
        private DateTime fechaActualizacion;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public DateTime FechaActualizacion
        {
            get { return fechaActualizacion; }
            set { fechaActualizacion = value; }
        }
    }
}
