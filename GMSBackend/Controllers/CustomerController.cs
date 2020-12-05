using GMSBackend.Entities;
using GMSBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        DBRepository _dBRepository;

        public CustomerController(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        [HttpPost("addcustomer")]
        [Authorize]
        public ActionResult AddCustomer([FromBody] Account request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            request.CreateDate = DateTime.Now;
            request.JoinDate = DateTime.Now;
            request.AccountTypeId = 1; // 1 is for customer
            //request.MembershipJoinTypeId = request.JobInfoId = null;
            request.AccountType = null;
            request.JobInfo = null;
            request.MembershipJoinType = null;
            _dBRepository.Accounts.Add(request);
            _dBRepository.SaveChanges();

            return Ok(request);
        }
    }
}
