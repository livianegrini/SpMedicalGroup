using senai.SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Interfaces
{
    interface IUsuarioRepository 
    {
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="Email">E-mail do usuário</param>
        /// <param name="Senha">Senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi encontrado</returns>
        Usuario Login(string Email, string Senha);
    }

    //fazer crud
}
