using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MerchantWebApi.Models;
using MerchantWebApi.Repositories;

namespace MerchantWebApi.Controllers
{
   
    public class MerchantController : ApiController
    {
        private IMerchantDetailRepo _merchantDetailRepo;
        public MerchantController(IMerchantDetailRepo merchantDetailRepo)
        {
            _merchantDetailRepo = merchantDetailRepo;
        }
        [HttpPost]
        public void Post(MerchantDetailWithAddress mdwa)
        {
            _merchantDetailRepo.AddMerchantDetail(mdwa);
        }
        [HttpDelete]
        public void Delete(int merchantDetailId)
        {
            _merchantDetailRepo.DeleteMerchantDetail(merchantDetailId);
        }
        [HttpGet]
        [Route("api/merchant/active")]
        public IEnumerable<MerchantDetail> GetActiveMerchantDetails()
        {
            return _merchantDetailRepo.GetActiveMerchantDetails();
        }
        [HttpGet]
        [Route("api/merchant/all")]
        public IEnumerable<MerchantDetailWithAddress> GetAllMerchantDetails()
        {
            return _merchantDetailRepo.GetAllMerchantDetails();
        }

        public MerchantDetail GetMerchantDetailById(int id)
        {
            return _merchantDetailRepo.GetMerchantDetailById(id);
        }
        public void Put(MerchantDetail merchantDetail)
        {
            _merchantDetailRepo.UpadateMerchantDetail(merchantDetail);
        }
    }
}
