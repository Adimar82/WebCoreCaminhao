
using System.Collections.Generic;
using WebCoreModel;

namespace WebCoreSite.Models
{
	public class SPAObjetoViewModel
	{
		public CaminhaoModel InserirAtualizar;
		public List<CaminhaoModel> Lista;
		public string MensagensErro;

		public SPAObjetoViewModel()
		{
			InserirAtualizar = new CaminhaoModel();
			Lista = new List<CaminhaoModel>();
			MensagensErro = null;
		}
	}
}
