using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVJ.BL
{
    public class Producto
    {

        public Producto()
        {
            Disponible = true;
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int cantidad { get; set; }
        public int Precio { get; set; }
        public bool Disponible { get; set; }
    }
}
