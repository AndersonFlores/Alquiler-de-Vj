using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVJ.BL
{
    public class ProductosBL
    {
        Contexto _contexto;
        public List<Producto> ListadeProductos { get; set; }


        public ProductosBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new List<Producto>();
        }

        public List<Producto> ObtenerProductos()
        {

            ListadeProductos = _contexto.Productos
                .Include("Categoria")
                .ToList();

            return ListadeProductos; 
        }

        public void GuardarProducto(Producto producto)
        {
            if (producto.Id == 0)
            {
                _contexto.Productos.Add(producto);
            }
            else
            {
                var productoExistent = _contexto.Productos.Find(producto.Id);

                productoExistent.Descripcion = producto.Descripcion;
                productoExistent.CategoriaId = producto.CategoriaId;
                productoExistent.cantidad = producto.cantidad;
                productoExistent.Precio = producto.Precio;
                productoExistent.Disponible = producto.Disponible;
            }
            _contexto.SaveChanges();

        }

        public void EliminarProducto(int id)
        {
            var producto = _contexto.Productos.Find(id);
            _contexto.Productos.Remove(producto);
            _contexto.SaveChanges();

        }

        public Producto ObtenerProducto(int id)
        {
            var producto = _contexto.Productos
           .Include("Categoria").FirstOrDefault(p => p.Id == id);

            return producto;
        }
    }
}
