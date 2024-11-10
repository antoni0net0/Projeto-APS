using System;

namespace Entities
{
    class Employee : Entity
    {
        public double Salary { get; private set; }
        public string Role { get; private set; }
        public int CompanyId { get; private set; }

        public Employee()
        {
        }
        
    }
}