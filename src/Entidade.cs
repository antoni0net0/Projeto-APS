using System;

namespace Entidades
{
    class Entidade
    {
        protected int id;
        protected string nome;
        protected string email;
        protected string telefone;
        protected string endereco;

        public Entidade()
        {
        }

        public int get_ID()
        {
            return id;
        }

        public string get_nome()
        {
             return nome;
        }

        public string get_email()
        {
            return email;
        }

        public string get_telefone()
        {
            return telefone;
        }

        public string get_endereco()
        {
            return Endereco;
        }
        
        ~Entidade()
        {
        }
    }
}