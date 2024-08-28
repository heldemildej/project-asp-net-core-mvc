using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SelesWebMvc.Models; // using SelesWebMvc.Models;

namespace SelesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            //Cria e instancia a lista Department
            List<Department> list = new List<Department>();
            //Criar novos Departamentos apartir da lista criada
            list.Add(new Department { Id = 1, Name = "Electronics" });
            list.Add(new Department { Id = 2, Name = "Fashion"});

            return View(list);// envia os dados da lista para a View
        }
    }
}
