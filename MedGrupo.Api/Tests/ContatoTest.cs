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
using System.ComponentModel.DataAnnotations;
using MedGrupo.Services.Interfaces;

namespace MedGrupo.Tests
{
    public class ContatoTest : TestBase
    {
        ContatoController _controller;
        IContatoService _contatoService;

        public ContatoTest()
        {
            _contatoService = base.ServiceProvider.GetService<IContatoService>();
        }

        [Fact]
        public void Contato_ControllerGetAll()
        {                        
            _controller = new ContatoController(_contatoService);            

            var actionResult = _controller.Get();            
            var type = actionResult.GetType();            
            var result = type.FullName == "Microsoft.AspNetCore.Mvc.OkObjectResult";

            Assert.True(result);
        }

        [Fact]
        public void Contato_ControllerGetById()
        {                        
            _controller = new ContatoController(_contatoService);            

            var actionResult = _controller.Get(1);
            var type = actionResult.GetType();            
            var result = type.FullName == "Microsoft.AspNetCore.Mvc.OkObjectResult";

            Assert.True(result);
        }

        [Fact]
        public void Contato_NomeObrigatorio()
        {                        
            Contato contato = new Contato();
            contato.DtNascimento = DateTime.Parse("17/03/1978");
            contato.Sexo = "M";

            _controller = new ContatoController(_contatoService);
            var context = new ValidationContext(contato, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(contato, context, validationResults, true);

            Assert.False(isValid);
        }

        [Fact]
        public void Contato_TamanhoMinimo()
        {                        
            Contato contato = new Contato();
            contato.Nome = "T";
            contato.DtNascimento = DateTime.Parse("17/03/1978");
            contato.Sexo = "M";

            _controller = new ContatoController(_contatoService);
            var context = new ValidationContext(contato, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(contato, context, validationResults, true);

            Assert.False(isValid);
        }

        [Fact]
        public void Contato_TamanhoMaximo()
        {                        
            Contato contato = new Contato();
            contato.Nome = "ksdhgf la ofihasdifha isodhfv oiasdbvlahsbgdiva gsdfvghkahdgcxasgdvuiasgv cjahkjb askdvgc kaxsdhvckjuxvsdgfkcjabskdcjhaogisdvcxhbc vjhldcvb sdhv iasg doaisl bldhc oliasdg oisagdkasdf kahsdgf kashdgf kashdgf kasjdhgf aksjdhfg aksjdgf isygc faisdyhgf kajshdf akjshdgf aksjhdgf akjsdhgf akjsdgf aksjdhgf aksjhdgf aksjhdgf aksjdhfga";
            contato.DtNascimento = DateTime.Parse("17/03/1978");
            contato.Sexo = "M";

            _controller = new ContatoController(_contatoService);
            var context = new ValidationContext(contato, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(contato, context, validationResults, true);

            Assert.False(isValid);
        }

        [Fact]
        public void Contato_DataNascimentoObrigatorio()
        {                        
            Contato contato = new Contato();
            contato.Nome = "MedGrupo";
            contato.Sexo = "M";

            _controller = new ContatoController(_contatoService);
            var context = new ValidationContext(contato, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(contato, context, validationResults, true);

            Assert.False(isValid);
        }

        [Fact]
        public void Contato_SexoObrigatorio()
        {                        
            Contato contato = new Contato();
            contato.Nome = "MedGrupo";
            contato.DtNascimento = DateTime.Parse("17/03/1978");            

            _controller = new ContatoController(_contatoService);
            var context = new ValidationContext(contato, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(contato, context, validationResults, true);

            Assert.False(isValid);
        }

        [Fact]
        public void Contato_SexoMF()
        {                        
            Contato contato = new Contato();
            contato.Nome = "MedGrupo";
            contato.DtNascimento = DateTime.Parse("17/03/1978");  
            contato.Sexo = "I";

            _controller = new ContatoController(_contatoService);
            var context = new ValidationContext(contato, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(contato, context, validationResults, true);

            Assert.False(isValid);
        }

    }
}
