using System;
using Estacionamento.Modelos;
using Xunit;

namespace Estacionamento.Testes
{
    public class VeiculoTeste: IDisposable //IDisposable conceito de cleanup, limpeza das variáveis após cada método
    {
        private Veiculo veiculo;
        public VeiculoTeste()
        {
                veiculo = new Veiculo();
        }

        // Padrão de teste AAA(Arrange, Act, Assert)
        //Arrange é a preparação do cenário para o teste
        //Act é o método que vai ser testado
        //Assert é o resultado esperado do método testado

        [Fact]
        [Trait("Método", "Acelerar")]
        public void TesteVeiculoAcelerar()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Método", "Frear")]
        public void TesteVeiculoFrear()
        {
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Método ainda não implementado.Ignorar.")]
        public void TesteNomeProprietario()
        {

        }

        [Fact]
        public void FichaDadosVeiculo()
        {
            //Arrange
            veiculo.Proprietario = "José";
            veiculo.Placa = "JOS-8493";
            veiculo.Cor = "Cinza";
            veiculo.Modelo = "Palio";
            veiculo.Tipo = TipoVeiculo.Automovel;

            //Act
            string retorno = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", retorno);
        }

        [Fact]
        public void TesteExcecaoNomeProprietarioVeiculo()
        {
            //Arrange
            string nomeProprietario = "Ad";

            //Assert.Throws pois está testando a exceção a ser lançada
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
                );
        }

        [Fact]
        public void TesteExcecaoHIfenPlaca()
        {
            //Arrange
            string placa = "AEIO1234";

            //Act
            var mensagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placa
                );

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        [Fact]
        public void TesteExcecaoUltimosCaracteresPlaca()
        {
            string placa = "ASD-23E4";

            var mensagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placa
                );

            Assert.Equal("Do 5º ao 8º caractere deve-se ter um número!", mensagem.Message);
        }

        public void Dispose()
        {

        }
    }
}
