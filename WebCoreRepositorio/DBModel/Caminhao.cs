using System;
using System.ComponentModel.DataAnnotations;

namespace WebCoreRepositorio.DBModel
{
	public class Caminhao
	{
		[Key]
		public Guid ID { get; set; }

		[MaxLength(100)]
		public string Nome { get; set; }

		public short Modelo { get; set; }

		public short AnoFabricacao { get; set; }

		public short AnoModelo { get; set; }
	}
}
