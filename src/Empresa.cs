using System;

namespace Entidades
{
    class Empresa : Entidade
    {
        public string Senha { get; private set; }
        public string Cnpj { get; private set; }
        
        private List<Funcionario> ListaFuncionarios;

        public Empresa()
        {
        }
        
        public void Login()
        {
        }

        public void Logout()
        {
        }

        public void VerificarDespesas(List<Funcionario> lista)
        {
        }
    }
}