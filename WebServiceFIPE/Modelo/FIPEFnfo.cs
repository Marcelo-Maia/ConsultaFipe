using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceFIPE.Modelo
{
    /// <summary>
    /// Modelo representa o objeto com os dados da consulta ao Webservice da FIPE
    /// </summary>
    public class FIPEInfo
    {
        public string fipe_codigo { get; set; }
        public string combustivel { get; set; }
        public string marca { get; set; }
        public string ano_modelo { get; set; }
        public string preco { get; set; }
        public string key { get; set; }
        public string veiculo { get; set; }
        public int id { get; set; }
        public string referencia { get; set; }
        public string name { get; set; }
        public string time { get; set; }
    }

    /// <summary>
    /// Modelo representa o objeto com os dados dos tipos (carro, moto ...)
    /// </summary>
    public class TipoFIPEinfo
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }

    /// <summary>
    /// Modelo representa o objeto com os dados da marca
    /// </summary>
    public class MarcaFIPEinfo
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Fipe_Name { get; set; }
    }

    /// <summary>
    /// Modelo representa o objeto com os dados do carro, moto ou caminhão
    /// </summary>
    public class CarroFIPEinfo
    {
        public long id { get; set; }
        public string fipe_marca { get; set; }
        public string name { get; set; }
        public string marca { get; set; }
        public string key { get; set; }
        public string fipe_name { get; set; }
    }

    /// <summary>
    /// Modelo representa o objeto com os dados do ano do veiculo selecionado
    /// </summary>
    public class CarroAnoFIPEinfo
    {
        public string id { get; set; }
        public string fipe_marca { get; set; }
        public string fipe_codigo { get; set; }
        public string name { get; set; }
        public string marca { get; set; }
        public string key { get; set; }
        public string veiculo { get; set; }
    }
}
