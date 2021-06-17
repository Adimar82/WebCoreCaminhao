using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using WebCoreModel;
using WebCoreRepositorio;

namespace WebCoreNegocio
{
	public class CaminhaoNeg
	{
		#region Atributos
		private CaminhaoRep _ObjetoRep;
		#endregion


		#region ConstrutoresDestrutores
		public CaminhaoNeg(PersistDbContext repoDbContext)
		{
			_ObjetoRep = new CaminhaoRep(repoDbContext);
		}
		#endregion


		#region Metodos
		public RetornoMetodoTipado<CaminhaoModel> Inserir(CaminhaoModel model)
		{
			RetornoMetodoTipado<CaminhaoModel> retornoModel = null;
			retornoModel = ValidarModel(model, null);
			if (retornoModel.Sucesso == true)
			{
				retornoModel = _ObjetoRep.Inserir(model);				
			}
			return retornoModel;
		}

		public RetornoMetodoTipado<CaminhaoModel> Atualizar(CaminhaoModel model)
		{
			RetornoMetodoTipado<CaminhaoModel> retornoModel = null;
			RetornoMetodoTipado<CaminhaoModel> retornoPersistido = null;
			retornoPersistido = Pegar(model.ID);
			if (retornoPersistido.Sucesso == true || retornoPersistido.ObjetoRetorno == null)
			{
				retornoModel = ValidarModel(model, retornoPersistido.ObjetoRetorno);
				if (retornoModel.Sucesso == true)
				{
					retornoModel = _ObjetoRep.Atualizar(model);
				}
			}
			else
			{
				retornoModel.Sucesso = false;
				retornoModel.Mensagem = "Erro ao encontrar o Caminhão";
			}
			return retornoModel;
		}

		public RetornoMetodoTipado<bool> Excluir(CaminhaoModel model)
		{
			RetornoMetodoTipado<bool> retornoModel = null;			
			retornoModel = _ObjetoRep.Excluir(model);
			return retornoModel;
		}

		public RetornoMetodoTipado<CaminhaoModel> Pegar(Guid id)
		{
			RetornoMetodoTipado<CaminhaoModel> retornoModel = null;
			retornoModel = _ObjetoRep.Pegar(id);
			return retornoModel;
		}

		public RetornoMetodoTipado<List<CaminhaoModel>> ListarTodos()
		{
			RetornoMetodoTipado<List<CaminhaoModel>> retornoModel = null;
			retornoModel = _ObjetoRep.ListarTodos();
			return retornoModel;
		}

		private RetornoMetodoTipado<CaminhaoModel> ValidarModel(CaminhaoModel caminhaoModel, CaminhaoModel caminhaoPersistido)
		{
			RetornoMetodoTipado<CaminhaoModel> retorno = new RetornoMetodoTipado<CaminhaoModel>();
			retorno.Sucesso = true;
			retorno.Mensagem = "";

			if (caminhaoModel.Nome.Trim().Length < 3)
			{
				retorno.Sucesso = false;
				retorno.Mensagem += "Nome deve ter no mínimo 3 letras. ";
			}

			if (caminhaoModel.Modelo <= 0 || caminhaoModel.Modelo >= 3)
			{
				retorno.Sucesso = false;
				retorno.Mensagem += "Informe um Modelo válido. ";
			}
			
			if ((caminhaoPersistido == null && caminhaoModel.AnoFabricacao != (short)DateTime.Now.Year)  
				|| (caminhaoPersistido != null && caminhaoModel.AnoFabricacao < 1927 || caminhaoModel.AnoFabricacao >= short.MaxValue))
			{
				retorno.Sucesso = false;
				retorno.Mensagem += "Informe um Ano de Fabricação válido. ";
			}

			if ((caminhaoPersistido == null && caminhaoModel.AnoModelo < (short)DateTime.Now.Year) 
				|| (caminhaoPersistido != null && caminhaoModel.AnoModelo < short.MaxValue && caminhaoModel.AnoModelo < caminhaoPersistido.AnoModelo))
			{
				retorno.Sucesso = false;
				retorno.Mensagem += "Informe um Ano do Modelo válido. ";
			}

			return retorno;
		}
		#endregion
	}
}
