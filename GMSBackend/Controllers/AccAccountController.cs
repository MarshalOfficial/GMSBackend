using AutoMapper;
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
    public class AccAccountController : Controller
    {
        private DBRepository _dBRepository;
        private DBDapperRepository _dBDapperRepository;

        
        public AccAccountController(DBRepository dBRepository, DBDapperRepository dBDapperRepository)
        {
            _dBRepository = dBRepository;
            _dBDapperRepository = dBDapperRepository;
        }

        [HttpPost("add_account")]
        public async Task<ActionResult> AddAccount([FromBody] Account request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (string.IsNullOrWhiteSpace(request.title))
                {
                    throw new Exception("first name is required");
                }

                request.create_date = DateTime.Now;
                request.join_date = DateTime.Now;
                
                await _dBRepository.accounts.AddAsync(request);
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { is_success = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        [HttpGet("get_account_types")]
        public async Task<ActionResult> GetAccountTypes()   
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.account_types.Where(a => a.id != 1).AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        [HttpPut("update_account")]
        public async Task<ActionResult> UpdateAccount([FromBody] AccountUpdateModel account)   
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (string.IsNullOrWhiteSpace(account.title))
                {
                    throw new Exception("first name is required");
                }

                var cus = await _dBRepository.accounts.Where(l => l.id == account.id).FirstOrDefaultAsync();
                if (cus == null)
                {
                    throw new Exception("there is no account with this id that passed in.");
                }


                cus.title = account.title;
                cus.first_name = account.first_name;
                cus.last_name = account.last_name;
                cus.birth_date = account.birth_date;
                cus.Gender = account.Gender;
                cus.mobile = account.mobile;
                cus.tel = account.tel;
                cus.postal_code = account.postal_code;
                cus.email = account.email;
                cus.telegram = account.telegram;
                cus.instagram = account.instagram;
                cus.address = account.address;
                cus.membership_join_type_id = account.membership_join_type_id;
                cus.jobinfo_id = account.jobinfo_id;
                cus.contract_file_path = account.contract_file_path;

                await _dBRepository.SaveChangesAsync();

                return Ok(new CoreResponse() { is_success = true, data = cus });
            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        [HttpGet("get_accounts_paginate")]
        public async Task<ActionResult> GetAccountsPaginate(string first_name, string last_name, string title, string mobile, int page = 1, int pagesize = 10)  
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var query = $@" select count(1) OVER() AS row_count,a.*,at.title as account_type_title
                                from public.accounts a 
                                join public.account_types at on a.account_type_id = at.id
                                where account_type_id != 1
                                and first_name like '%{first_name}%'
                                and last_name like '%{last_name}%'
                                and mobile like '%{mobile}%'
                                and a.title like '%{title}%'
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

        [HttpGet("get_accounts")]
        public async Task<ActionResult> GetAccounts(string first_name, string last_name, string title, string mobile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var query = $@"select a.*,at.title as account_type_title
                                from public.accounts a 
                                join public.account_types at on a.account_type_id = at.id
                                where account_type_id != 1
                                and first_name like '%{first_name}%'
                                and last_name like '%{last_name}%'
                                and mobile like '%{mobile}%'
                                and a.title like '%{title}%'";

                var lst = await _dBDapperRepository.RunQueryAsync<Account>(query); //await _dBRepository.accounts.Where(l => l.account_type_id == 1).AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

    }
}
