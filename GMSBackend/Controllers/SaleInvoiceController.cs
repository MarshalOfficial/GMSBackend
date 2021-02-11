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

                request.create_date = request.inv_date = DateTime.Now;
                
                if(request.sale_invoice_details == null || request.sale_invoice_details.Count == 0)
                {
                    throw new Exception("SaleInvoiceDetails is empty, can not add invoice without details(products).");
                }
                if (request.account_id == 0 || !(await _dBRepository.accounts.AnyAsync(p => p.id == request.account_id)))
                {
                    throw new Exception("Customer is not valid, check AccountID value plz.");
                }
                request.price = request.sale_invoice_details.Sum(l => l.price * l.qty);
                request.reduction = request.sale_invoice_details.Sum(l => l.reduction_price * l.qty);

                await _dBRepository.sale_invoice_headers.AddAsync(request);
                await _dBRepository.SaveChangesAsync();

                var acctrans = new AccTransaction()
                {
                    account_id = request.account_id,
                    invoice_id = request.id,
                    account_type_id = 9,
                    is_variz = true,
                    price = request.sale_invoice_payments.Sum(l => l.price),
                    create_date = DateTime.Now,
                    description = "ثبت اتومات از فاکتور فروش"
                };
                
                ///////////////todo update customer balance
                
                await _dBRepository.acc_transactions.AddAsync(acctrans);
                await _dBRepository.SaveChangesAsync();

                return Ok(new CoreResponse() { is_success = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
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

                var query = $@"
                                select h.*,a.title as account_title, a.first_name, a.last_name,d.product_id, d.product_name, 
                                 d.qty, d.price as product_price, d.reduction_percent, d.reduction_price, d.session_qty, 
                                 d.session_reserved, d.session_used,p.sale_invoice_payment_type_id, p.price aS payment_price, 
                                 p.description,pt.title as payment_type_title 
                                 from public.sale_invoice_headers h 
                                 left join public.sale_invoice_details d on h.id = d.invoice_id
                                 left join public.sale_invoice_payments p on h.id = p.invoice_id
                                 left join public.sale_invoice_payment_types pt on p.sale_invoice_payment_type_id = pt.id 
                                 left join public.accounts a on h.account_id = a.Id where h.is_deleted = '0' and d.is_deleted = '0' ";
                
                var lst = await _dBDapperRepository.RunQueryAsync<SaleInvoiceReportModel>(query);               
                return Ok(new CoreResponse() { is_success = true, data = lst });
            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
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

                var obj = await _dBRepository.sale_invoice_headers.Where(l => l.id == id).FirstOrDefaultAsync();
                if (obj == null)
                {
                    throw new Exception("there is no SaleInvoice with this id that passed in.");
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

        [HttpGet("getSaleInvoicePaymentTypes")]
        public async Task<ActionResult> GetSaleInvoicePaymentTypes()    
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.sale_invoice_payment_types.AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }
    }
}
