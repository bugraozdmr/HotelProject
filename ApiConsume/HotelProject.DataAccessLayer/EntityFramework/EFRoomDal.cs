﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
	public class EFRoomDal : GenericRepository<Room>, IRoomDal
	{
		// implement sınıf ctor içinde parametre almış o burda tanımlanmalı diyor.
		public EFRoomDal(Context context) : base(context)
		{
			
		}
	}
}
