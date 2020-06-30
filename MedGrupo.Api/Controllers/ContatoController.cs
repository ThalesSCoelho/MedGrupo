using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedGrupo.Domain;
using MedGrupo.Services.Interfaces;
using MedGrupo.Services;

namespace MedGrupo.Controllers
{
	[ApiController]
	[Route("Contato")]
    public class ContatoController : Controller
	{
		private readonly IContatoService _contatoService;
		public bool Persistir = true;

		public ContatoController(IContatoService ContatoService)
		{
			_contatoService = ContatoService;
		}
		
		[HttpGet()]
		[Route("{id:int}")]
		public IActionResult Get(int id)
		{
			try
			{
				var lista = _contatoService.Query(false)
					.FirstOrDefault(x => x.Id == id);

				if(lista == null)
				{
					return NotFound();
				}
				
				return Ok(lista);
			}
			catch(Exception)
			{
				return BadRequest();
			}
			
		}

		[HttpGet]
		[Route("")]
		public IActionResult Get()
		{
			try
			{
				var lista = _contatoService.Query(false)
					.ToList();

				if(lista == null)
				{
					return NotFound();
				}
				
				return Ok(lista);
			}
			catch(Exception ex)
			{
				return BadRequest(ex);
			}
			
		}

		[HttpPost]
		[Route("")]
		public IActionResult Post([FromBody]Contato entity)
		{
			if(ModelState.IsValid)
			{
				try
				{
					_contatoService.Salvar(entity);

					return Ok("Pessoa Física Incluida com sucesso!");
				}
				catch(Exception ex)
				{
					return BadRequest(ex);
				}
				
			}

			return BadRequest(ModelState);
		
		}

		[HttpPut]
		[Route("")]
		public IActionResult Put([FromBody]Contato entity)
		{
			if(ModelState.IsValid)
			{
				try
				{
					_contatoService.Salvar(entity);

					return Ok("Pessoa Física Editada com sucesso!");
				}
				catch(Exception ex)
				{
					return BadRequest(ex);
				}
				
			}
			
			return BadRequest(ModelState);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult Delete(int id)
		{
			if (id == 0)
            {
                return BadRequest("Favor Informar o Contato!");
            }
			
			try
			{
				_contatoService.Remover(id);
				
				return Ok("Pessoa Física Removida com sucesso!");
			}
			catch(Exception ex)
			{
				return BadRequest(ex);
			}

			
		}
	}
}