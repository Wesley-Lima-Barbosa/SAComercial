using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ProjetoLOJA.Models
{
    class CompraProdutos
    {
        public long idpedido { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public long Quantidade { get; set; }

        public void AdicionarProduto(string produtoid, long idpedido, long quanti)
        {
            ProjetoMercado2Entities banco = new ProjetoMercado2Entities();
            Produto produto = banco.Produtos.FirstOrDefault(x => x.Codigo == produtoid);
            ItensPedido itensPedido = new ItensPedido();
            

            itensPedido.Produto = produto.ID;
            itensPedido.Códigopedido = idpedido;
            itensPedido.Quantidade = quanti;
            itensPedido.Valor = produto.Preço;
            banco.ItensPedidos.Add(itensPedido);
            banco.SaveChanges();
            Nome = produto.Nome;
            Preco = produto.Preço;
            Quantidade = itensPedido.Quantidade;
            
        }
    }
}
