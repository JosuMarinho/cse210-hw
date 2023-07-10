using System;
using System.Collections.Generic;

namespace GestionInventarios
{
    // Definición de la clase Producto
    class Producto
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }

    // Definición de la clase Inventario
    class Inventario
    {
        public List<Producto> productos;  // Cambio de visibilidad a public

        public Inventario()
        {
            productos = new List<Producto>();
        }

        // Agregar un producto al inventario
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        // Mostrar todos los productos en el inventario
        public void MostrarInventario()
        {
            Console.WriteLine("Inventario:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Cantidad: {producto.Cantidad}, Precio: {producto.Precio}");
            }
        }
    }

    // Definición de la clase Compras
    class Compras
    {
        private Inventario inventario;

        public Compras(Inventario inventario)
        {
            this.inventario = inventario;
        }

        // Realizar una compra de productos
        public void RealizarCompra(string nombreProducto, int cantidad)
        {
            // Verificar si el producto existe en el inventario
            Producto producto = inventario.productos.Find(p => p.Nombre == nombreProducto);
            if (producto != null)
            {
                // Verificar si hay suficiente cantidad en stock
                if (producto.Cantidad >= cantidad)
                {
                    producto.Cantidad -= cantidad;
                    Console.WriteLine($"Compra realizada: {cantidad} {nombreProducto}(s) comprado(s).");
                }
                else
                {
                    Console.WriteLine("No hay suficiente stock disponible.");
                }
            }
            else
            {
                Console.WriteLine("El producto no existe en el inventario.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();

            // Agregar productos al inventario
            inventario.AgregarProducto(new Producto { Nombre = "Producto 1", Cantidad = 10, Precio = 9.99 });
            inventario.AgregarProducto(new Producto { Nombre = "Producto 2", Cantidad = 5, Precio = 19.99 });
            inventario.AgregarProducto(new Producto { Nombre = "Producto 3", Cantidad = 3, Precio = 14.99 });

            // Mostrar el inventario
            inventario.MostrarInventario();

            // Realizar una compra
            Compras compras = new Compras(inventario);
            compras.RealizarCompra("Producto 1", 2);

            // Mostrar el inventario actualizado después de la compra
            inventario.MostrarInventario();

            Console.ReadLine();
        }
    }
}
