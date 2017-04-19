using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace KBits.Exemplos
{
    class Program
    {
        static void Main(string[] args)
        {



            #region interpolação da cadeia de caracteres
            //<inicio>
            // interpolação da cadeia de caracteres no lugar do string.Format
            //Antes
            Console.WriteLine(string.Format("Esta Logado o {0} ",Environment.UserName));
            //C# 6.0
            Console.WriteLine($"Esta Logado o {Environment.UserName} ");

            /*
             * Note que tiramos a chamada para o método Format e o substituímos por um cifrão($).
             *  Fazemos isso para dizer ao C# que estamos fazendo uma interpolação de strings. Dessa forma, ao invés de utilizarmos os placeholders(as chaves) com números,
             *   podemos colocar direto os valores que queremos.
             */

            //<Fim>
            #endregion

            #region Operador nulo condicional
            //<inicio>
            //Operador nulo condicional
            Pessoa variaveNula = null;
            List<Pessoa> pessoasNulas = null;

            //tratamento Antigo para Nulo
            if(variaveNula != null && variaveNula.idade > 0)
                Console.WriteLine("Maior que Zero");
            else
                Console.WriteLine("Menor que Zero ou Nulo");

            //C# 6.0
            if(variaveNula?.idade > 0)
                Console.WriteLine("Maior que Zero");
            else
                Console.WriteLine("Menor que Zero ou Nulo");

            //É possivel tratar a Propria Coleção antes de Adicionar
            pessoasNulas?.Add(variaveNula);

            if(pessoasNulas == null)
                Console.WriteLine("Continua Nulo e não deu pau");
            //<Fim>
            #endregion

            #region Inicializar Dictionary
            //<inicio>
            //Inicializar Dictionary
            Dictionary<string, ConsoleColor> colorMap =
                 new Dictionary<string, ConsoleColor> { { "DeuMerda", ConsoleColor.Red }, { "Informando", ConsoleColor.Yellow }, { "DeBoa", ConsoleColor.White } };

            Console.WriteLine($"Cor {colorMap["DeuMerda"].ToString()}");

            //C# 6.0
            Dictionary<string, ConsoleColor> colorMapNovo =
                  new Dictionary<string, ConsoleColor>
                  {
                      ["DeuMerda"] = ConsoleColor.Red,
                      ["Informando"] = ConsoleColor.Yellow,
                      ["DeBoa"] = ConsoleColor.White
                  };
            //<Fim>

            Console.WriteLine($"Cor {colorMapNovo["DeuMerda"].ToString()}");


            #endregion

            #region Using estático
            //<inicio>
            //Using estático
            string idadeTexto = "28";
            Pessoa pessoa = new Pessoa() ;
            pessoa.idade = Convert.ToInt32(idadeTexto);
            Console.WriteLine($"Idade {pessoa.idade}");

            //Classes que são estaticas permitem agora utilizar static no using (ex: using static System.Convert;)

            //C# 6.0 Ao invés de ficar utilizando o nome da classe toda hora
            pessoa.idade = ToInt32(idadeTexto);
            Console.WriteLine($"Idade {pessoa.idade}");
            //<Fim>
            #endregion

            #region Operador nameof
            //<inicio>
            ContaExmpression conta = new ContaExmpression();
            Console.WriteLine($"Numero {conta.RetornaNomeDaPropriedadeNumero()}");
            //<Fim>
            #endregion


            Console.ReadLine();
        }

        public class Pessoa
        {
            public int idade { get; set; }
            //C# 6.0  inicializar nossas propriedades com um valor padrão
            public int idadeinicializada { get; set; } = 28;
        }

        #region Expression-bodied methods para a definição de métodos simples

        //Quando Queremos Efetuar uma Operação em uma Propriedade.
        public class Conta
        {
            public double Saldo { get; set; }
            public int Numero { get; set; }

            //Incrementar um Numero na Propria Propriedade.
            public int ProximoNumero
            {
                get
                {
                    return this.Numero + 1;
                }
            }

            //Ou Sobrescrever uma Propriedade
            public override string ToString()
            {
                return string.Format("Numero:{0}, saldo:{1}", Numero.ToString(),Saldo.ToString());
            }
        }

        //c# 6.0
        public class ContaExmpression
        {
            public double Saldo { get; set; }
            public int Numero { get; set; }

            public int ProximoNumero => this.Numero + 1;

            //Para simplificar a escrita desse tipo de método, agora podemos defini-lo da seguinte forma
            public override string ToString() => $"Numero:{this.Numero}, Saldo:{this.Saldo}";


            //C# 6.0 Operador nameof 
            public string RetornaNomeDaPropriedadeNumero()
            {
                return nameof(this.Numero); //retorna "Numero"
            }

        }

       

        //C#6.0 

        /* Como é possível observar, a declaração da propriedade TotalItem foi feita em uma única linha: 
         * este novo recurso dispensa o uso das palavras chaves “get” e “return”, além dos caracteres (chaves) 
         * que marcam o início e o fim de um bloco de instruções.
        */
        public class ItemPedido
        {
            public string CodigoBarras { get; set; }

            public int Quantidade { get; set; }

            public double Preco { get; set; }

            /* Forma Antes da Versão 6.0
            public double TotalItem
            {
                get
                {
                    return Quantidade * Preco;
                }
            }
            */

        public double TotalItem => Quantidade * Preco;
        }

        public class Cidade
        {
            public string Nome { get; set; }
            public string Estado { get; set; }

            //o método ToString foi modificado para que se demonstrasse a utilização de uma Expression-bodied Function.
            public override string ToString() => this.Nome + " - " + this.Estado;
        }

        #endregion

        #region Auto-Property Initializers
        //C# 6.0 
        //É possivel inicialiar propriedades de forma mais rapida.
        public class AutoProperty
        {
            public enum TipoLog
            {
                Informacao,
                Alerta,
                Erro
            }

            public class MensagemLog
            {
                public DateTime Data { get; } = DateTime.Now;
                public TipoLog Tipo { get; set; } = TipoLog.Informacao;
                public string Mensagem { get; set; }
            }
        }
        #endregion


    }
}
