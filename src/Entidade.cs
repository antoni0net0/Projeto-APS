using System;

namespace Entidades
{
    class Entidade
    {
        protected int id;
        protected string Nome { get; private set; };
        protected string Email { get; private set; };
        protected string Telefone { get; private set; };
        protected string Endereco { get; private set; };

        public Entidade()
        {
        }

        public int get_ID()
        {
            return id;
        }
        
        ~Entidade()
        {
        }
    }
}