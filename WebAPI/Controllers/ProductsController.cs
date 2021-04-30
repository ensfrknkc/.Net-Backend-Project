using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //Attrıbute 
    public class ProductsController : ControllerBase
    {
        //Loosely coupled (bagımlılıgı var ama daha hafıf)
        IProductService _productService; //naming convertion

        //IoC Container -- Inversion of Control  (bir containere a bazı new lemeler verirsin gerekli yerlerde hep onu kullanırsın)
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain (bagımlılık zincirinden uzak dur) new lemeden kacın somut sınıflardan kacın
            var result = _productService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
            
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getallbycategoryid")]
        public IActionResult GetAllByCategoryId(int id)
        {
            var result = _productService.GetAllByCategoryId(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Succes)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
