using System;

class VentasEmpresa
{
    static void Main()
    {
       
        int productos = 5;
        int vendedores = 4;

        // Crear un arreglo bidimensional para almacenar las ventas de cada vendedor por producto
        decimal[,] ventas = new decimal[productos, vendedores];

        // Ingresamos los datos simulados para las ventas del mes anterior
        Console.WriteLine("Ingrese las ventas del mes anterior. Formato: Número de Vendedor (1-4), Número de Producto (1-5), Ventas en dólares.");
        string continuar = "si";

        while (continuar.ToLower() == "si")
        {
            int vendedor = -1;
            int producto = -1;
            decimal valorVenta = -1;

            // Leer el número del vendedor con validación
            while (true)
            {
                Console.Write("Ingrese el número del vendedor (1-4): ");
                if (int.TryParse(Console.ReadLine(), out vendedor) && vendedor >= 1 && vendedor <= 4)
                {
                    vendedor--; // Restamos 1 para convertir a índice del arreglo
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. El número del vendedor debe ser entre 1 y 4.");
                }
            }

            // Leer el número del producto con validación
            while (true)
            {
                Console.Write("Ingrese el número del producto (1-5): ");
                if (int.TryParse(Console.ReadLine(), out producto) && producto >= 1 && producto <= 5)
                {
                    producto--; 
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. El número del producto debe ser entre 1 y 5.");
                }
            }

            // Leer el valor total de las ventas con validación
            while (true)
            {
                Console.Write("Ingrese el valor de las ventas del producto: ");
                if (decimal.TryParse(Console.ReadLine(), out valorVenta) && valorVenta >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. El valor de las ventas debe ser un número positivo.");
                }
            }

            // Almacenar las ventas en la matriz
            ventas[producto, vendedor] += valorVenta;

            
            Console.Write("¿Desea ingresar otra venta? (si/no): ");
            continuar = Console.ReadLine();
        }

        
        Console.WriteLine("\nResumen de ventas por producto y vendedor:\n");

     
        Console.Write("Producto\t");
        for (int v = 0; v < vendedores; v++)
        {
            Console.Write($"Vendedor {v + 1}\t");
        }
        Console.WriteLine("Total Producto");

      
        decimal[] totalVendedores = new decimal[vendedores];
        decimal totalGeneral = 0;

       
        for (int p = 0; p < productos; p++)
        {
            decimal totalProducto = 0;
            Console.Write($"Producto {p + 1}\t");

            for (int v = 0; v < vendedores; v++)
            {
                Console.Write($"{ventas[p, v]}\t\t");
                totalProducto += ventas[p, v]; // Sumar las ventas del producto actual
                totalVendedores[v] += ventas[p, v]; // Sumar las ventas por vendedor
            }

            Console.WriteLine($"{totalProducto}"); // Imprimir total por producto
            totalGeneral += totalProducto; // Sumar al total general
        }

        
        Console.Write("Total Vendedor\t");
        for (int v = 0; v < vendedores; v++)
        {
            Console.Write($"{totalVendedores[v]}\t\t");
        }

        
        Console.WriteLine($"\nTotal General de Ventas: {totalGeneral}");
    }
}
