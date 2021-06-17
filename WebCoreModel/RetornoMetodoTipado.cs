using System;

namespace WebCoreModel
{
	/// <summary>
	/// Classe tipada para o retorno dos métodos.
	/// </summary>
	public class RetornoMetodoTipado<T>
	{
		#region Atributos		
		private Exception _Erro;
		private string _Mensagem;
		private T _ObjetoRetorno;
		private bool _Sucesso;
		#endregion


		/// <summary>
		/// Construtor padrão.
		/// </summary>
		public RetornoMetodoTipado()
		{
			_Erro = null;
			_Sucesso = true;
			_Mensagem = string.Empty;
		}

		/// <summary>
		/// Destrutor padrão.
		/// </summary>
		~RetornoMetodoTipado()
		{
			_Erro = null;
			_Sucesso = false;
			_Mensagem = null;
		}

		/// <summary>
		/// Erro que possa ter ocorrido na execução do método.
		/// </summary>
		public Exception Erro
		{
			get { return _Erro; }
			set { _Erro = value; }
		}

		/// <summary>
		/// Mensagem amigável.
		/// </summary>
		public string Mensagem
		{
			get { return _Mensagem; }
			set { _Mensagem = value; }
		}

		/// <summary>
		/// Objeto de retorno.
		/// </summary>
		public T ObjetoRetorno
		{
			get { return _ObjetoRetorno; }
			set { _ObjetoRetorno = value; }
		}

		/// <summary>
		/// Se houve sucesso ou não na execução do método.
		/// </summary>
		public bool Sucesso
		{
			get { return _Sucesso; }
			set { _Sucesso = value; }
		}
	}
}
