﻿using LojaFantasias.Data;
using LojaFantasias.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaFantasias.UI.Controllers
{
    public class FornecedoresController : Controller
    {
        //
        // GET: /Fornecedores/
        
         public ActionResult Index(string txtbuscar)
         {
             List<Fornecedores> lista;
             if (txtbuscar == null)
                 lista = FornecedoresRepo.Get();
             else
                 lista = FornecedoresRepo.BuscarFornecedor(txtbuscar);
             return View(lista);
         }

         public ActionResult Create()
         {
             return View();
         }

         [HttpPost]
         public ActionResult Create(Fornecedores Fornecedor)
         {
             if (ModelState.IsValid)
             {
                 FornecedoresRepo.Create(Fornecedor);
                 return RedirectToAction("index");
             }
             else
             {
                 return View();
             }
         }
         [HttpPost]
         public ActionResult Edit(int id, Fornecedores Fornecedor)
         {
             if (ModelState.IsValid)
             {
                 FornecedoresRepo.Edit(id, Fornecedor);
                 return RedirectToAction("index");
             }
             else
             {
                 return View();
             }
         }

         public ActionResult Edit()
         {
             return View();
         }

         public ActionResult Delete(int id)
         {
             FornecedoresRepo.Delete(id);
             return RedirectToAction("index");
         }
         
    }
}