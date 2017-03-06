using MerchantWebApi.Models;
using MerchantWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantWebApi.Repositories
{
    public class MerchantDetailRepo : IMerchantDetailRepo
    {
        MerchantDBEntities dbContext;
        public void AddMerchantDetail(MerchantDetailWithAddress mdwa)
        {
            try
            {

                if (mdwa != null)
                {
                    var merchantDet = new MerchantDetail()
                    {
                        display_name = mdwa.display_name,
                        registered_name = mdwa.registered_name,
                        email = mdwa.email,
                        phone = mdwa.phone,
                        merchant_id = mdwa.merchant_id,
                        web_url = mdwa.web_url,
                        date_created = mdwa.date_created,
                        date_modified = null,
                        logo = mdwa.logo,
                        status = mdwa.status
                    };
                    var addressItemVar = new addressItem()
                    {
                        country = mdwa.country,
                        state = mdwa.state,
                        postcode = mdwa.postcode,
                        suburb = mdwa.suburb,
                        address1 = mdwa.address1,
                        merchantDetail_Id = merchantDet.Id
                    };
                    using (dbContext = new MerchantDBEntities())
                    {
                        dbContext.Database.Log = Console.WriteLine;
                        dbContext.MerchantDetails.Add(merchantDet);
                        merchantDet.addressItems.Add(addressItemVar);
                        dbContext.SaveChanges();
                    } 
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void DeleteMerchantDetail(int merchantDetailId)
        {
           try
            {
                using (var dbContext = new MerchantDBEntities())
                {
                    dbContext.Database.Log = Console.WriteLine;
                    var delMerchantItems = dbContext.MerchantDetails.FirstOrDefault(m => m.merchant_id == merchantDetailId);

                    if (delMerchantItems != null)
                    { 
                        var delAddressItem = dbContext.addressItems.FirstOrDefault(a => a.merchantDetail_Id == delMerchantItems.Id);
                        dbContext.MerchantDetails.Remove(delMerchantItems);
                        if(delAddressItem != null)
                        dbContext.addressItems.Remove(delAddressItem);
                    }
                    dbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public IEnumerable<MerchantDetail> GetActiveMerchantDetails()
        {
            List<MerchantDetail> mdwaList = null;
            try
            {
                using (dbContext = new MerchantDBEntities())
                {
                    mdwaList = new List<MerchantDetail>();
                    mdwaList = dbContext.MerchantDetails.Where(m => m.status == "active").ToList();

                }
            }
            catch(Exception ex)
            {
                
            }
            return mdwaList;
            
        }

        public IEnumerable<MerchantDetailWithAddress> GetAllMerchantDetails()
        {
            List<MerchantDetailWithAddress> mdwaList = null;
            try
            {
                using (dbContext = new MerchantDBEntities())
                {
                    mdwaList = new List<MerchantDetailWithAddress>();
                    mdwaList = ( from m in dbContext.MerchantDetails
                                         join a in dbContext.addressItems on m.Id equals a.merchantDetail_Id
                                         select ( new MerchantDetailWithAddress()
                                         {
                                             display_name = m.display_name,
                                             registered_name = m.registered_name,
                                             email = m.email,
                                             phone =m.phone,
                                             web_url = m.web_url,
                                             merchant_id = m.merchant_id,
                                             date_created = m.date_created,
                                             date_modified = m.date_modified,
                                             logo = m.logo,
                                             country = a.country,
                                             state = a.state,
                                             postcode = a.postcode,
                                             suburb = a.suburb,
                                             address1 = a.address1,
                                             merchantDetail_Id = a.merchantDetail_Id

                                         })).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return mdwaList;
        }

        public MerchantDetail GetMerchantDetailById(int merchantDetailId)
        {
            MerchantDetail merchantDetail = null;
            try
            {
                using (dbContext = new MerchantDBEntities())
                {
                    merchantDetail = new MerchantDetail();
                    merchantDetail = dbContext.MerchantDetails.FirstOrDefault(m => m.merchant_id == merchantDetailId); 
                    //merchantDetail = from m in dbContext.MerchantDetails
                    //                 join a in dbContext.addressItems
                    //                 on m.Id equals a.merchantDetail_Id
                    //                 where m.merchant_id == merchantDetailId
                    //                 select (new MerchantDetailWithAddress()
                    //                 {

                    //                 });
                }
            }
            catch (Exception ex)
            {

            }
            return merchantDetail;
        }

        public void UpadateMerchantDetail(MerchantDetail merchantDetail)
        {
            MerchantDetail entity;
            using (var dbContext = new MerchantDBEntities())
            {
                entity = dbContext.MerchantDetails.Find(merchantDetail.Id);
            }
            if(entity != null )
            {
                entity.status = "Inactive";
            }
            using (var dbContext = new MerchantDBEntities())
            {
                dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                dbContext.SaveChanges();
            }
        }
    }
}