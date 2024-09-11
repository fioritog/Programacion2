using Cine.Enums;

namespace Cine.Modelos
{
    public class Asientos
    {
        private char _letra;
        private int _numero;
        private TipoAsiento _tipo;
        private bool _ocupado;

        public char Letra  {get { return _letra; }}
        public int Numero {get { return _numero; }}
        public TipoAsiento Tipo {get { return _tipo; }}
        public bool Ocupado { get { return _ocupado; }}
        

        public Asientos(char letra, int numero, TipoAsiento tipo) 
        {
            _letra = letra;
            _numero = numero;
            _tipo = tipo;
        }

        public void CambiarEstado() 
        {
            _ocupado = !_ocupado;
        }
    }
}

