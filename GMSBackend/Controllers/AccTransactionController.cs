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
                var request = new AccTransaction();

                var mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AccTransactionModel, AccTransaction>();
                }));
                mapper.Map(requestobj, request);

                request.create_date = DateTime.Now;
                request.is_deleted = false;

                if (request.user_id == 0)
                    throw new Exception("کاربر ثبت کننده مشخص نشده است");

                if (request.price == 0)
                    throw new Exception("امکان ثبت تراکنش با مبلغ 0 وجود ندارد");

                if (request.account_type_id == 0)
                    throw new Exception("نوع حساب را مشخص کنید");

                if (request.account_id == 0)
                    throw new Exception("حساب مدنظر را انتخاب کنید");


                await _dBRepository.acc_transactions.AddAsync(request);
                await _dBRepository.SaveChangesAsync();

                await _dBDapperRepository.RunQueryScalar(@$"update accounts set balance = balance + {(request.is_variz ? request.price : (request.price * -1))} where id={request.account_id}");

                return Ok(new CoreResponse() { is_success = true, data = request });

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
        public async Task<ActionResult> GetAccTransactions()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.acc_transactions.Where(l => l.is_deleted == false).Include(x => x.account).Include(p => p.account_type).AsNoTracking().ToListAsync();

                var result = new List<AccTransactionViewModel>();

                var mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AccTransaction, AccTransactionViewModel>();
                }));
                mapper.Map(lst, result);

                return Ok(new CoreResponse() { is_success = true, data = result });

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