using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceFIPE.Modelo;

namespace WebServiceFIPE
{
    public class Consulta
    {
        public List<TipoFIPEinfo> ConsultarTiposFIPE()
        {
            return new List<TipoFIPEinfo>
            {
                new TipoFIPEinfo{Tipo = "carros", Descricao = "Carros"},
                new TipoFIPEinfo{Tipo = "caminhoes", Descricao = "Caminhão e Micro-Onibus"},
                new TipoFIPEinfo{Tipo = "motos", Descricao = "Motos"}
            };
        }

        public List<MarcaFIPEinfo> ConsultarMarcasFIPE(string tipo)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri("http://fipeapi.appspot.com/")
            };

            var req = new RestRequest("api/1/{tipo}/marcas.json", Method.GET);

            req.AddParameter("tipo", tipo, ParameterType.UrlSegment);

            var response = client.Execute(req);
            var contentResponse = JsonConvert.DeserializeObject<List<MarcaFIPEinfo>>(response.Content);

            return contentResponse;
        }

        public List<CarroFIPEinfo> ConsultarCarrosFIPE(string tipo, int idMarca)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri("http://fipeapi.appspot.com/")
            };

            var req = new RestRequest("api/1/{tipo}/veiculos/{id}.json", Method.GET);

            req.AddParameter("tipo", tipo, ParameterType.UrlSegment);
            req.AddParameter("id", idMarca, ParameterType.UrlSegment);

            var response = client.Execute(req);
            var contentResponse = JsonConvert.DeserializeObject<List<CarroFIPEinfo>>(response.Content);

            return contentResponse;
        }

        public List<CarroAnoFIPEinfo> ConsultarCarrosAnoFIPE(string tipo, int idMarca, long idCarro)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri("http://fipeapi.appspot.com/")
            };

            var req = new RestRequest("api/1/{tipo}/veiculo/{id}/{idC}.json", Method.GET);

            req.AddParameter("tipo", tipo, ParameterType.UrlSegment);
            req.AddParameter("id", idMarca, ParameterType.UrlSegment);
            req.AddParameter("idC", idCarro, ParameterType.UrlSegment);

            var response = client.Execute(req);
            var contentResponse = JsonConvert.DeserializeObject<List<CarroAnoFIPEinfo>>(response.Content);

            return contentResponse;
        }

        public FIPEInfo ConsultarPreco(string tipo, int idMarca, long idCarro, string idAno)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri("http://fipeapi.appspot.com/")
            };

            var req = new RestRequest("api/1/{tipo}/veiculo/{id}/{idC}/{idA}.json", Method.GET);

            req.AddParameter("tipo", tipo, ParameterType.UrlSegment);
            req.AddParameter("id", idMarca, ParameterType.UrlSegment);
            req.AddParameter("idC", idCarro, ParameterType.UrlSegment);
            req.AddParameter("idA", idAno, ParameterType.UrlSegment);

            var response = client.Execute(req);
            var contentResponse = JsonConvert.DeserializeObject<FIPEInfo>(response.Content);

            return contentResponse;
        }
    }
}
