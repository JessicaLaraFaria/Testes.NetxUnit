﻿using System;

namespace Estacionamento.Modelos
{
    public class Veiculo
    {
        //Campos    
        private string placa;
        private string proprietario;
        private TipoVeiculo tipo;
        private string ticket;


        //Construtor
        public Veiculo()
        {

        }

        public Veiculo(string proprietario)
        {
            Proprietario = proprietario;
        }

        //Propriedades   

        public string IdTicket { get; set; }
        public string Ticket { get => ticket; set => ticket = value; }

        public string Placa
        {
            get
            {
                return placa;
            }
            set
            {
                // Checa se o valor possui pelo menos 8 caracteres
                if (value.Length != 8)
                {
                    throw new FormatException(" A placa deve possuir 8 caracteres");
                }
                for (int i = 0; i < 3; i++)
                {
                    //checa se os 3 primeiros caracteres são numeros
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Os 3 primeiros caracteres devem ser letras!");
                    }
                }
                //checa o Hifem
                if (value[3] != '-')
                {
                    throw new FormatException("O 4° caractere deve ser um hífen");
                }
                //checa se os 4 ultimos caracteres são numeros
                for (int i = 4; i < 8; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Do 5º ao 8º caractere deve-se ter um número!");
                    }
                }
                placa = value;

            }
        }
        public string Cor { get; set; }
        public double Largura { get; set; }    
        public double VelocidadeAtual { get; set; }
        public string Modelo { get; set; }        
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }   
        public TipoVeiculo Tipo { get => tipo; set => tipo = value; }
        public string Proprietario 
        {   
            get
            {
                return proprietario;
            } 
            set
            {
                if(value.Length < 3)
                {
                    throw new System.FormatException("Nome do proprietario precisa conter mais de 3 caracteres.");
                }
                proprietario = value;
            }
        }

        //Métodos
        public void Acelerar(int tempoSeg)
        {
            this.VelocidadeAtual += (tempoSeg * 10);
        }

        public void Frear(int tempoSeg)
        {
            this.VelocidadeAtual -= (tempoSeg * 15);
        }

        public void AlterarDados(Veiculo veiculo)
        {
            this.Proprietario = veiculo.Proprietario;
            this.Placa = veiculo.Placa;
            this.Cor = veiculo.Cor;
            this.Modelo = veiculo.Modelo;
        }

        public override string ToString()
        {
            return $"Ficha do Veículo:\n " +
                   $"Tipo do Veículo: {this.Tipo.ToString()}\n " +
                   $"Proprietário: {this.Proprietario}\n " +
                   $"Modelo: {this.Modelo}\n " +
                   $"Cor: {this.Cor}\n " +
                   $"Placa: {this.Placa}\n ";
        }

    }
}
