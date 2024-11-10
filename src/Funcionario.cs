using System;

namespace Entidades
{
    class Funcionario : Entidade
    {
        private double salario;
        private string cargo;
        private int idempresa;

        public Funcionario()
        {
        }

        public double get_salario()
        {
            return salario;
        }

        public string get_cargo()
        {
            return cargo;
        }

        public int get_idempresa()
        {
            return idempresa;
        }
    }
}