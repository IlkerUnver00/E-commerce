using Basecore.Model.Constants;
using Eticaret.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eticaret.Api.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {
        private readonly IProductRepository productRepo;
        public ProductController(IProductRepository pRepo)
        {
            productRepo = pRepo;
        }

        [HttpGet, Route("list")]
        public HttpResponseMessage GetProducts()
        {
            var result = productRepo.GetList();
            HttpResponseMessage message = null;
            switch (result.Status)
            {
                case ResultStatus.NotFound:
                    message = Request.CreateErrorResponse(HttpStatusCode.NotFound, new Exception("Ürünler bulunamadı"));
                    break;
                case ResultStatus.Success:
                    message = Request.CreateResponse(HttpStatusCode.OK, result.Data);
                    break;
                case ResultStatus.Error:
                    message = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception(result.Message));
                    break;
                case ResultStatus.Warning:

                    break;
                case ResultStatus.Info:

                    break;
            }
            return message;
        }


        [HttpGet, Route("")]
        public HttpResponseMessage Get(string productid)
        {
            var result = productRepo.Get(x => x.Id == productid);
            HttpResponseMessage message = null;
            switch (result.Status)
            {
                case ResultStatus.NotFound:
                    message = Request.CreateErrorResponse(HttpStatusCode.NotFound, new Exception("Ürün bulunamadı"));
                    break;
                case ResultStatus.Success:
                    message = Request.CreateResponse(HttpStatusCode.OK, result.Data);
                    break;
                case ResultStatus.Error:
                    message = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception(result.Message));
                    break;
                case ResultStatus.Warning:

                    break;
                case ResultStatus.Info:

                    break;
            }
            return message;
        }
    }
    
}
