using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestfulAPITest.Models;

namespace RestfulAPITest.Controllers
{
    [ApiController]
    [Route("book/add")]    
    public class ValuesController : ControllerBase
    {
        private static Dictionary<string, Addrequest> DB = new Dictionary<string, Addrequest>();
        [HttpPost]
        public Addresponse Post([FromBody] Addrequest req)
        {
            Addresponse resp = new Addresponse();
            try
            {
                DB.Add(req.ISBN, req);
                resp.ISBN = req.ISBN;
                resp.message = "交易成功";
                resp.result = "S";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resp.ISBN = "";
                resp.message = "交易失败";
                resp.result = "F";
            }
            return resp;
        }

    }
}
