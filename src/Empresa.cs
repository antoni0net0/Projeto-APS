using System;

namespace Entidades
{
    class Empresa : Entidade
    {
        private string senha;
        private string cnpj;
        
        private List<Funcionario> lista_funcionarios;

        public Empresa()
        {
        }
        
        public void Login()
        {
        }

        public void Logout()
        {
        }

        public string get_senha()
        {
            return senha;
        }

        public string get_cnpj()
        {
            return cnpj;
        }

        public void VerificarDespesas(List<Funcionario> lista)
        {
        }
    }
}