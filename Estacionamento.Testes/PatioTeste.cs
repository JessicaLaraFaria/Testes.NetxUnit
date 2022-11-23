
using System;
using Estacionamento.Modelos;
using Xunit;

namespace Estacionamento.Testes
{
    public class PatioTeste: IDisposable
    {
        private Patio patio;
        private Veiculo veiculo;
        private Operador operador;

        public PatioTeste()
        {
            patio = new Patio();
            veiculo = new Veiculo();
            operador = new Operador();
            operador.Nome = "Marisa";
            patio.OperadorPatio = operador;
        }

        [Fact]
        public void TesteFaturamento()
        {
            //Arrange            
            veiculo.Proprietario = "José";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Palio";
            veiculo.Placa = "jos-1234";

            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = patio.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Maria", "MAR-1213", "Rosa", "Gol")]
        [InlineData("Pedro", "PED-4321", "Preto", "Palio")]
        [InlineData("Joao", "JOA-2314", "Verde", "Civic")]

        public void TesteFaturamentoVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = patio.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Mariana", "GIO-1213", "Rosa", "Gol")]
        public void LocalizaVeiculo(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            patio.RegistrarEntradaVeiculo(veiculo);

            //Act
            var localiza = patio.LocalizaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("Ticket Estacionamento", localiza.Ticket);
        }

        [Fact]
        public void AlteraDadosVeiculoPatio()
        {
            veiculo.Proprietario = "Joaquim";
            veiculo.Placa = "AEI-3456";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Palio";

            patio.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Joaquim";
            veiculoAlterado.Placa = "AEI-3456";
            veiculoAlterado.Cor = "Verde"; //Alterado
            veiculoAlterado.Modelo = "Palio";

            //Act
            Veiculo alterado = patio.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {

        }
    }
}
