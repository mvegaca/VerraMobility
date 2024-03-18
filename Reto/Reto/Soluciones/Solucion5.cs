namespace Reto.Solucion5
{
    namespace Reto.Ejemplos5
    {
        // Vamos a aplicar el Dependency injection definiendo interfaces para abstraer el comportamiento de las puertas y ventanas.
        // La clase House ahora depende de las abstracciones, no de las implementaciones concretas.
        // El sistema de Dependency Injection insertará para las interfaces IDoor y IWindow clases de implementacion o en caso de Testing puede poner objetos Mock.

        public interface IDoor
        {
            string GetColor();
            void OnOpen();
            void OnClose();
        }

        public interface IWindow
        {
            string GetSize();
            void OnOpen();
            void OnClose();
        }

        public class Door : IDoor
        {
            public string GetColor()
            {
                return string.Empty;
            }

            public void OnOpen()
            {
            }

            public void OnClose()
            {
            }
        }

        public class Window : IWindow
        {
            public string GetSize()
            {
                return string.Empty;
            }

            public void OnOpen()
            {
            }

            public void OnClose()
            {
            }
        }

        public class House
        {
            private IDoor _door;
            private IWindow _window;

            public House(IDoor door, IWindow window)
            {
                _door = door;
                _window = window;
            }
        }
    }

}
