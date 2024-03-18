namespace Reto.Solucion4
{
    namespace Reto.Ejemplos4
    {
        // Vamos a usar el principio de segregación de interfaces pare definir interfaces más pequeñas con responsabilidades
        // más particulares y separar la responsabilidad Trabajar que la tienen que hacer todos, con las responsabilidades de Descansar y Comer
        // que por ejemplo el robot no tiene que hacerlas.
        public interface ITrabajable
        {
            void Trabajar();
        }

        public interface IDescansable
        {
            void Descansar();
        }

        public interface IComible
        {
            void Comer();
        }

        public class TrabajadorPlanta : ITrabajable, IDescansable, IComible
        {
            public void Trabajar()
            {
                // Implementación de trabajar
            }

            public void Descansar()
            {
                // Implementación de descansar
            }

            public void Comer()
            {
                // Implementación de comer
            }
        }

        public class Desarrollador : ITrabajable, IDescansable, IComible
        {
            public void Trabajar()
            {
                // Implementación de trabajar
            }

            public void Descansar()
            {
                // Implementación de descansar
            }

            public void Comer()
            {
                // Implementación de comer
            }
        }

        public class Robot : ITrabajable
        {
            public void Trabajar()
            {
                // Implementación de trabajar
            }
        }

        public class JefeDespota
        {
            private ITrabajable _trabajador;

            public void ElegirTrabajador(ITrabajable trabajador)
            {
                _trabajador = trabajador;
            }

            public void Mandar()
            {
                _trabajador.Trabajar();
            }
        }
    }
}
}

