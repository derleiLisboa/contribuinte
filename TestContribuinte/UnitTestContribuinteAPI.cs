using ContribuinteApi.Models;
using RA;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestContribuinte {

    /// <summary>
    /// Classe de para Teste da API REST
    /// </summary>
    public class UnitTestContribuinteAPI {

        ///  Alterar para URI de execução da API
        const string URI_API = "https://localhost:44337/api/contribuinte";

        [Fact]
        public void TestIncluirContribuinte() {
            new RestAssured()
                .Given()
                    .Header("Content-Type", "application/json")
                    .Body("{" +
                            "\"cpf\":\"000.000.000-00\"," +
                            "\"nome\":\"Contribuinte Teste\"," +
                            "\"numeroDependentes\":0," +
                            "\"rendaBrutaMensal\":1100}")
                .When()
                    .Post(URI_API)
                .Then()
                    .TestBody("id", x => x.id != null)
                    .TestBody("nome", x => x.nome == "Contribuinte Teste")
                    .TestBody("cpf", x => x.cpf == "000.000.000-00")
                    .TestBody("numeroDependentes", x => x.numeroDependentes == 0)
                    .TestBody("rendaBrutaMensal", x => x.rendaBrutaMensal == 1100)
                    .AssertAll();
        }
    }
}
