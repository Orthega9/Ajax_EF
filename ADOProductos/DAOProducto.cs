using ADOProductos.Clases;
using ADOProductos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOProductos
{
    public class DAOProducto
    {
        public List<ProductoE>ListaProducto()
        {
            using (EntitiesProductos db = new EntitiesProductos())
            {
                List<Producto> ls = db.Producto.Include("Categoria").ToList();
                List<ProductoE> lista = ls.Select(x => new ProductoE()
                {
                    CategoriaId = x.CategoriaId,
                    Descripcion = x.Categoria.Descripcion,
                    id = x.id,
                    IdCategoria = x.Categoria.IdCategoria,
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    PrecioIVA = x.PrecioIVA

                }).ToList();

                return lista;
            }
        }

        public ProductoE Obtener(int id)
        {
            using (EntitiesProductos db = new EntitiesProductos())
            {
                Producto p = db.Producto.Find(id);
                ProductoE pro = new ProductoE();
                pro.id = p.id;
                pro.Nombre = p.Nombre;
                pro.Precio = p.Precio;
                pro.PrecioIVA = p.PrecioIVA;
                pro.CategoriaId = p.CategoriaId;
                return pro;
            }
        }

        public void Agregar(Producto p)
        {
            decimal iva = 0.16M;
            //decimal precioIva=Convert.ToDecimal(p.Precio)* iva;
            using (EntitiesProductos db = new EntitiesProductos())
            {
                Producto pe = new Producto();
                pe.Nombre = p.Nombre;
                pe.Precio = p.Precio;
                pe.PrecioIVA = pe.Precio * iva + pe.Precio;
                pe.CategoriaId = p.CategoriaId;
                db.Producto.Add(pe);
                db.SaveChanges();
            }
        }

        public void Editar(Producto p)
        {
            decimal iva = 0.16M;
            using (EntitiesProductos db = new EntitiesProductos())
            {
                Producto pe = new Producto();
                pe.id = p.id;
                pe.Nombre = p.Nombre;
                pe.Precio = p.Precio;
                pe.PrecioIVA = pe.Precio * iva + pe.Precio;
                pe.CategoriaId = p.CategoriaId;
                db.Entry(pe).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void Eliminar(Producto p)
        {
            using (EntitiesProductos db = new EntitiesProductos())
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<ProductoE>BuscarCategoria(int idCat)
        {
            using (EntitiesProductos db = new EntitiesProductos())
            {
                List<Producto> ls = db.Producto.Include("Categoria").Where(x => x.Categoria.IdCategoria == idCat).ToList();
                List<ProductoE> lista = ls.Select(y => new ProductoE()
                {
                    CategoriaId = y.CategoriaId,
                    Descripcion = y.Categoria.Descripcion,
                    id = y.id,
                    IdCategoria = y.Categoria.IdCategoria,
                    Nombre = y.Nombre,
                    Precio = y.Precio,
                    PrecioIVA = y.PrecioIVA
                }).ToList();

                return lista;
            }
        }

        public List<ProductoE> BuscarNombre(string cadena)
        {
            using (EntitiesProductos db = new EntitiesProductos())
            {
                List<Producto> ls = db.Producto.Include("Categoria").Where(x => x.Nombre == cadena).ToList();
                List<ProductoE> lista = ls.Select(y => new ProductoE()
                {
                    CategoriaId = y.CategoriaId,
                    Descripcion = y.Categoria.Descripcion,
                    id = y.id,
                    IdCategoria = y.Categoria.IdCategoria,
                    Nombre = y.Nombre,
                    Precio = y.Precio,
                    PrecioIVA = y.PrecioIVA
                }).ToList();

                return lista;
            }
        }
    }
}
