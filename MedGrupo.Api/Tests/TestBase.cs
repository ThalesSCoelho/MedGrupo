using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MedGrupo.Controllers;
using MedGrupo.Repository;
using MedGrupo.Repository.Interfaces;
using Xunit;
using MedGrupo.Data;
using MedGrupo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using MedGrupo.Services.Interfaces;
using MedGrupo.Services;

namespace MedGrupo.Tests
{
    public class TestBase
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public  TestBase()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IContatoService, ContatoService>();            
            serviceCollection.AddDbContext<DataContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            ServiceProvider = serviceCollection.BuildServiceProvider();            
        }
    }
}