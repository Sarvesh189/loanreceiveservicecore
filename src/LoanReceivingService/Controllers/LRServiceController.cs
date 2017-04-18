using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanReceivingService.Controllers
{
   [Route("api/lrservice")]
    public class LRServiceController : Controller
    {
        // GET: /<controller>/
        public async Task<string> Index()
        {
            SQSManager sqsManager = new  SQSManager();
             await sqsManager.SendMessage();
            return "OK";
        }
    }
}
