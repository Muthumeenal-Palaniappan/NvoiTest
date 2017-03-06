using MerchantWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantWebApi.Repositories
{
   public interface IMerchantDetailRepo
    {
        IEnumerable<MerchantDetailWithAddress> GetAllMerchantDetails();
        MerchantDetail GetMerchantDetailById(int merchantDetailId);
        IEnumerable<MerchantDetail> GetActiveMerchantDetails();
        void AddMerchantDetail(MerchantDetailWithAddress merchantDetail);
        void UpadateMerchantDetail(MerchantDetail merchantDetail);
        void DeleteMerchantDetail(int merchantDetailId);
        
    }
}
