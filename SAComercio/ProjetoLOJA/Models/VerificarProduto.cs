using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLOJA.Models
{
    class VerificarProduto
    {
        public bool ProdutoExiste(string id)
        {   
            ProjetoMercado2Entities banco = new ProjetoMercado2Entities();
            Produto produto = banco.Produtos.FirstOrDefault(x => x.Codigo == id);
            if (produto == null || produto.Desativado == true )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
