using LojaFantasias.Data;
using LojaFantasias.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LojaFantasias.Controllers
{
    public class ExemplaresController : Controller
    {
        // GET: /Exemplares/

        #region Struct

        public struct Tamanhos
        {
            public int id { get; set; }
            public string tam { get; set; }
        }

        #endregion

        #region Métodos
        private SelectList getTamanhos()
        {
            List<Tamanhos> tipo = new List<Tamanhos>
            {
               new Tamanhos() {id = 1, tam = "UN"},
               new Tamanhos() {id = 2, tam = "P"},
               new Tamanhos() {id = 3, tam = "M"},
               new Tamanhos() {id = 4, tam = "G"},
               new Tamanhos() {id = 5, tam = "GG"},
               new Tamanhos() {id = 6, tam = "EG"},
            };

            return new SelectList(tipo, "id", "tam");

        }
        #endregion 

        public ActionResult Index(string txtbuscar)
        {
            ViewBag.Tamanhos = getTamanhos();

            List<Exemplares> lista;
            if (txtbuscar == null)
                lista = ExemplaresRepo.Get();
            else
                lista = ExemplaresRepo.BuscarExemplar(txtbuscar);
            return View(lista);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form, string txtbuscar)
        {
            ViewBag.Tamanhos = getTamanhos();
            int id = 0;
            List<Exemplares> lista = new List<Exemplares>();
            if (txtbuscar == null)
            {
                id = int.Parse(form["Tamanhos"]);
                string tam = " ";
                switch (id)
                {
                    case 1: tam = "UN"; break;
                    case 2: tam = "P"; break;
                    case 3: tam = "M"; break;
                    case 4: tam = "G"; break;
                    case 5: tam = "GG"; break;
                    case 6: tam = "EG"; break;
                };
                if (tam == " ")
                    lista = ExemplaresRepo.Get();
                else
                    lista = ExemplaresRepo.BuscarExemplarTamanho(tam);
            }
            else
            {
                lista = ExemplaresRepo.BuscarExemplar(txtbuscar);
            }
            return View(lista);
        }

        public ActionResult Create()
        {
            ViewBag.Fantasias = new SelectList(FantasiasRepo.Get(), "id_fantasia", "descricao");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Exemplares Exemplares)
        {
            ExemplaresRepo.Create(Exemplares);
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Edit(int id, Exemplares Exemplares)
        {
            ExemplaresRepo.Edit(id, Exemplares);
            return RedirectToAction("index");
        }


        public ActionResult Edit()
        {
            ViewBag.Fantasias = new SelectList(FantasiasRepo.Get(), "id_fantasia", "descricao");
            return View();
        }

        public ActionResult Delete(int id)
        {
            ExemplaresRepo.Delete(id);
            return RedirectToAction("index");
        }

	}
}