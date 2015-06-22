﻿using LojaFantasias.Data;
using LojaFantasias.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaFantasias.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            List<Categorias> lista = CategoriasRepo.Get();
            return View(lista);
        }
    }
}