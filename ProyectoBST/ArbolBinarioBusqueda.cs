using System;
using System.Collections.Generic;

namespace ProyectoBST
{
    public class ArbolBinarioBusqueda
    {
        private Nodo raiz;

        public ArbolBinarioBusqueda()
        {
            raiz = null;
        }

        // INSERTAR
        public void Insertar(int valor)
        {
            raiz = InsertarRecursivo(raiz, valor);
        }

        private Nodo InsertarRecursivo(Nodo actual, int valor)
        {
            if (actual == null)
                return new Nodo(valor);

            if (valor < actual.Valor)
                actual.Izquierdo = InsertarRecursivo(actual.Izquierdo, valor);
            else if (valor > actual.Valor)
                actual.Derecho = InsertarRecursivo(actual.Derecho, valor);
            else
                Console.WriteLine("El valor ya existe en el árbol.");

            return actual;
        }

        // BUSCAR
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(raiz, valor);
        }

        private bool BuscarRecursivo(Nodo actual, int valor)
        {
            if (actual == null)
                return false;

            if (actual.Valor == valor)
                return true;

            if (valor < actual.Valor)
                return BuscarRecursivo(actual.Izquierdo, valor);

            return BuscarRecursivo(actual.Derecho, valor);
        }

        // ELIMINAR
        public void Eliminar(int valor)
        {
            if (!Buscar(valor))
            {
                Console.WriteLine("El valor no existe en el árbol.");
                return;
            }

            raiz = EliminarRecursivo(raiz, valor);
            Console.WriteLine("Valor eliminado correctamente.");
        }

        private Nodo EliminarRecursivo(Nodo actual, int valor)
        {
            if (actual == null)
                return null;

            if (valor < actual.Valor)
            {
                actual.Izquierdo = EliminarRecursivo(actual.Izquierdo, valor);
            }
            else if (valor > actual.Valor)
            {
                actual.Derecho = EliminarRecursivo(actual.Derecho, valor);
            }
            else
            {
                // Caso 1: sin hijos
                if (actual.Izquierdo == null && actual.Derecho == null)
                    return null;

                // Caso 2: un solo hijo
                if (actual.Izquierdo == null)
                    return actual.Derecho;

                if (actual.Derecho == null)
                    return actual.Izquierdo;

                // Caso 3: dos hijos
                Nodo sucesor = ObtenerNodoMinimo(actual.Derecho);
                actual.Valor = sucesor.Valor;
                actual.Derecho = EliminarRecursivo(actual.Derecho, sucesor.Valor);
            }

            return actual;
        }

        // RECORRIDOS
        public List<int> Inorden()
        {
            List<int> resultado = new List<int>();
            InordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void InordenRecursivo(Nodo actual, List<int> resultado)
        {
            if (actual != null)
            {
                InordenRecursivo(actual.Izquierdo, resultado);
                resultado.Add(actual.Valor);
                InordenRecursivo(actual.Derecho, resultado);
            }
        }

        public List<int> Preorden()
        {
            List<int> resultado = new List<int>();
            PreordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void PreordenRecursivo(Nodo actual, List<int> resultado)
        {
            if (actual != null)
            {
                resultado.Add(actual.Valor);
                PreordenRecursivo(actual.Izquierdo, resultado);
                PreordenRecursivo(actual.Derecho, resultado);
            }
        }

        public List<int> Postorden()
        {
            List<int> resultado = new List<int>();
            PostordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void PostordenRecursivo(Nodo actual, List<int> resultado)
        {
            if (actual != null)
            {
                PostordenRecursivo(actual.Izquierdo, resultado);
                PostordenRecursivo(actual.Derecho, resultado);
                resultado.Add(actual.Valor);
            }
        }

        // MÍNIMO
        public int? Minimo()
        {
            if (raiz == null)
                return null;

            return ObtenerNodoMinimo(raiz).Valor;
        }

        private Nodo ObtenerNodoMinimo(Nodo actual)
        {
            while (actual.Izquierdo != null)
                actual = actual.Izquierdo;

            return actual;
        }

        // MÁXIMO
        public int? Maximo()
        {
            if (raiz == null)
                return null;

            Nodo actual = raiz;
            while (actual.Derecho != null)
                actual = actual.Derecho;

            return actual.Valor;
        }

        // ALTURA
        public int Altura()
        {
            return AlturaRecursiva(raiz);
        }

        private int AlturaRecursiva(Nodo actual)
        {
            if (actual == null)
                return -1; // árbol vacío = -1, un solo nodo = 0

            int alturaIzquierda = AlturaRecursiva(actual.Izquierdo);
            int alturaDerecha = AlturaRecursiva(actual.Derecho);

            return Math.Max(alturaIzquierda, alturaDerecha) + 1;
        }

        // LIMPIAR
        public void Limpiar()
        {
            raiz = null;
        }

        // VALIDAR SI ESTÁ VACÍO
        public bool EstaVacio()
        {
            return raiz == null;
        }
    }
}