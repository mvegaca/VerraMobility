namespace Reto.Solucion2
{
    // Descripción de la solución
    // Vamos a aplicar el principio abierto / cerrado haciendo que el sistema sea abierto para la extensión y cerrado para la modificación.
    // Dando la responsabilidad de Dibujar() a las formas, el sistema es abierto para añadir nuevas formas como Cuadrado
    // y de añadir nuevos métodos como Borrar o Editar.
    // He hecho que Forma sea una clase báse en lugar de una interfaz para que se puedan definir implementaciones base.
    public abstract class Forma
    {
        public virtual void Dibujar()
        {
            // Implementación base para dibujar.
        }

        // Tambien sería posible definir el método abstract si no queremos tener una implentacion base
        // public abstract void Dibujar();

        public virtual void Borrar()
        {
            // Implementación base para borrar.
        }

        public virtual void Editar()
        {
            // Implementación base para editar.
        }
    }
    public class Rectangulo : Forma
    {
        public override void Dibujar()
        {
            // dibuja un rectangulo
            base.Dibujar();
        }

        public override void Borrar()
        {
            // borra un rectangulo
            base.Borrar();
        }

        public override void Editar()
        {
            //edita un rectangulo
            base.Editar();
        }
    }    

    public class Circulo : Forma
    {
        public override void Dibujar()
        {
            // dibuja un circulo
            base.Dibujar();
        }

        public override void Borrar()
        {
            // borra un circulo
            base.Borrar();
        }

        public override void Editar()
        {
            // edita un circulo
            base.Editar();
        }
    }

    public class Cuadrado : Forma
    {
        public override void Dibujar()
        {
            // dibuja un cuadrado
            base.Dibujar();
        }

        public override void Borrar()
        {
            // borra un cuadrado
            base.Borrar();
        }

        public override void Editar()
        {
            // edita un cuadrado
            base.Editar();
        }
    }

    public class EditorGrafico
    {
        public void DibujarForma(Forma forma)
            => forma.Dibujar();

        public void BorrarForma(Forma forma)
            => forma.Borrar();

        public void EditarForma(Forma forma)
            => forma.Editar();
    }
}
