using ADOProductos.Clases;
using ADOProductos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOProductos
{
    public class DAOCategoria
    {
        public List<CategoriaE> ListaCategoria()
        {
            using (EntitiesProductos db = new EntitiesProductos())
            {
                List<Categoria> ls = db.Categoria.ToList();
                List<CategoriaE> lista = ls.Select(x => new CategoriaE()
                {
                    IdCategoria = x.IdCategoria,
                    Descripcion = x.Descripcion

                }).ToList();

                return lista;
            }
        }
    }
}
