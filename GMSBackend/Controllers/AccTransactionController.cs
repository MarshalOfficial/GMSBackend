using AutoMapper;
using GMSBackend.Entities;
using GMSBackend.Models;
using GMSBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        public AccTransactionController(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
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

                request.CreateDate = DateTime.Now;
                request.IsDeleted = false;

                if (request.UserID == 0)
                    throw new Exception("کاربر ثبت کننده مشخص نشده است");

                if (request.Price == 0)
                    throw new Exception("امکان ثبت تراکنش با مبلغ 0 وجود ندارد");

                if (request.AccountTypeID == 0)
                    throw new Exception("نوع حساب را مشخص کنید");

                if (request.AccountID == 0)
                    throw new Exception("حساب مدنظر را انتخاب کنید");


                await _dBRepository.AccTransactions.AddAsync(request);
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { isSuccess = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
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

                var obj = await _dBRepository.AccTransactions.Where(l => l.Id == id).FirstOrDefaultAsync();
                if (obj == null)
                {
                    throw new Exception("there is no acc transaction with this id that passed in.");
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

        [HttpGet("getAccTransactions")]
        public async Task<ActionResult> GetAccTransactions()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.AccTransactions.Where(l => l.IsDeleted == false).Include(x => x.Account).Include(p => p.AccountType).AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
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

                var cus = await _dBRepository.AccTransactions.Where(l => l.Id == ID).Include(x => x.Account).Include(p => p.AccountType).AsNoTracking().FirstOrDefaultAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = cus });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
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

                var lst = await _dBRepository.AccountTypes.AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
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

                var lst = await _dBRepository.Accounts.Where(p=>p.AccountTypeId == AccountTypeID && p.IsDeleted == false).AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }
    }
}