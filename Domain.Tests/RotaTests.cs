using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System;
using Domain.Entities;

namespace Domain.Testes
{
    namespace Domain.Tests
    {
        [TestFixture]
        public class RotaTests
        {
            [Test]
            public void Rota_Criar_ComOrigemVazia_DeveLancarArgumentException()
            { // Arrange & Act & Assert
                var ex = Assert.Throws<ArgumentException>(() => new Rota("", "Destino", 10));
                Assert.That(ex.Message, Is.EqualTo("Origem deve ser preenchida"));
            }

            [Test]
            public void Rota_Criar_ComDestinoVazio_DeveLancarArgumentException()
            {
                // Arrange & Act & Assert

                var ex = Assert.Throws<ArgumentException>(() => new Rota("Origem", "", 10));
                Assert.That(ex.Message, Is.EqualTo("Destino deve ser preenchida"));
            }
            [Test]
            public void Rota_Criar_ComValorZero_DeveLancarArgumentException()
            {
                // Arrange & Act & Assert
                var ex = Assert.Throws<ArgumentException>(() => new Rota("Origem", "Destino", 0));
                Assert.That(ex.Message, Is.EqualTo("Valor deve ser maior que 0"));
            }
            [Test]
            public void Rota_Criar_ComOrigemIgualADestino_DeveLancarArgumentOutOfRangeException()
            {
                // Arrange & Act & Assert
                var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Rota("Origem", "Origem", 10));
                Assert.That(ex.ParamName, Is.EqualTo("Origem e Destino n podem ser os mesmos"));
            }
            [Test]
            public void Rota_Criar_Valido_DeveAtribuirPropriedadesCorretamente()
            {
                // Act
                var rota = new Rota("Origem", "Destino", 10);
                // Assert
                Assert.AreEqual("Origem", rota.Origem);
                Assert.AreEqual("Destino", rota.Destino);
                Assert.AreEqual((uint)10, rota.Valor);
            }
            [Test]
            public void AtualizarRota_ComOrigemVazia_DeveLancarArgumentException()
            {
                // Arrange 
                var rota = new Rota("Origem", "Destino", 10);
                // Act & Assert
                var ex = Assert.Throws<ArgumentException>(() => rota.AtualizarRota("", "NovoDestino", 20));
                Assert.That(ex.Message, Is.EqualTo("Origem deve ser preenchida"));
            }
            [Test]
            public void AtualizarRota_ComDestinoVazio_DeveLancarArgumentException()
            {
                // Arrange
                var rota = new Rota("Origem", "Destino", 10);
                // Act & Assert
                var ex = Assert.Throws<ArgumentException>(() => rota.AtualizarRota("NovaOrigem", "", 20));
                Assert.That(ex.Message, Is.EqualTo("Destino deve ser preenchida"));
            }
            [Test]
            public void AtualizarRota_ComValorZero_DeveLancarArgumentException()
            {
                // Arrange
                var rota = new Rota("Origem", "Destino", 10);
                // Act & Assert
                var ex = Assert.Throws<ArgumentException>(() => rota.AtualizarRota("NovaOrigem", "NovoDestino", 0));
                Assert.That(ex.Message, Is.EqualTo("Valor deve ser maior que 0"));
            }
            [Test]
            public void AtualizarRota_ComOrigemIgualADestino_DeveLancarArgumentOutOfRangeException()
            {
                // Arrange
                var rota = new Rota("Origem", "Destino", 10);
                // Act & Assert
                var ex = Assert.Throws<ArgumentOutOfRangeException>(() => rota.AtualizarRota("NovaOrigem", "NovaOrigem", 20));
                Assert.That(ex.ParamName, Is.EqualTo("Origem e Destino n podem ser os mesmos"));
            }
            [Test]
            public void AtualizarRota_Valido_DeveAtualizarPropriedadesCorretamente()
            {
                // Arrange
                var rota = new Rota("Origem", "Destino", 10);
                // Act
                rota.AtualizarRota("NovaOrigem", "NovoDestino", 20);
                // Assert
                Assert.AreEqual("NovaOrigem", rota.Origem);
                Assert.AreEqual("NovoDestino", rota.Destino);
                Assert.AreEqual((uint)20, rota.Valor);
            }
        }
    }
}
