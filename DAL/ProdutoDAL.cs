using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ProdutoDAL : SqlHelper
    {

        public bool adicionar(SqlConnection con, Produto objProd)
        {
            string inserirProd = "INSERT into Produto (nome_prod, categoria, " +
            "preco,medida, quant) VALUES ('" + objProd.NomeProd + "', '" + objProd.Categoria +
            "','" + objProd.Preco + "','" + objProd.Medida + "','" + objProd.Quant + "')";
            try
            {
                executarComando(inserirProd, con);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool alterar(SqlConnection con, Produto objProd)
        {
            string alterarProduto = " UPDATE produto SET " +
                "nome_prod ='" + objProd.NomeProd + "'," +
                "categoria ='" +objProd.Categoria + "'," +
                "preco ='" +objProd.Preco + "'," +
                "medida ='" + objProd.Medida + "'," +
                "quant ='" + objProd.Quant + "'" +
                "WHERE codbar_prod = " + objProd.Codbar_prod +" " ; 

            try
            {
                executarComando(alterarProduto, con);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto pesquisarProd(SqlConnection con, Produto prod)
        {
            string buscarProdID = "select * from produto where codbar_prod=" +
            prod.Codbar_prod;
            try
            {
                SqlDataReader dr = retornaDataReader(buscarProdID, con);
                dr.Read();
                prod.NomeProd = dr[1].ToString();
                prod.Categoria = dr[2].ToString();
                prod.Preco = Convert.ToDouble(dr[3].ToString());
                prod.Medida = dr[4].ToString();
                prod.Quant = Convert.ToInt32(dr[5].ToString());
                return prod;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DelProd(SqlConnection con, Produto prod)
        {
            string deletaProd = "DELETE produto where codbar_prod=" +
                prod.Codbar_prod;
            try
            {
                executarComando(deletaProd, con);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

    
    
