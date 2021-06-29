using Categorias_Negociações.Model;
using System;
using System.Collections.Generic;
using static Categoria_Negociações.Enum.Enum;

namespace Categorias_Negociações
{
    class Valida_Categorias
    {
        private const string DataReferencia = "11/12/2020";
        private const int NumeroNegociacoes =  4;

        static void Main(string[] args)
        {
            try
            {

                Categorias_Negociacoes Categorias_Negociacoes = new Categorias_Negociacoes();
                Dados_Negociacoes Dados_Negociacoes = new Dados_Negociacoes();


                Categorias_Negociacoes.DataReferencia = Convert.ToDateTime(DataReferencia);
                Categorias_Negociacoes.NumeroNegociacoes = NumeroNegociacoes;


                Categorias_Negociacoes.Dados_Negociacoes.Add(new Dados_Negociacoes
                {
                    ValorNegociacao = 2000000,
                    SetorNegociacao = "Privado",
                    DataNextPagtoPendente = Convert.ToDateTime("29/12/2025")
                });

                Categorias_Negociacoes.Dados_Negociacoes.Add(new Dados_Negociacoes
                {
                    ValorNegociacao = 400000,
                    SetorNegociacao = "Público",
                    DataNextPagtoPendente = Convert.ToDateTime("01/07/2020")
                });

                Categorias_Negociacoes.Dados_Negociacoes.Add(new Dados_Negociacoes
                {
                    ValorNegociacao = 5000000,
                    SetorNegociacao = "Público",
                    DataNextPagtoPendente = Convert.ToDateTime("01/02/2024")
                });

                Categorias_Negociacoes.Dados_Negociacoes.Add(new Dados_Negociacoes
                {
                    ValorNegociacao = 3000000,
                    SetorNegociacao = "Público",
                    DataNextPagtoPendente = Convert.ToDateTime("26/10/2023")
                });

                List<string> retorno = Prepara_Retornos(Categorias_Negociacoes);

                foreach (var item in retorno)
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao processar dados: '{e}'");
                throw ;
            }          

           
        }

        public static List<string> Prepara_Retornos(Categorias_Negociacoes Categorias_Negociacoes) {

            List<string> RetPrep = new List<string>();

            foreach (var item in Categorias_Negociacoes.Dados_Negociacoes)
            {
                if (item.DataNextPagtoPendente < DateTime.Now)
                {
                    RetPrep.Add(EnumRetCategorias.EXPIRADO.ToString());
                }
                else if (item.DataNextPagtoPendente > DateTime.Now.AddYears(3))
                {
                    RetPrep.Add(EnumRetCategorias.ALTO_RISCO.ToString());
                }
                else
                {
                    RetPrep.Add(EnumRetCategorias.RISCO_MEDIO.ToString());
                }
            }

            return RetPrep;

        }
    }
}
