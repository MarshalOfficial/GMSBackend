﻿using AutoMapper;
using GMSBackend.Entities;
using GMSBackend.Models;
using GMSBackend.Models.pagination_reports;
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
        private DBDapperRepository _dBDapperRepository;

        #region [Customer]
        public CustomerController(DBRepository dBRepository, DBDapperRepository dBDapperRepository)
        {
            _dBRepository = dBRepository;
            _dBDapperRepository = dBDapperRepository;
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

                if (string.IsNullOrWhiteSpace(request.first_name))
                {
                    throw new Exception("first name is required");
                }
                if (string.IsNullOrWhiteSpace(request.last_name))
                {
                    throw new Exception("last name is required");
                }
                if (string.IsNullOrWhiteSpace(request.mobile))
                {
                    throw new Exception("mobile is required");
                }
                if(await _dBRepository.accounts.AnyAsync(a=>a.mobile == request.mobile))
                {
                    throw new Exception($"there is already a customer with this mobile = {request.mobile}");
                }

                request.create_date = DateTime.Now;
                request.join_date = DateTime.Now;
                request.account_type_id = 1; 
                await _dBRepository.accounts.AddAsync(request);
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { is_success = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
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

                var lst = await _dBRepository.job_infos.AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
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

                var lst = await _dBRepository.membership_join_types.AsNoTracking().ToListAsync(); 

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }


        [HttpGet("getCustomers")]        
        public async Task<ActionResult> GetCustomers(string first_name, string last_name, string mobile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var query = $@"select * from public.accounts
                                where account_type_id = 1
                                and first_name like '%{first_name}%'
                                and last_name like '%{last_name}%'
                                and mobile like '%{mobile}%'  ";

                var lst = await _dBDapperRepository.RunQueryAsync<Account>(query); //await _dBRepository.accounts.Where(l => l.account_type_id == 1).AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        [HttpGet("getCustomersCombo")]
        public async Task<ActionResult> GetCustomersCombo(string first_name, string last_name, string mobile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var query = $@"select first_name,last_name,mobile from public.accounts
                                where account_type_id = 1
                                and first_name like '%{first_name}%'
                                and last_name like '%{last_name}%'
                                and mobile like '%{mobile}%'  ";

                var lst = await _dBDapperRepository.RunQueryAsync<CustomerComboModel>(query); 

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        [HttpGet("getCustomerspaginate")]
        public async Task<ActionResult> GetCustomersPaginate(string first_name, string last_name, string mobile,int page=1,int pagesize=10)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var query = $@" select count(1) OVER() AS row_count,* 
                                from public.accounts
                                where account_type_id = 1
                                and first_name like '%{first_name}%'
                                and last_name like '%{last_name}%'
                                and mobile like '%{mobile}%'
                                ORDER BY id 
                                LIMIT {pagesize} 
                                OFFSET ({pagesize} * ({page}-1)) ";

                var lst = await _dBDapperRepository.RunQueryAsync<AccountPaginatedModel>(query);


                return Ok(new CoreResponse() { is_success = true, data = lst, total_items = lst.First()?.row_count, current_page = page, total_pages = (lst.First()?.row_count / pagesize) + 1 });
                //return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
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

                var cus = await _dBRepository.accounts.Where(l => l.id == ID).AsNoTracking().FirstOrDefaultAsync();

                return Ok(new CoreResponse() { is_success = true, data = cus });
                
            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null,dev_message=ex.Message });
            }
        }

        [HttpPut("updateCustomer")]
        public async Task<ActionResult> UpdateCustomer([FromBody] AccountUpdateModel customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var cus = await _dBRepository.accounts.Where(l => l.id == customer.id).FirstOrDefaultAsync();
                if (cus == null)
                {
                    throw new Exception("there is no customer with this id that passed in.");
                }

                cus.title = customer.title;
                cus.first_name = customer.first_name;
                cus.last_name = customer.last_name;
                cus.birth_date = customer.birth_date;
                cus.Gender = customer.Gender;
                cus.mobile = customer.mobile;
                cus.tel = customer.tel;
                cus.postal_code = customer.postal_code;
                cus.email = customer.email;
                cus.telegram = customer.telegram;
                cus.instagram = customer.instagram;
                cus.address = customer.address;
                cus.membership_join_type_id = customer.membership_join_type_id;
                cus.jobinfo_id = customer.jobinfo_id;
                cus.contract_file_path = customer.contract_file_path;

                await _dBRepository.SaveChangesAsync();

                return Ok(new CoreResponse() { is_success = true, data = cus });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
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

                request.create_date = DateTime.Now;
                request.is_deleted = false;

                if (!await _dBRepository.accounts.AnyAsync(p => p.id == request.account_id))
                    throw new Exception("there is not any Customer with AccountID = " + request.account_id.ToString());
                
                await _dBRepository.client_periodic_checkups.AddAsync(request);
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { is_success = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
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

                var obj = await _dBRepository.client_periodic_checkups.Where(l => l.id == id).FirstOrDefaultAsync();
                if(obj == null)
                {
                    throw new Exception("there is no clientCheckup with this id that passed in.");
                }
                obj.is_deleted = true;
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { is_success = true, data = obj });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
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

                var lst = await _dBRepository.client_periodic_checkups.Where(l => l.account_id == customerid && l.is_deleted == false).AsNoTracking().ToListAsync();

                var result = new List<ClientPeriodicCheckupModel>();

                var mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ClientPeriodicCheckUp, ClientPeriodicCheckupModel>();
                }));
                mapper.Map(lst, result);

                return Ok(new CoreResponse() { is_success = true, data = result });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        #endregion
    }
}
