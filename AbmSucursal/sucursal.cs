using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Sucursal
{
    public class sucursal
    {
        public sucursal(string nombre, int codigoPostal, string direccion, Boolean habilitado)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.codigoPostal = codigoPostal;
            this.habilitado = habilitado;
        }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public int codigoPostal { get; set; }
        public Boolean habilitado { get; set; }
    }
}
