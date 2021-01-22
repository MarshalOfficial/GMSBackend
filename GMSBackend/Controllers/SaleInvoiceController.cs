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
    public class SaleInvoiceController : Controller
    {
        private DBRepository _dBRepository;
        private DBDapperRepository _dBDapperRepository;

        public SaleInvoiceController(DBRepository dBRepository,DBDapperRepository dBDapperRepository)
        {
            _dBRepository = dBRepository;
            _dBDapperRepository = dBDapperRepository;
        }


        [HttpPost("addSaleInvoice")]
        public async Task<ActionResult> AddSaleInvoice([FromBody] SaleInvoiceHeader request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                request.CreateDate = request.InvDate = DateTime.Now;
                
                if(request.SaleInvoiceDetails == null || request.SaleInvoiceDetails.Count == 0)
                {
                    throw new Exception("SaleInvoiceDetails is empty, can not add invoice without details(products).");
                }
                if (request.AccountID == 0 || !(await _dBRepository.Accounts.AnyAsync(p => p.Id == request.AccountID)))
                {
                    throw new Exception("Customer is not valid, check AccountID value plz.");
                }
                request.Price = request.SaleInvoiceDetails.Sum(l => l.Price * l.Qty);
                request.Reduction = request.SaleInvoiceDetails.Sum(l => l.Reduction_Price * l.Qty);

                await _dBRepository.SaleInvoiceHeaders.AddAsync(request);
                await _dBRepository.SaveChangesAsync();

                var acctrans = new AccTransaction()
                {
                    AccountID = request.AccountID,
                    InvoiceID = request.ID,
                    AccountTypeID = 9,
                    IsVariz = true,
                    Price = request.SaleInvoicePayments.Sum(l => l.Price),
                    CreateDate = DateTime.Now,
                    Description = "ثبت اتومات از فاکتور فروش"
                };
                
                ///////////////todo update customer balance
                
                await _dBRepository.AccTransactions.AddAsync(acctrans);
                await _dBRepository.SaveChangesAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }


        [HttpGet("getSaleInvoices")]
        public async Task<ActionResult> GetSaleInvoices()   
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var query = " " +
                    "select h.*,a.\"Title\" as \"AccountTitle\", a.\"FirstName\", a.\"LastName\",d.\"ProductID\", d.\"ProductName\", d.\"Qty\", " +
                    "d.\"Price\" as \"ProductPrice\", d.\"Reduction_Percent\", d.\"Reduction_Price\", d.\"SessionQty\", d.\"SessionReserved\", d.\"SessionUsed\",p.\"SaleInvoicePaymentTypeId\", " +
                    "p.\"Price\" aS \"paymentPrice\", p.\"Description\",pt.\"Title\" as \"PaymentTypeTitle\" " +
                    "from public.\"SaleInvoiceHeaders\" h " +
                    "left join public.\"SaleInvoiceDetails\" d on h.\"ID\" = d.\"InvoiceID\" " +
                    "left join public.\"SaleInvoicePayments\" p on h.\"ID\" = p.\"InvoiceID\" " +
                    "left join public.\"SaleInvoicePaymentTypes\" pt on p.\"SaleInvoicePaymentTypeId\" = pt.\"Id\" " +
                    "left join public.\"Accounts\" a on h.\"AccountID\" = a.\"Id\" " +
                    "where h.\"IsDeleted\" = '0' and d.\"IsDeleted\" = '0' ";
                
                var lst = await _dBDapperRepository.RunQueryAsync<SaleInvoiceReportModel>(query);               
                return Ok(new CoreResponse() { isSuccess = true, data = lst });
            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }

        [HttpDelete("deleteSaleInvoice")]
        public async Task<ActionResult> DeleteSaleInvoice(long id)
        {   
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var obj = await _dBRepository.SaleInvoiceHeaders.Where(l => l.ID == id).FirstOrDefaultAsync();
                if (obj == null)
                {
                    throw new Exception("there is no SaleInvoice with this id that passed in.");
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

        [HttpGet("getSaleInvoicePaymentTypes")]
        public async Task<ActionResult> GetSaleInvoicePaymentTypes()    
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.SaleInvoicePaymentTypes.AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }
    }
}
