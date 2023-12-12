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
	public class TestimonialManager : ITestimonialService
	{
		private readonly ITestimonialDal _testimonialDal;

		// testimonialDal seslencek class olarak -- bağlantılı bunlar -- şirket mimarisi hep aynı
		public TestimonialManager(ITestimonialDal testimonialDal)
		{
			_testimonialDal = testimonialDal;
		}

		public void TInsert(Testimonial entity)
		{
			_testimonialDal.Insert(entity);
		}

		public void TDelete(Testimonial entity)
		{
			_testimonialDal.Delete(entity);
		}

		public void TUpdate(Testimonial entity)
		{
			_testimonialDal.Update(entity);
		}

		public List<Testimonial> TGetList()
		{
			return _testimonialDal.GetList();
		}

		public Testimonial TGetById(int id)
		{
			return _testimonialDal.GetById(id);
		}
	}
}
