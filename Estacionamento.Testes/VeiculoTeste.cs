using System;
using Estacionamento.Modelos;
using Xunit;

namespace Estacionamento.Testes
{
    public class VeiculoTeste: IDisposable //IDisposable conceito de cleanup, limpeza das vari�veis ap�s cada m�todo
    {
        private Veiculo veiculo;
        public VeiculoTeste()
        {
                veiculo = new Veiculo();
        }

        // Padr�o de teste AAA(Arrange, Act, Assert)
        //Arrange � a prepara��o do cen�rio para o teste
        //Act � o m�todo que vai ser testado
        //Assert � o resultado esperado do m�todo testado

        [Fact]
        [Trait("M�todo", "Acelerar")]
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
        [Trait("M�todo", "Frear")]
        public void TesteVeiculoFrear()
        {
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "M�todo ainda n�o implementado.Ignorar.")]
        public void TesteNomeProprietario()
        {

        }

        [Fact]
        public void FichaDadosVeiculo()
        {
            //Arrange
            veiculo.Proprietario = "Jos�";
            veiculo.Placa = "JOS-8493";
            veiculo.Cor = "Cinza";
            veiculo.Modelo = "Palio";
            veiculo.Tipo = TipoVeiculo.Automovel;

            //Act
            string retorno = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Ve�culo:", retorno);
        }

        [Fact]
        public void TesteExcecaoNomeProprietarioVeiculo()
        {
            //Arrange
            string nomeProprietario = "Ad";

            //Assert.Throws pois est� testando a exce��o a ser lan�ada
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

            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
        }

        [Fact]
        public void TesteExcecaoUltimosCaracteresPlaca()
        {
            string placa = "ASD-23E4";

            var mensagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placa
                );

            Assert.Equal("Do 5� ao 8� caractere deve-se ter um n�mero!", mensagem.Message);
        }

        public void Dispose()
        {

        }
    }
}
