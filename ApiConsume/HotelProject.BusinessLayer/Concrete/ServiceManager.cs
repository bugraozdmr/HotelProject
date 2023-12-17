using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
	public class ServiceManager : IServiceService
	{
		private readonly IServicesDal _servicesDal;

		public ServiceManager(IServicesDal servicesDal)
		{
			_servicesDal = servicesDal;
		}

		public void TInsert(Service entity)
		{
			_servicesDal.Insert(entity);
		}

		public void TDelete(Service entity)
		{
			_servicesDal.Delete(entity);
		}

		public void TUpdate(Service entity)
		{
			_servicesDal.Update(entity);
		}

		public List<Service> TGetList()
		{
			return _servicesDal.GetList();
		}

		public Service TGetById(int id)
		{
			return _servicesDal.GetById(id);
		}
	}
}
