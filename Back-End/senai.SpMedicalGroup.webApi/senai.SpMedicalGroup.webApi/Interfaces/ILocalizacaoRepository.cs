using senai.SpMedicalGroup.webApi.Domains;
using System.Collections.Generic;


namespace senai.SpMedicalGroup.webApi.Interfaces
{
    interface ILocalizacaoRepository
    {
        List<Localizacao> ListarTodas();

        void Cadastrar(Localizacao NovaLocalizacao);
    }
}
