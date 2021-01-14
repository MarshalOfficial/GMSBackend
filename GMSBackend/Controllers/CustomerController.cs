using GMSBackend.Entities;
using GMSBackend.Models;
using GMSBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("addCustomer")]
        [Authorize]
        public async Task<ActionResult> AddCustomer([FromBody] Account request)
        {
           try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                request.CreateDate = DateTime.Now;
                request.JoinDate = DateTime.Now;
                request.AccountTypeId = 1; 
                await _dBRepository.Accounts.AddAsync(request);
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { isSuccess = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = true, data = null, devMessage = ex.Message });
            }
        }


        [HttpGet("getJobInfos")]
        [Authorize]
        public async Task<ActionResult> GetJobInfos()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.JobInfos.AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = true, data = null, devMessage = ex.Message });
            }
        }

        [HttpGet("getMembershipJoinTypes")]
        [Authorize]
        public async Task<ActionResult> GetMembershipJoinTypes()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.MembershipJoinTypes.AsNoTracking().ToListAsync(); 

                return Ok(new CoreResponse() { isSuccess = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = true, data = null, devMessage = ex.Message });
            }
        }


        [HttpGet("getCustomers")]
        [Authorize]
        public async Task<ActionResult> GetCustomers()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.Accounts.Where(l => l.AccountTypeId == 1).AsNoTracking().ToListAsync();
                
                return Ok(new CoreResponse() { isSuccess = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = true, data = null, devMessage = ex.Message });
            }
        }

        
        [HttpGet("getCustomer")]
        [Authorize]
        public async Task<ActionResult> GetCustomer(long ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var cus = await _dBRepository.Accounts.Where(l => l.Id == ID).AsNoTracking().FirstOrDefaultAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = cus });
                
            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = true, data = null,devMessage=ex.Message });
            }
        }

    }
}
