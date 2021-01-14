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
    public class ProductController : Controller
    {
        private DBRepository _dBRepository;

        public ProductController(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        [HttpPost("addProduct")]
        public async Task<ActionResult> AddProduct([FromBody] ProductMain request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                request.CreateDate = DateTime.Now;
                request.IsActive = true;
                request.IsDeleted = false;
                request.CodingID = 1;

                await _dBRepository.ProductMains.AddAsync(request);
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { isSuccess = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }

        [HttpGet("getProducts")]
        public async Task<ActionResult> GetProducts()   
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.ProductMains.Where(l => l.IsDeleted == false).AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }


        [HttpGet("getProduct")]
        public async Task<ActionResult> GetProduct(long ID) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var cus = await _dBRepository.ProductMains.Where(l => l.ID == ID).AsNoTracking().FirstOrDefaultAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = cus });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }

        [HttpPut("updateProduct")]  
        public async Task<ActionResult> UpdateProduct([FromBody] ProductMain product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var obj = await _dBRepository.ProductMains.Where(l => l.ID == product.ID).FirstOrDefaultAsync();
                if (obj == null)
                {
                    throw new Exception("there is no product with this id that passed in.");
                }

                //todo functional below code with extension method
                var mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Account, Account>();
                }));
                mapper.Map(product, obj);

                await _dBRepository.SaveChangesAsync();

                return Ok(new CoreResponse() { isSuccess = true, data = obj });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { isSuccess = false, data = null, devMessage = ex.Message });
            }
        }


        [HttpDelete("deleteProduct")]   
        public async Task<ActionResult> DeleteProduct(long id)  
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var obj = await _dBRepository.ProductMains.Where(l => l.ID == id).FirstOrDefaultAsync();
                if (obj == null)
                {
                    throw new Exception("there is no product with this id that passed in.");
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
    }
}
