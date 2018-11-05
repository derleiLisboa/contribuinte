using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContribuinteApi.Models {

    [Table("contribuinte")]
    public class Contribuinte {

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("nome", TypeName = "varchar(200)")]
        public string Nome { get; set; }

        [Column("numero_dependentes")]
        public int NumeroDependentes { get; set; }

        [Column("renda_bruta_mensal")]
        public decimal RendaBrutaMensal { get; set; }

        [NotMapped]
        private decimal ir;

        [NotMapped]
        public decimal Ir {
            get {
                return ir;
            }
        }

        public void CalcularIR (decimal salarioMinimo) {

            decimal descontoDependentes = ((NumeroDependentes * 5.0m) / 100.0m ) * salarioMinimo;
            decimal rendaLiquida = RendaBrutaMensal - descontoDependentes;
            decimal numeroSalariosMinimos = rendaLiquida / salarioMinimo;

            decimal aliquota = 0m;

            if (numeroSalariosMinimos > 7) {
                aliquota = 27.5m;
            }
            else if (numeroSalariosMinimos > 5) {
                aliquota = 22.5m;
            }
            else if (numeroSalariosMinimos > 4) {
                aliquota = 15;
            }
            else if (numeroSalariosMinimos > 2) {
                aliquota = 7.5m;
            }

            ir = rendaLiquida * (aliquota / 100);
        }
    }
}