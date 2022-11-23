using System;


namespace Estacionamento.Modelos
{
    public class Operador
    {
        private string matricula;
        private string nome;

        public string Matricula { get { return matricula; } set { matricula = value; } }
        public string Nome { get { return nome; } set { nome = value; } }

        public Operador()
        {
            this.Matricula = new Guid().ToString().Substring(0, 8);
        }

        public override string ToString()
        {
            return $"Operador: {this.Nome}\n" +
                   $"Matricula: {this.Matricula}";
        }

    }
}
