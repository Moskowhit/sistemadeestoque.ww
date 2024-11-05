using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Produto
    {

        //Atributos
        protected int codbar_prod;
        protected string nome_prod;
        protected string categoria;
        protected double preco;
        protected int quant;
        protected string medida;
      

        public int Codbar_prod
        {
            get
            {
                return codbar_prod;
            }

            set
            {
                codbar_prod = value;
            }
        }

        public string NomeProd
        {
            get
            {
                return nome_prod;
            }

            set
            {
                nome_prod = value;
            }
        }

        public string Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public double Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }

        public int Quant
        {
            get
            {
                return quant;
            }

            set
            {
                quant= value;
            }
        }

        public string Medida
        {
            get
            {
                return medida;
            }

            set
            {
                medida = value;
            }
        }


        //Métodos

    }
}


