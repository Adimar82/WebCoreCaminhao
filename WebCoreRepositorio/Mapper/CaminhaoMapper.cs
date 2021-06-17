using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebCoreModel;
using WebCoreRepositorio.DBModel;

namespace WebCoreRepositorio.Mapper
{
	public class CaminhaoMapper
	{
		private IMapper _MapperModelToBD;
		private IMapper _MapperBDtoModel;

		public CaminhaoMapper()
		{
			var config = new AutoMapper.MapperConfiguration(cfg =>
			{
				cfg.CreateMap<CaminhaoModel, Caminhao>();
			});
			_MapperModelToBD = config.CreateMapper();
			var configReverse = new AutoMapper.MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Caminhao, CaminhaoModel>();
			});
			_MapperBDtoModel = configReverse.CreateMapper();
		}

		public Caminhao ModelToBD(CaminhaoModel caminhaoModel, Caminhao caminhao)
		{
			return (Caminhao)_MapperModelToBD.Map(caminhaoModel, caminhao, typeof(CaminhaoModel), typeof(Caminhao));
		}

		public CaminhaoModel BDToModel(Caminhao caminhao)
		{
			return _MapperBDtoModel.Map<CaminhaoModel>(caminhao);
		}
	}
}
