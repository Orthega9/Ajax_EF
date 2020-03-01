using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOProductos.Clases
{
    public class ProductoE
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> PrecioIVA { get; set; }
        public Nullable<int> CategoriaId { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
    }
}
