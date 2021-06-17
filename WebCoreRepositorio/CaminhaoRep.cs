using System;
using WebCoreModel;
using System.Linq;
using System.Collections.Generic;
using WebCoreRepositorio.Mapper;
using WebCoreRepositorio.DBModel;

namespace WebCoreRepositorio
{
	public class CaminhaoRep
	{		
		private PersistDbContext _PersistDbContext;
		private CaminhaoMapper _CaminhaoMapper;

		public CaminhaoRep(PersistDbContext context)
		{
			_PersistDbContext = context;
			_CaminhaoMapper = new CaminhaoMapper();
		}
		public RetornoMetodoTipado<CaminhaoModel> Atualizar(CaminhaoModel model)
		{
			RetornoMetodoTipado<CaminhaoModel> retornoMetodo = new RetornoMetodoTipado<CaminhaoModel>();
			retornoMetodo.Sucesso = true;

			try
			{
				if (model != null)
				{
					Caminhao caminhao = new Caminhao();
					caminhao = (from cam in _PersistDbContext.Caminhao where cam.ID == model.ID select cam).FirstOrDefault();
					caminhao = _CaminhaoMapper.ModelToBD(model, caminhao);
					_PersistDbContext.Caminhao.Update(caminhao);
					_PersistDbContext.SaveChanges();
					retornoMetodo.ObjetoRetorno = _CaminhaoMapper.BDToModel(caminhao);
				}
				else
				{
					retornoMetodo.Sucesso = false;
					retornoMetodo.Mensagem = "Model está nulo.";
				}
			}
			catch (Exception ex)
			{
				retornoMetodo.Sucesso = false;
				retornoMetodo.Mensagem = "Erro ao salvar.";
				retornoMetodo.Erro = ex;
			}

			return retornoMetodo;
		}

		public RetornoMetodoTipado<bool> Excluir(CaminhaoModel model)
		{
			RetornoMetodoTipado<bool> retornoMetodo = new RetornoMetodoTipado<bool>();
			retornoMetodo.Sucesso = true;

			try
			{
				if (model != null)
				{
					Caminhao entity;
					entity = (from entityFind in _PersistDbContext.Caminhao where entityFind.ID == model.ID select entityFind).FirstOrDefault();
					_PersistDbContext.Caminhao.Remove(entity);
					_PersistDbContext.SaveChanges();
				}
				else
				{
					retornoMetodo.Sucesso = false;
					retornoMetodo.Mensagem = "Model está nulo.";
				}
			}
			catch (Exception ex)
			{
				retornoMetodo.Sucesso = false;
				retornoMetodo.Mensagem = "Erro ao excluir.";
				retornoMetodo.Erro = ex;
			}

			return retornoMetodo;
		}

		public RetornoMetodoTipado<CaminhaoModel> Inserir(CaminhaoModel model)
		{
			RetornoMetodoTipado<CaminhaoModel> retornoMetodo = new RetornoMetodoTipado<CaminhaoModel>();
			retornoMetodo.Sucesso = true;

			try
			{
				if (model != null)
				{
					Caminhao entity;
					entity = (from entityFind in _PersistDbContext.Caminhao where entityFind.ID == model.ID select entityFind).FirstOrDefault();
					if (entity == null)
					{
						entity = _CaminhaoMapper.ModelToBD(model, entity);
						_PersistDbContext.Caminhao.Add(entity);
						_PersistDbContext.SaveChanges();
						retornoMetodo.ObjetoRetorno = _CaminhaoMapper.BDToModel(entity);
					}
					else
					{
						retornoMetodo.Sucesso = false;
						retornoMetodo.Mensagem = string.Format("Caminhão id '{0}' já existe.", model.ID);
					}
				}
				else
				{
					retornoMetodo.Sucesso = false;
					retornoMetodo.Mensagem = "Model está nulo.";
				}
			}
			catch (Exception ex)
			{
				retornoMetodo.Sucesso = false;
				retornoMetodo.Mensagem = "Erro ao Inserir.";
				retornoMetodo.Erro = ex;
			}

			return retornoMetodo;
		}


		public RetornoMetodoTipado<CaminhaoModel> Pegar(Guid id)
		{
			RetornoMetodoTipado<CaminhaoModel> retornoMetodoTipado = new RetornoMetodoTipado<CaminhaoModel>();
			retornoMetodoTipado.Sucesso = true;
			
			try
			{
				Caminhao caminhao = (from cam in _PersistDbContext.Caminhao where cam.ID == id select cam).FirstOrDefault();
				retornoMetodoTipado.ObjetoRetorno = _CaminhaoMapper.BDToModel(caminhao);
			}
			catch (Exception ex)
			{
				retornoMetodoTipado.Sucesso = false;
				retornoMetodoTipado.Mensagem = "Erro ao pesquisar.";
				retornoMetodoTipado.Erro = ex;
			}

			return retornoMetodoTipado;
		}

		public RetornoMetodoTipado<List<CaminhaoModel>> ListarTodos()
		{
			RetornoMetodoTipado<List<CaminhaoModel>> retornoMetodoTipado = new RetornoMetodoTipado<List<CaminhaoModel>>();
			retornoMetodoTipado.Sucesso = false;
		
			try
			{
				List<Caminhao> caminhoes = (from cam in _PersistDbContext.Caminhao select cam).ToList();
				retornoMetodoTipado.ObjetoRetorno = new List<CaminhaoModel>();
				if (caminhoes != null && caminhoes.Count > 0)
				{
					foreach (Caminhao item in caminhoes)
					{
						retornoMetodoTipado.ObjetoRetorno.Add(_CaminhaoMapper.BDToModel(item));
					}
				}
			}
			catch (Exception ex)
			{
				retornoMetodoTipado.Sucesso = false;
				retornoMetodoTipado.Mensagem = "Erro ao pesquisar.";
				retornoMetodoTipado.Erro = ex;
			}

			return retornoMetodoTipado;
		}
	}
}
