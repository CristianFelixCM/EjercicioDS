﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calculator;
using System.Xml.Linq;

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
            ViewData["a"] = @String.Format("{0:N3}", calculator.A.TheNumber).Replace(",", ".");
            ViewData["result"] = @String.Format("{0:N3}", Operator.raiz(calculator.A.TheNumber)).Replace(",", ".");
            return View();
        }
    }
}
 