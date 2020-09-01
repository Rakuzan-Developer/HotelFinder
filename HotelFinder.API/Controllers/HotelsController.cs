using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels= await _hotelService.GetAllHotels();
            return Ok(hotels);// 200 olarak response döndür + body kısmına datayı ekle
        }

        /// <summary>
        /// Get an hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> gethotelbyıd(int id)
        {

            var hotel = await _hotelService.GetHotelById(id);
            if (hotel!=null)
            {
                
                return Ok(hotel);//200 + data döndü
            }

            return NotFound();//404
        }

        /// <summary>
        /// Get an hotel by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Gethotelbyname(string name)
        {
            var hotel = await _hotelService.GetHotelByName(name);
            if (hotel!=null)
            {
                return Ok(hotel);
            }

            return NotFound();
        }

       

        /// <summary>
        /// create an hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Hotel hotel)
        {
            
                var createdHotel= await _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get",new {id = createdHotel.Id},createdHotel);
            

            
        }

        /// <summary>
        /// update the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Hotel hotel)
        {
            if (await _hotelService.GetHotelById(hotel.Id) != null)
            {
                var upgradedHotel = await _hotelService.UpdateHotel(hotel);
                return Ok(upgradedHotel);
            }

            return NotFound();
        }


        /// <summary>
        /// delete the hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (await _hotelService.GetHotelById(id)!=null)
            {
                await _hotelService.DeleteHotel(id);
                return Ok();
            }

            return NotFound();
        }


    }
}
