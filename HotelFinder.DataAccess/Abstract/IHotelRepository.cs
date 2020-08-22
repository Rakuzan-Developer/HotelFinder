using System;
using System.Collections.Generic;
using System.Text;
using HotelFinder.Entities;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IHotelRepository
    {
       List<Hotel> GetAllHotels();

       Hotel GetHotelById(int id);

       Hotel CreateHotel(Hotel hotel);

       Hotel UpdateHotel(Hotel hotel);

       void DeleteHotel(int id);

    }
}
