using ADOProductos;
using ADOProductos.Clases;
using ADOProductos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProductosEFAjax.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListaProducto()
        {
            try
            {
                List<ProductoE> lista = new DAOProducto().ListaProducto();

                return Json(new { r = "ok", listaP = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ListaCategoria()
        {
            try
            {
                List<CategoriaE> lista = new DAOCategoria().ListaCategoria();

                return Json(new { r = "ok", listaC = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerProducto(int id)
        {
            try
            {
                ProductoE p = new DAOProducto().Obtener(id);

                return Json(new { entProducto = p}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Agregar(Producto p)
        {
            try
            {
                new DAOProducto().Agregar(p);

                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Editar(Producto p)
        {
            try
            {
                new DAOProducto().Editar(p);

                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Eliminar(Producto p)
        {
            try
            {
                new DAOProducto().Eliminar(p);

                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BuscarCategoria(int id)
        {
            try
            {
                List<ProductoE> lista = new List<ProductoE>();
                using (EntitiesProductos db = new EntitiesProductos())
                {
                    if (id==0)
                    {
                        lista = new DAOProducto().ListaProducto();
                    }
                    else
                     lista = new DAOProducto().BuscarCategoria(id);

                    return Json(new { r = "ok", listaB = lista }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BuscarNombre(string id)
        {
            try
            {
                List<ProductoE> lista = new List<ProductoE>();
                ProductoE p = new ProductoE();
                using (EntitiesProductos db = new EntitiesProductos())
                {
                    if (id == null)
                    {
                        lista = new DAOProducto().ListaProducto();
                    }
                    else
                        lista = new DAOProducto().BuscarNombre(id);

                    return Json(new { r = "ok", listaB = lista }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}