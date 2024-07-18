using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        
        public CouponAPIController(AppDbContext db){
            _db=db;
            _response=new ResponseDto();
        }

        //we have 2 endpoints
        [HttpGet]
        public ResponseDto Get(){
            try{
                IEnumerable<Coupon> objList=_db.Coupons.ToList();
                _response.Result=objList;
            }
            catch(Exception ex){
                _response.IsSuccess=false;
                _response.Message=ex.Message;
            }
            return _response;
        }
        //individual coupon based on the ID
        [HttpGet]
        //with route id will be provided
        [Route("{id:int}")]
        public ResponseDto Get(int id){
            try{
                Coupon obj=_db.Coupons.First(u=>u.CouponId==id);
                _response.Result=obj;

            }
            catch(Exception ex){
                  _response.IsSuccess=false;
                _response.Message=ex.Message;
            }
            return _response;
        }
        
    }
}