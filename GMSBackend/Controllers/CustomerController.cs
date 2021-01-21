using AutoMapper;
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
        private DBRepository _dBRepository;

        #region [Customer]
        public CustomerController(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        [HttpPost("addCustomer")]        
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
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }


        [HttpGet("getJobInfos")]        
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
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }

        [HttpGet("getMembershipJoinTypes")]        
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
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }


        [HttpGet("getCustomers")]        
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
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }

        
        [HttpGet("getCustomer")]        
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
                return Ok(new CoreResponse() { isSuccess = false, data = null,devMessage=ex.Message });
            }
        }

        [HttpPut("updateCustomer")]        
        public async Task<ActionResult> UpdateCustomer([FromBody] Account customer) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var cus = await _dBRepository.Accounts.Where(l => l.Id == customer.Id).FirstOrDefaultAsync();
                if (cus == null)
                {
                    throw new Exception("there is no customer with this id that passed in.");
                }

                //todo functional below code with extension method
                var mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Account, Account>();
                }));
                mapper.Map(customer, cus);

                await _dBRepository.SaveChangesAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = cus });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }
        #endregion

        #region [ClientPeriodicCheckup]

        [HttpPost("addCheckup")]        
        public async Task<ActionResult> AddClientCheckup([FromBody] ClientPeriodicCheckUp request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                request.CreateDate = DateTime.Now;
                request.IsDeleted = false;

                if (!await _dBRepository.Accounts.AnyAsync(p => p.Id == request.AccountID))
                    throw new Exception("there is not any Customer with AccountID = " + request.AccountID.ToString());
                
                await _dBRepository.ClientPeriodicCheckUps.AddAsync(request);
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { isSuccess = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }

        [HttpDelete("deleteCheckup")]        
        public async Task<ActionResult> DeleteClientCheckup(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var obj = await _dBRepository.ClientPeriodicCheckUps.Where(l => l.ID == id).FirstOrDefaultAsync();
                if(obj == null)
                {
                    throw new Exception("there is no clientCheckup with this id that passed in.");
                }
                obj.IsDeleted = true;
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { isSuccess = true, data = obj });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }

        [HttpGet("getClientCheckups")]        
        public async Task<ActionResult> GetClientCheckups(long customerid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.ClientPeriodicCheckUps.Where(l => l.AccountID == customerid && l.IsDeleted == false).AsNoTracking().ToListAsync();

                var result = new List<ClientPeriodicCheckupModel>();

                var mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ClientPeriodicCheckUp, ClientPeriodicCheckupModel>();
                }));
                mapper.Map(lst, result);

                return Ok(new CoreResponse() { isSuccess = true, data = result });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }

        #endregion
    }
}
