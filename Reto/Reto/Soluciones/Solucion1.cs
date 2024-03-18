using System;

namespace Reto.Solucion1
{
    // Descripción de la solución
    // Vamos a aplicar el principio de responsabilidad única para hacer que la propiedad Contenido sea extensible sin modificar la clase CorreoElectronico.
    // Vamos a hacer que contenido sea un objeto que se pase como parámetro utilizando una interfaz
    // Depende del contenido que se le pase como parametro, ese objeto podria tener diferentes tipos de contenido.
    public interface IContenido
    {
        string ObtenerContenidoComoTexto();
    }

    public class ContenidoTexto : IContenido
    {
        public string Texto { get; set; }

        public ContenidoTexto(string texto)
        {
            Texto = texto;
        }

        public string ObtenerContenidoComoTexto()
            => Texto;
    }

    public interface ICorreoElectronico
    {
        void SetEmisor(String emisor);
        void SetReceptor(String receptor);
        void SetContenido(IContenido contenido);
    }

    public class CorreoElectronico : ICorreoElectronico
    {
        public string Emisor { get; set; }

        public string Receptor { get; set; }

        public string ContenidoEnTexto { get; set; }

        public CorreoElectronico()
        {
        }

        public void SetEmisor(string emisor)
            => Emisor = emisor;

        public void SetReceptor(string receptor)
            => Receptor = receptor;

        public void SetContenido(IContenido contenido)
        {
            ContenidoEnTexto = contenido.ObtenerContenidoComoTexto();
        }
    }
}
