namespace ProyectoBST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== ÁRBOL BINARIO DE BÚSQUEDA (BST) =====");
                Console.WriteLine("1. Insertar valor");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Eliminar valor");
                Console.WriteLine("4. Mostrar recorrido Preorden");
                Console.WriteLine("5. Mostrar recorrido Inorden");
                Console.WriteLine("6. Mostrar recorrido Postorden");
                Console.WriteLine("7. Mostrar valor mínimo");
                Console.WriteLine("8. Mostrar valor máximo");
                Console.WriteLine("9. Mostrar altura del árbol");
                Console.WriteLine("10. Limpiar árbol");
                Console.WriteLine("11. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida.");
                    Pausa();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        InsertarValor(arbol);
                        break;

                    case 2:
                        BuscarValor(arbol);
                        break;

                    case 3:
                        EliminarValor(arbol);
                        break;

                    case 4:
                        MostrarRecorrido("Preorden", arbol.Preorden());
                        break;

                    case 5:
                        MostrarRecorrido("Inorden", arbol.Inorden());
                        break;

                    case 6:
                        MostrarRecorrido("Postorden", arbol.Postorden());
                        break;

                    case 7:
                        MostrarMinimo(arbol);
                        break;

                    case 8:
                        MostrarMaximo(arbol);
                        break;

                    case 9:
                        MostrarAltura(arbol);
                        break;

                    case 10:
                        arbol.Limpiar();
                        Console.WriteLine("El árbol ha sido limpiado completamente.");
                        Pausa();
                        break;

                    case 11:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausa();
                        break;
                }

            } while (opcion != 11);
        }

        static void InsertarValor(ArbolBinarioBusqueda arbol)
        {
            Console.Write("Ingrese un valor entero para insertar: ");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                arbol.Insertar(valor);
                Console.WriteLine("Valor insertado correctamente.");
            }
            else
            {
                Console.WriteLine("Entrada inválida. Debe ingresar un número entero.");
            }

            Pausa();
        }

        static void BuscarValor(ArbolBinarioBusqueda arbol)
        {
            Console.Write("Ingrese el valor a buscar: ");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                bool encontrado = arbol.Buscar(valor);
                Console.WriteLine(encontrado
                    ? "El valor sí existe en el árbol."
                    : "El valor no existe en el árbol.");
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }

            Pausa();
        }

        static void EliminarValor(ArbolBinarioBusqueda arbol)
        {
            Console.Write("Ingrese el valor a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                arbol.Eliminar(valor);
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }

            Pausa();
        }

        static void MostrarRecorrido(string nombre, List<int> recorrido)
        {
            Console.WriteLine($"Recorrido {nombre}:");

            if (recorrido.Count == 0)
            {
                Console.WriteLine("El árbol está vacío.");
            }
            else
            {
                Console.WriteLine(string.Join(" - ", recorrido));
            }

            Pausa();
        }

        static void MostrarMinimo(ArbolBinarioBusqueda arbol)
        {
            int? minimo = arbol.Minimo();

            if (minimo == null)
                Console.WriteLine("El árbol está vacío.");
            else
                Console.WriteLine($"El valor mínimo es: {minimo}");

            Pausa();
        }

        static void MostrarMaximo(ArbolBinarioBusqueda arbol)
        {
            int? maximo = arbol.Maximo();

            if (maximo == null)
                Console.WriteLine("El árbol está vacío.");
            else
                Console.WriteLine($"El valor máximo es: {maximo}");

            Pausa();
        }

        static void MostrarAltura(ArbolBinarioBusqueda arbol)
        {
            if (arbol.EstaVacio())
                Console.WriteLine("El árbol está vacío.");
            else
                Console.WriteLine($"La altura del árbol es: {arbol.Altura()}");

            Pausa();
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}