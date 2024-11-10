using System;

namespace Entities
{
    class Entity
    {
        protected int id;
        protected string Name { get; private set; };
        protected string Email { get; private set; };
        protected string Phone { get; private set; };
        protected string Address { get; private set; };

        public Entity()
        {
        }

        public int get_ID()
        {
            return id;
        }
        
    }
}