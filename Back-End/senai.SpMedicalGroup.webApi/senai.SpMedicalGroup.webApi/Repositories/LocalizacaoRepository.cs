using MongoDB.Driver;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly IMongoCollection<Localizacao> _Localizacoes;
        // readonly : serve apenas para leitura
        // IMongoCollection: nome da coleção

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("spmedicalgroup");
            _Localizacoes = database.GetCollection<Localizacao>("mapas");
        }


        public void Cadastrar(Localizacao NovaLocalizacao)
        {
            _Localizacoes.InsertOne(NovaLocalizacao);
        }


        public List<Localizacao> ListarTodas()
        {
            return _Localizacoes.Find(Localizacao => true).ToList();
        }
    }
}
