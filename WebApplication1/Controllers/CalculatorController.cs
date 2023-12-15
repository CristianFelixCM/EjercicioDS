using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calculator;

namespace bdd.workshop.calculator.web.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Operate(Models.Calculator calculator)
        {
            ViewData["a"] = calculator.A.TheNumber;
            ViewData["result"] = Operator.raiz(calculator.A.TheNumber);
            return View();
        }
    }
}
