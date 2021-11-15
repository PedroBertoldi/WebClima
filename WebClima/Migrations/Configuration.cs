namespace WebClima.Migrations
{
    using System;
using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
using System.Linq;
    using WebClima.Models.Enums;
    using WebClima.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebClima.Data.WebClimaContext>
    {
        private readonly Random _gerador;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            _gerador = new Random();
        }

        protected override void Seed(WebClima.Data.WebClimaContext context)
        {
            var defaultEstados = new List<Estado>();
            var defaultCidades = new List<Cidade>();
            var defaultPrevisoes = new List<PrevisaoClima>();

            defaultEstados.Add(new Estado() { Id = 1, Nome = "Paraná", UF = "PR" });
            defaultEstados.Add(new Estado() { Id = 2, Nome = "São Paulo", UF = "SP" });
            defaultEstados.Add(new Estado() { Id = 3, Nome = "Rio de Janeiro", UF = "RJ" });

            context.Estados.AddOrUpdate(defaultEstados.ToArray());

            defaultCidades.Add(new Cidade() { Id = 1, Nome = "Curitiba", EstadoId = 1 });
            defaultCidades.Add(new Cidade() { Id = 2, Nome = "Maringa", EstadoId = 1 });
            defaultCidades.Add(new Cidade() { Id = 3, Nome = "São Paulo", EstadoId = 2 });
            defaultCidades.Add(new Cidade() { Id = 4, Nome = "Rio de Janeiro", EstadoId = 3 });
            defaultCidades.Add(new Cidade() { Id = 5, Nome = "Diadema", EstadoId = 2 });
            defaultCidades.Add(new Cidade() { Id = 6, Nome = "Ribeirão Preto", EstadoId = 2 });

            context.Cidades.AddOrUpdate(defaultCidades.ToArray());
            var counter = 0;
            foreach (var cidade in defaultCidades)
            {
                for (int i = 0; i < 7; i++)
                {
                    defaultPrevisoes.Add(new PrevisaoClima()
                    {
                        Id = counter++,
                        CidadeId = cidade.Id,
                        DataPrevisao = DateTime.Now.AddDays(i),
                        TemperaturaMaxima = _gerador.Next(18, 40),
                        TemperaturaMinima = _gerador.Next(0, 18),
                        Clima = SelectRandom(),
                    }); ;
                }
            }

            context.Previsoes.AddOrUpdate(defaultPrevisoes.ToArray());
        }
        private string SelectRandom()
        {
            var temp = (EnumClima)_gerador.Next(0, Enum.GetNames(typeof(EnumClima)).Length);
            return temp.ToString();
        }
    }
}
