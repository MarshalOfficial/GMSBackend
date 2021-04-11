using AutoMapper;
using GMSBackend.Entities;
using GMSBackend.Framework;
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
    public class AccTransactionController : Controller
    {
        private DBRepository _dBRepository;
        private DBDapperRepository _dBDapperRepository;

        public AccTransactionController(DBRepository dBRepository, DBDapperRepository dBDapperRepository)
        {
            _dBRepository = dBRepository;
            _dBDapperRepository = dBDapperRepository;
        }

        [HttpPost("addAccTransaction")]
        public async Task<ActionResult> AddAccTransaction([FromBody] AccTransactionModel requestobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                //validate
                if (requestobj.user_id == 0)
                    throw new Exception("کاربر ثبت کننده مشخص نشده است");

                if (requestobj.price == 0)
                    throw new Exception("امکان ثبت تراکنش با مبلغ 0 وجود ندارد");

                if (requestobj.account_id == 0)
                    throw new Exception("حساب اصلی را انتخاب کنید");

                if (requestobj.account_id_fromto == 0)
                    throw new Exception("حساب از/به را انتخاب کنید");

                if (requestobj.invoice_id.HasValue && requestobj.invoice_id > 0)
                    requestobj.account_type_id = 1;
                else if (requestobj.account_type_id == 0)
                    throw new Exception("نوع حساب را مشخص کنید");


                var sanadnum = await _dBDapperRepository.GetSanadNum();

                var request = new AccTransaction
                {
                    create_date = DateTime.Now,
                    is_deleted = false,
                    user_id = requestobj.user_id,
                    account_id = requestobj.account_id,
                    description = requestobj.description,
                    account_type_id = requestobj.account_type_id.Value,
                    invoice_id = requestobj.invoice_id,
                    price = requestobj.is_daryaft ? requestobj.price : (requestobj.price * -1),
                    sanad_num = sanadnum
                };                
                await _dBRepository.acc_transactions.AddAsync(request);

                var accountfromto = await _dBRepository.accounts.AsNoTracking().FirstOrDefaultAsync(a => a.id == requestobj.account_id_fromto);
                var request1 = new AccTransaction
                {
                    create_date = DateTime.Now,
                    is_deleted = false,
                    user_id = requestobj.user_id,
                    account_id = requestobj.account_id_fromto,
                    description = requestobj.description,
                    account_type_id = accountfromto.account_type_id,
                    invoice_id = requestobj.invoice_id,
                    price = requestobj.is_daryaft ? (requestobj.price * -1) : requestobj.price,
                    sanad_num = sanadnum
                };
                await _dBRepository.acc_transactions.AddAsync(request1);

                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { is_success = true, data = new List<AccTransaction>() { request, request1 } });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        [HttpDelete("deleteAccTransaction")]
        public async Task<ActionResult> DeleteAccTransaction(long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var obj = await _dBRepository.acc_transactions.Where(l => l.id == id).FirstOrDefaultAsync();
                if (obj == null)
                {
                    throw new Exception("there is no acc transaction with this id that passed in.");
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

        [HttpGet("getAccTransactions")]
        public async Task<ActionResult> GetAccTransactions(long account_id, int account_type_id, string title, string mobile, long invoice_id, string description, string from_date, string to_date, string user_name)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var query = @$"
                                select t.*,a.first_name,a.last_name,a.title,a.mobile,at.title as account_type_title,u.user_name
                                from public.acc_transactions t
                                join public.accounts a on t.account_id = a.id
                                join public.account_types at on a.account_type_id = at.id
                                left join public.users u on t.user_id = u.id
                                    where t.is_deleted='0' "
                                    + (!string.IsNullOrWhiteSpace(title) ? $" and (a.first_name like '%{title}%' or a.last_name like '%{title}%'or a.title like '%{title}%') " : string.Empty)
                                    + (!string.IsNullOrWhiteSpace(mobile) ? $" and a.mobile like '%{mobile}%' " : string.Empty)
                                    + (!string.IsNullOrWhiteSpace(description) ? $" and t.description like '%{description}%' " : string.Empty)
                                    + (!string.IsNullOrWhiteSpace(user_name) ? $" and u.user_name like '%{user_name}%' " : string.Empty)
                                    + (!string.IsNullOrWhiteSpace(from_date) ? $"and t.create_date >= '{from_date.ToDateTimeStr()}'" : string.Empty)
                                    + (!string.IsNullOrWhiteSpace(to_date) ? $"and t.create_date <= '{to_date.ToDateTimeStr()}'" : string.Empty)
                                    + (invoice_id > 0 ? $" and t.invoice_id = {invoice_id} " : string.Empty)
                                    + (account_id > 0 ? $" and t.account_id= {account_id} " : string.Empty)
                                    + (account_type_id > 0 ? $" and t.account_type_id= {account_type_id} " : string.Empty)
                                    ;

                //var lst = await _dBRepository.acc_transactions.Where(l => l.is_deleted == false).Include(x => x.account).Include(p => p.account_type).AsNoTracking().ToListAsync();

                var lst = await _dBDapperRepository.RunQueryAsync<AccTransactionViewModel>(query);
                
                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }


        [HttpGet("getAccTransaction")]
        public async Task<ActionResult> GetAccTransaction(long ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var cus = await _dBRepository.acc_transactions.Where(l => l.id == ID).Include(x => x.account).Include(p => p.account_type).AsNoTracking().FirstOrDefaultAsync();

                var result = new AccTransactionViewModel();

                var mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AccTransaction, AccTransactionViewModel>();
                }));
                mapper.Map(cus, result);

                return Ok(new CoreResponse() { is_success = true, data = result });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }


        [HttpGet("getAccountTypes")]
        public async Task<ActionResult> GetAccountTypes()   
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.account_types.AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        [HttpGet("getAccountByType")]
        public async Task<ActionResult> GetAccountByType(int AccountTypeID)     
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.accounts.Where(p=>p.account_type_id == AccountTypeID && p.is_deleted == false).AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }
    }
}