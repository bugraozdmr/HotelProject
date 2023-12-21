using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
	public interface IBookingDal : IGenericDal<Booking>
	{
		void BookingStatusChangeApproved(Booking booking);

		void BookingStatusChangeApproved2(int id);
	}
}
