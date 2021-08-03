using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response; //not to pass something generic so create the responsedto
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;

            }
            catch (Exception kostas)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { kostas.ToString() };
            }
            return _response;

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
               ProductDto productDtos = await _productRepository.GetProductById(id);
                _response.Result = productDtos;

            }
            catch (Exception kostas)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { kostas.ToString() };
            }
            return _response;

        }



        [HttpPost]
         public async Task<object> Post(ProductDto productDto)
         {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;

            }
            catch (Exception kostas)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() {kostas.ToString()};
            }
            return _response;

         }



        [HttpPut]
        public async Task<object> Put(ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;

            }
            catch (Exception kostas)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { kostas.ToString() };
            }
            return _response;

        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool  isSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = isSuccess;

            }
            catch (Exception kostas)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { kostas.ToString() };
            }
            return _response;

        }



    }
}