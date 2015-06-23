using LojaFantasias.Data;
using LojaFantasias.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaFantasias.UI.Controllers
{
    public class FantasiasController : Controller
    {
        // GET: Fantasias
        public ActionResult Index(string txtbuscar)
        {
            ViewBag.Categorias = new SelectList(CategoriasRepo.Get(), "id_categoria", "nome_cat");

            List<Fantasias> lista;
            if (txtbuscar == null)
                lista = FantasiasRepo.Get();
            else
                lista = FantasiasRepo.BuscarFantasiaNome(txtbuscar);
            return View(lista);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form, string txtbuscar)
        {
            ViewBag.Categorias = new SelectList(CategoriasRepo.Get(), "id_categoria", "nome_cat");
            int id = 0;
            List<Fantasias> lista = new List<Fantasias>();
            if (txtbuscar == null)
            {
                id = int.Parse(form["Categorias"]);
                lista = FantasiasRepo.BuscarFantasiaCategoria(id);
            }
            else
            {
                lista = FantasiasRepo.BuscarFantasiaNome(txtbuscar);
            }            
            return View(lista);
        }

        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList(CategoriasRepo.Get(), "id_categoria", "nome_cat");
            ViewBag.Fornecedores = new SelectList(FornecedoresRepo.Get(), "id_fornecedor", "nome_forn");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Fantasias Fantasia)
        {
            FantasiasRepo.Create(Fantasia);
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Edit(int id, Fantasias Fantasia)
        {
            FantasiasRepo.Edit(id, Fantasia);
            return RedirectToAction("index");
        }

        public ActionResult Edit()
        {
            ViewBag.Categorias = new SelectList(CategoriasRepo.Get(), "id_categoria", "nome_cat");
            ViewBag.Fornecedores = new SelectList(FornecedoresRepo.Get(), "id_fornecedor", "nome_forn");
            return View();
        }

        public ActionResult Delete(int id)
        {
            FantasiasRepo.Delete(id);
            return RedirectToAction("index");
        }
    }
}
