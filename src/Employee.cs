using System;

namespace Entidades
{
    class Employee : Entidade
    {
        public double Salario { get; private set; }
        public string Cargo { get; private set; }
        public int IdEmpresa { get; private set; }

        public Funcionario()
        {
        }
        
    }
}