using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Funcionario
    {
        //Atributos
        protected int idFunc;
        protected string nomeFunc;
        protected string rgFunc;
        protected string cpfFunc;
        protected string nomeUser;
        protected string senhaUser;

        public int IdFunc
        {
            get
            {
                return idFunc;
            }

            set
            {
                idFunc = value;
            }
        }

        public string NomeFunc
        {
            get
            {
                return nomeFunc;
            }

            set
            {
                nomeFunc = value;
            }
        }

        public string RgFunc
        {
            get
            {
                return rgFunc;
            }

            set
            {
                rgFunc = value;
            }
        }

        public string CpfFunc
        {
            get
            {
                return cpfFunc;
            }

            set
            {
                cpfFunc = value;
            }
        }

        public string NomeUser
        {
            get
            {
                return nomeUser;
            }

            set
            {
                nomeUser = value;
            }
        }

        public string SenhaUser
        {
            get
            {
                return senhaUser;
            }

            set
            {
                senhaUser = value;
            }
        }


        //Métodos

    }
}
