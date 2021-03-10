using AutoMapper;
using GMSBackend.Entities;
using GMSBackend.Framework;
using GMSBackend.Models;
using GMSBackend.Models.pagination_reports;
using GMSBackend.Services;
using MD.PersianDateTime.Standard;
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

                var user = await _dBRepository.users.FirstOrDefaultAsync(a => a.user_name.ToLower() == User.Identity.Name.ToLower());

                var acctrans = new AccTransaction()
                {
                    account_id = request.account_id,
                    invoice_id = request.id,
                    account_type_id = 9,
                    is_variz = false,
                    price = (request.price.ToDeciaml() - request.reduction.ToDeciaml()) * -1,
                    create_date = DateTime.Now,
                    description = "ثبت اتومات از فاکتور فروش",
                    user_id = (long)(user?.id)
                };
                                                
                await _dBRepository.acc_transactions.AddAsync(acctrans);
                await _dBRepository.SaveChangesAsync();
                

                return Ok(new CoreResponse() { is_success = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }


        [HttpGet("getSaleInvoicesPaginate")]
        public async Task<ActionResult> GetSaleInvoicesPaginate(long customer_id,string mobile,string from_date,string to_date, string first_name, string last_name, int page = 1, int pagesize = 10)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var query = $@"
                                select count(1) OVER() AS row_count,h.*,a.title as account_title, a.first_name, a.last_name,d.product_id, d.product_name, 
                                 d.qty, d.price as product_price, d.reduction_percent, d.reduction_price, d.session_qty, 
                                 d.session_reserved, d.session_used,p.sale_invoice_payment_type_id, p.price aS payment_price, 
                                 p.description,pt.title as payment_type_title 
                                 from public.sale_invoice_headers h 
                                 left join public.sale_invoice_details d on h.id = d.invoice_id
                                 left join public.sale_invoice_payments p on h.id = p.invoice_id
                                 left join public.sale_invoice_payment_types pt on p.sale_invoice_payment_type_id = pt.id 
                                 left join public.accounts a on h.account_id = a.Id where h.is_deleted = '0' and d.is_deleted = '0' "
                                 + (!string.IsNullOrWhiteSpace(mobile) ? $"and a.mobile like '%{mobile}%'" : string.Empty)
                                 + (customer_id > 0 ? $"and a.id = {customer_id}" : string.Empty)
                                 + (!string.IsNullOrWhiteSpace(from_date) ? $"and h.create_date >= '{from_date.ToDateTimeStr()}'" : string.Empty)
                                 + (!string.IsNullOrWhiteSpace(to_date) ? $"and h.create_date <= '{to_date.ToDateTimeStr()}'" : string.Empty)
                                 + (!string.IsNullOrWhiteSpace(first_name) ? $"and a.first_name like '%{first_name}%'" : string.Empty)
                                 + (!string.IsNullOrWhiteSpace(last_name) ? $"and a.last_name like '%{last_name}%'" : string.Empty)
                                 + @$"ORDER BY id 
                                   LIMIT {pagesize}
                                   OFFSET({pagesize}*({page}-1)) ";
                                                
                var lst = await _dBDapperRepository.RunQueryAsync<SaleInvoiceReportPaginateModel>(query);               
                return Ok(new CoreResponse() { is_success = true, data = lst });
            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        [HttpGet("getSaleInvoices")]
        public async Task<ActionResult> GetSaleInvoices(long customer_id, string mobile, string from_date, string to_date, string first_name, string last_name)
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
                                 left join public.accounts a on h.account_id = a.Id where h.is_deleted = '0' and d.is_deleted = '0' "
                                 + (!string.IsNullOrWhiteSpace(mobile) ? $"and a.mobile like '%{mobile}%'" : string.Empty)
                                 + (customer_id > 0 ? $"and a.id = {customer_id}" : string.Empty)
                                 + (!string.IsNullOrWhiteSpace(from_date) ? $"and h.create_date >= '{from_date.ToDateTimeStr()}'" : string.Empty)
                                 + (!string.IsNullOrWhiteSpace(to_date) ? $"and h.create_date <= '{to_date.ToDateTimeStr()}'" : string.Empty)
                                 + (!string.IsNullOrWhiteSpace(first_name) ? $"and a.first_name like '%{first_name}%'" : string.Empty)
                                 + (!string.IsNullOrWhiteSpace(last_name) ? $"and a.last_name like '%{last_name}%'" : string.Empty);

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


                await _dBDapperRepository.RunQueryScalar(@$"update public.acc_transactions set is_deleted = '1',deleted_date=now() where invoice_id = {id}");
                
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


        [HttpGet("get_sale_invoice_remain_price")]
        public async Task<ActionResult> GetSaleInvoiceRemainPrice(long invoice_id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var price = await _dBDapperRepository.RunQueryScalar<decimal>(@$"select abs(sum(COALESCE(price,0))) from public.acc_transactions where invoice_id={invoice_id}");

                return Ok(new CoreResponse() { is_success = true, data = price });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }
    }
}
