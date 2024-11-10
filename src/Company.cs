using System;

namespace Entities
{
    class Company : Entity
    {
        public string Password { get; private set; }
        public string Cnpj { get; private set; }
        
        private List<Employee> EmployeeList;

        public Company()
        {
        }
        
        public void Login()
        {
        }

        public void Logout()
        {
        }

        public void CheckExpenses(List<Employee> list)
        {
        }
    }
}