using System;

namespace Entities
{
    class Entity
    {
        protected int id;
        protected string Nome { get; private set; };
        protected string Email { get; private set; };
        protected string Telefone { get; private set; };
        protected string Endereco { get; private set; };

        public Entity()
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