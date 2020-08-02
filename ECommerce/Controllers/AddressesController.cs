using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ECommerce.HelperClasses;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class AddressesController : ApiController
    {
        private ECommerceEntities db = new ECommerceEntities();

        // GET: api/Addresses
        [HttpGet]
        [Route("api/GetAddresses")]
        public IHttpActionResult GetAddresses()
        {
          try
          {
            List<Address> addressList = new List<Address>();
            var ListOfAddresses = (from a in db.Addresses
                                  select new
                                  {
                                    a.Address_ID, a.User_ID, a.Door, a.Street1, a.Street2, a.Area, a.City, a.State,
                                    a.Pincode, a.Contact, a.AlternateContact
                                  });
            return Ok(ListOfAddresses.ToList());
          }

          catch (Exception e)
          {
            LogFile.WriteLog(e);
            return BadRequest();
          }
        }


        [HttpGet]
        [Route("api/GetAddresses/{id}")]
        public IHttpActionResult GetAddressesByID(long id)
        {
          try
          {
            List<Address> addressList = new List<Address>();
            var ListOfAddresses = (from a in db.Addresses.Where(ad => ad.Address_ID == id)
                                   select new
                                   {
                                     a.Address_ID,
                                     a.User_ID,
                                     a.Door,
                                     a.Street1,
                                     a.Street2,
                                     a.Area,
                                     a.City,
                                     a.State,
                                     a.Pincode,
                                     a.Contact,
                                     a.AlternateContact
                                   });
            return Ok(ListOfAddresses.ToList());
          }

          catch (Exception e)
          {
            LogFile.WriteLog(e);
            return BadRequest();
          }
        }

    // PUT: api/Addresses/5
    [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(long id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.Address_ID)
            {
                return BadRequest();
            }

            db.Entry(address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(address);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = address.Address_ID }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(long id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            db.SaveChanges();

            return Ok(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressExists(long id)
        {
            return db.Addresses.Count(e => e.Address_ID == id) > 0;
        }
    }
}