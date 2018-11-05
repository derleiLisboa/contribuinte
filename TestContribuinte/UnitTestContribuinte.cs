using ContribuinteApi.Models;
using System;
using Xunit;

namespace TestContribuinte {
    /// <summary>
    /// Classe para testes unitarios do Contribuinte
    /// </summary>
    public class UnitTestContribuinte {

        [Fact]
        public void TestCalculoIRRendaLiquidaMaiorQueSeteSalarios() {
            Contribuinte contribuinte = new Contribuinte {
                NumeroDependentes = 0,
                RendaBrutaMensal = 1600
            };

            contribuinte.CalcularIR(200);

            Assert.Equal(440m, contribuinte.Ir);
        }

        [Fact]
        public void TestCalculoIRRendaLiquidaMaiorQueSeteSalariosComDependentes() {
            Contribuinte contribuinte = new Contribuinte {
                NumeroDependentes = 2,
                RendaBrutaMensal = 1600
            };

            contribuinte.CalcularIR(200);

            Assert.Equal(434.50m, contribuinte.Ir);
        }

        [Fact]
        public void TestCalculoIRRendaLiquidaEntreCincoESeteSalarios() {
            Contribuinte contribuinte = new Contribuinte {
                NumeroDependentes = 0,
                RendaBrutaMensal = 1200
            };

            contribuinte.CalcularIR(200);

            Assert.Equal(270m, contribuinte.Ir);
        }

        [Fact]
        public void TestCalculoIRRendaLiquidaEntreCincoESeteSalariosComDependentes() {
            Contribuinte contribuinte = new Contribuinte {
                NumeroDependentes = 2,
                RendaBrutaMensal = 1200
            };

            contribuinte.CalcularIR(200);

            Assert.Equal(265.50m, contribuinte.Ir);
        }

        [Fact]
        public void TestCalculoIRRendaLiquidaEntreQuatroECincoSalarios() {
            Contribuinte contribuinte = new Contribuinte {
                NumeroDependentes = 0,
                RendaBrutaMensal = 1000
            };

            contribuinte.CalcularIR(200);

            Assert.Equal(150m, contribuinte.Ir);
        }

        [Fact]
        public void TestCalculoIRRendaLiquidaEntreQuatroECincoSalariosComDependentes() {
            Contribuinte contribuinte = new Contribuinte {
                NumeroDependentes = 2,
                RendaBrutaMensal = 1000
            };

            contribuinte.CalcularIR(200);

            Assert.Equal(147m, contribuinte.Ir);
        }

        [Fact]
        public void TestCalculoIRRendaLiquidaEntreDoisEQuatroSalarios() {
            Contribuinte contribuinte = new Contribuinte {
                NumeroDependentes = 0,
                RendaBrutaMensal = 800
            };

            contribuinte.CalcularIR(200);

            Assert.Equal(60m, contribuinte.Ir);
        }

        [Fact]
        public void TestCalculoIRRendaLiquidaEntreDoisEQuatroSalariosComDependentes() {
            Contribuinte contribuinte = new Contribuinte {
                NumeroDependentes = 2,
                RendaBrutaMensal = 800
            };

            contribuinte.CalcularIR(200);

            Assert.Equal(58.5m, contribuinte.Ir);
        }

        [Fact]
        public void TestCalculoIRRendaLiquidaMenorQueDoisSalarios() {
            Contribuinte contribuinte = new Contribuinte {
                NumeroDependentes = 0,
                RendaBrutaMensal = 400
            };

            contribuinte.CalcularIR(200);

            Assert.Equal(0, contribuinte.Ir);
        }

        [Fact]
        public void TestCalculoIRRendaLiquidaMenorQueDoisSalariosComDependentes() {
            Contribuinte contribuinte = new Contribuinte {
                NumeroDependentes = 2,
                RendaBrutaMensal = 400
            };

            contribuinte.CalcularIR(200);

            Assert.Equal(0, contribuinte.Ir);
        }
    }
}
