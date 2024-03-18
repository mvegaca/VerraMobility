using System;

namespace Reto.Solucion3
{
    // Vamos a aplicar el principio de sustitución de Liskov.
    // Los objetos de una clase base deben poder ser reemplazados con objetos de una clase derivada sin afectar el funcionamiento del código.
    // Cuadrado no puede sobreescribir las propuedades Alto y Ancho haciendo que Ancho cambie el Alto y Alto cambie el Ancho.
    // Esto no es válido porque esa regla no aplica para un rectángulo.
    // En este caso voy a separar las implementaciones de Rectángulo y Cuadrado.
    public class Rectangulo
    {
        public virtual int Alto { get; set; }
        public virtual int Ancho { get; set; }

        public int GetArea()
        {
            return Alto * Ancho;
        }
    }

    public class Cuadrado
    {
        private int _lado;

        public int Lado
        {
            get { return _lado; }
            set { _lado = value; }
        }

        public int GetArea()
        {
            return _lado * _lado;
        }
    }

    public class Prueba
    {
        private static Rectangulo GetNewRectangulo()
        {
            return new Rectangulo();
        }

        public static void Main()
        {
            var r = GetNewRectangulo();
            r.Alto = 2;
            r.Ancho = 3;

            Console.WriteLine(r.GetArea());
        }
    }
}
