using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCoreModel
{
	public class CaminhaoModel
	{
		public CaminhaoModel()
		{
			ID = Guid.Empty;
			Nome = "";
			AnoFabricacao = (short)DateTime.Now.Year;
			AnoModelo = (short)DateTime.Now.Year;
		}

		public Guid ID { get; set; }

		[Display(Name = "Nome")]
		[Required(ErrorMessage = "Informe o nome")]
		[MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 letras")]
		[MinLength(3, ErrorMessage = "Nome deve ter no mínimo 3 letras")]
		public string Nome { get; set; }

		[Display(Name = "Modelo")]
		[Range(1, 2, ErrorMessage = "Informe um modelo válido.")]
		public short Modelo { get; set; }

		[ReadOnly(true)]
		[Display(Name = "Ano de Fabricação")]
		[Range(1927, 32767, ErrorMessage = "Informe um ano de fabricação válido.")]
		public short AnoFabricacao { get; set; }

		[Display(Name = "Ano do Modelo")]
		[Range(1927, 32767, ErrorMessage = "Informe o ano do modelo válido.")]
		public short AnoModelo { get; set; }
	}
}
