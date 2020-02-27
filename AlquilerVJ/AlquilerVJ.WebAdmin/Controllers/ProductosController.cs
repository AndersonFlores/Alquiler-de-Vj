using AlquilerVJ.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquilerVJ.WebAdmin.Controllers
{
    public class ProductosController : Controller
    {
        ProductosBL _ProductosBL;
        CategoriaBL _Categoria;
        public ProductosController()
        {
            _ProductosBL = new ProductosBL();
            _Categoria = new CategoriaBL();
        }

        // GET: Productos
        public ActionResult Index()
        {
            var ListadeProductos = _ProductosBL.ObtenerProductos();

            return View(ListadeProductos);
        }



        public ActionResult Crear()
        {
            var NuevoProducto = new Producto();
            var categorias = _Categoria.ObtenerCategoria();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(NuevoProducto);
        }



        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            _ProductosBL.GuardarProducto(producto);
            return RedirectToAction("Index");
        }


        public ActionResult Editar(int id)
        {
            var producto = _ProductosBL.ObtenerProducto(id);
                var categoria = _Categoria.ObtenerCategoria();

            ViewBag.CategoriaId = new SelectList(categoria, "Id", "Descripcion", producto.CategoriaId);

            return View(producto);
        }


        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            _ProductosBL.GuardarProducto(producto);
            return RedirectToAction("Index");
        }


        public ActionResult Detalles(int id)
        {
            var producto = _ProductosBL.ObtenerProducto(id);
            return View(producto);
        }


        public ActionResult Eliminar(int id)
        {
            var producto = _ProductosBL.ObtenerProducto(id);
            return View(producto);
        }



        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _ProductosBL.EliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }
    }
}