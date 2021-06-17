using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using WebCoreModel;
using WebCoreNegocio;
using WebCoreRepositorio;

namespace WebCoreTest
{
	[TestClass]
	public class UnitTestCaminhao
	{
		private CaminhaoNeg _CaminhaoNeg;
		private PersistDbContext _PersistDbContext;

		public UnitTestCaminhao()
		{
			var builder = new DbContextOptionsBuilder<PersistDbContext>();
			var connectionString = "Server=localhost;Port=3306;User ID=caminhaouser;Password=a123456b;Database=caminhaobd";
			builder.UseMySql(connectionString);			
			_PersistDbContext = new PersistDbContext(builder.Options);
			_PersistDbContext.Database.EnsureCreated();
			_CaminhaoNeg = new CaminhaoNeg(_PersistDbContext);			
		}

		[TestMethod]
		
		public void CaminhaoCadastro_Sucesso()
		{
			RetornoMetodoTipado<CaminhaoModel> retorno = new RetornoMetodoTipado<CaminhaoModel>();
			retorno = _CaminhaoNeg.Inserir(CriarCaminhao());
			Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
		}

		[TestMethod]
		public void CaminhaoCadastro_Erro()
		{
			RetornoMetodoTipado<CaminhaoModel> retorno = new RetornoMetodoTipado<CaminhaoModel>();
			CaminhaoModel caminhaoModel = CriarCaminhao();
			caminhaoModel.Modelo = 3;
			retorno = _CaminhaoNeg.Inserir(caminhaoModel);
			Assert.AreEqual(false, retorno.Sucesso, retorno.Mensagem);
		}

		[TestMethod]
		public void CaminhaoPegar_Sucesso()
		{
			RetornoMetodoTipado<CaminhaoModel> retorno = new RetornoMetodoTipado<CaminhaoModel>();
			CaminhaoModel caminhaoModel = CriarCaminhao();
			retorno = _CaminhaoNeg.Inserir(caminhaoModel);			
			retorno = _CaminhaoNeg.Pegar(retorno.ObjetoRetorno.ID);
			Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
		}

		[TestMethod]
		public void CaminhaoAlterar_Sucesso()
		{
			RetornoMetodoTipado<CaminhaoModel> retorno = new RetornoMetodoTipado<CaminhaoModel>();
			CaminhaoModel caminhaoModel = CriarCaminhao();
			retorno = _CaminhaoNeg.Inserir(caminhaoModel);
			retorno.ObjetoRetorno.AnoFabricacao++;
			retorno = _CaminhaoNeg.Atualizar(retorno.ObjetoRetorno);
			Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
		}

		[TestMethod]
		public void CaminhaoAlterar_Erro()
		{
			RetornoMetodoTipado<CaminhaoModel> retorno = new RetornoMetodoTipado<CaminhaoModel>();
			CaminhaoModel caminhaoModel = CriarCaminhao();
			retorno = _CaminhaoNeg.Inserir(caminhaoModel);
			retorno.ObjetoRetorno.Nome = "";
			retorno = _CaminhaoNeg.Atualizar(retorno.ObjetoRetorno);
			Assert.AreEqual(false, retorno.Sucesso, retorno.Mensagem);
		}

		[TestMethod]
		public void CaminhaoExcluir_Sucesso()
		{
			RetornoMetodoTipado<bool> retorno = new RetornoMetodoTipado<bool>();
			RetornoMetodoTipado<CaminhaoModel> retornoIns = new RetornoMetodoTipado<CaminhaoModel>();
			CaminhaoModel caminhaoModel = CriarCaminhao();
			retornoIns = _CaminhaoNeg.Inserir(caminhaoModel);
			retorno = _CaminhaoNeg.Excluir(retornoIns.ObjetoRetorno);
			Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
		}

		private CaminhaoModel CriarCaminhao()
		{
			CaminhaoModel caminhaoCadastrado;
			caminhaoCadastrado = new CaminhaoModel();
			caminhaoCadastrado.ID = Guid.NewGuid();
			var rand = new Random();
			var uid = rand.Next(1, 1000000);
			caminhaoCadastrado.Nome = "Cabine leito " + uid.ToString();
			caminhaoCadastrado.Modelo = 1; //FH
			caminhaoCadastrado.AnoModelo = 2021;
			caminhaoCadastrado.AnoFabricacao = (short)DateTime.Now.Year;
			caminhaoCadastrado.ID = Guid.Empty;
			return caminhaoCadastrado;
		}
	}
}
