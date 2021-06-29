using System;
using System.Collections.Generic;
using System.Text;

namespace Categorias_Negociações.Model
{
    public class Categorias_Negociacoes
    {      
        public Categorias_Negociacoes()
        {
            Dados_Negociacoes = new List<Dados_Negociacoes>();
        }

        public int NumeroNegociacoes { get; set; }
        public DateTime DataReferencia { get; set; }
        public List<Dados_Negociacoes> Dados_Negociacoes { get; set; }
    }
}
