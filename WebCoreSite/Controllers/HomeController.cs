using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCoreModel;
using WebCoreNegocio;
using WebCoreSite.Models;

namespace WebCoreSite.Controllers
{
	public class HomeController : Controller
	{
		CaminhaoNeg _ObjetoNeg;

		public HomeController(CaminhaoNeg objetoNeg)
		{
			_ObjetoNeg = objetoNeg;
		}

		public IActionResult Index()
		{
			SPAObjetoViewModel sPAObjetoViewModel = new SPAObjetoViewModel();
			CarrregaItens(sPAObjetoViewModel);
			return View(sPAObjetoViewModel);
		}

		[HttpPost]
		public IActionResult atualizar(CaminhaoModel caminhaoModel)
		{
			SPAObjetoViewModel sPAObjetoViewModel = new SPAObjetoViewModel();
			IActionResult retorno = Redirect("/home/index");
			RetornoMetodoTipado<CaminhaoModel> retornoPersistir;

			if (ModelState.IsValid)
			{
				if (caminhaoModel.ID == Guid.Empty)
				{
					caminhaoModel.ID = Guid.NewGuid();
					retornoPersistir = _ObjetoNeg.Inserir(caminhaoModel);
				}
				else
				{
					retornoPersistir = _ObjetoNeg.Atualizar(caminhaoModel);
				}

				sPAObjetoViewModel.Lista = new List<CaminhaoModel>();
				CarrregaItens(sPAObjetoViewModel);

				if (retornoPersistir.Sucesso == false)
				{
					sPAObjetoViewModel.MensagensErro = retornoPersistir.Mensagem;
					//ModelState.Clear();
					retorno = View("index", sPAObjetoViewModel);
				}
				else
				{
					sPAObjetoViewModel.InserirAtualizar = new CaminhaoModel();
				}
			}
			else
			{
				sPAObjetoViewModel.InserirAtualizar = caminhaoModel;
				sPAObjetoViewModel.Lista = new List<CaminhaoModel>();
				CarrregaItens(sPAObjetoViewModel);
				retorno = View("index", sPAObjetoViewModel);
			}

			return retorno;
		}

		public IActionResult editar(Guid id)
		{
			SPAObjetoViewModel sPAObjetoViewModel = new SPAObjetoViewModel();
			RetornoMetodoTipado<CaminhaoModel> retornoEditar;

			retornoEditar = _ObjetoNeg.Pegar(id);
			if (retornoEditar.Sucesso == true)
			{
				sPAObjetoViewModel.InserirAtualizar = retornoEditar.ObjetoRetorno;
			}
			else
			{
				sPAObjetoViewModel.MensagensErro = retornoEditar.Mensagem;
			}
			sPAObjetoViewModel.Lista = new List<CaminhaoModel>();
			CarrregaItens(sPAObjetoViewModel);

			return View("Index", sPAObjetoViewModel);
		}

		public IActionResult excluir(Guid id)
		{
			SPAObjetoViewModel sPAObjetoViewModel = new SPAObjetoViewModel();

			_ObjetoNeg.Excluir(_ObjetoNeg.Pegar(id).ObjetoRetorno);
			sPAObjetoViewModel.InserirAtualizar = new CaminhaoModel();
			sPAObjetoViewModel.Lista = new List<CaminhaoModel>();
			CarrregaItens(sPAObjetoViewModel);

			return Redirect("/home/index");
		}

		private void CarrregaItens(SPAObjetoViewModel model)
		{
			model.Lista = _ObjetoNeg.ListarTodos().ObjetoRetorno;			
			CarregarModelos(model.InserirAtualizar.Modelo, "Selecione");
		}

		private short CarregarModelos(short valorSelecionado, string textoPrimeiroItem)
		{
			List<KeyValuePair<Int16, string>> liItens = new List<KeyValuePair<Int16, string>>();
			
			liItens.Add(new KeyValuePair<Int16, string>(0, textoPrimeiroItem));
			liItens.Add(new KeyValuePair<Int16, string>(1, "FH"));
			liItens.Add(new KeyValuePair<Int16, string>(1, "FM"));

			ViewBag.ListaModelos = CarregarSelectList(liItens, li => li.Key, li => li.Value, valorSelecionado);

			return valorSelecionado;
		}

		public IEnumerable<SelectListItem> CarregarSelectList<T>(List<T> entities, Func<T, object> funcToGetValue, Func<T, object> funcToGetText
		, object selectedValue)
		{
			return entities.Select(x => new SelectListItem
			{
				Value = funcToGetValue(x).ToString(),
				Text = funcToGetText(x).ToString(),
				Selected = selectedValue != null ? ((funcToGetValue(x).ToString() == selectedValue.ToString()) ? true : false) : false
			});
		}
	}
}
