using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Description;
using WsBVRD;

namespace WsBVRD
{
    public class VOrdenesFirmePropiasController : ApiController
    {
        private BIEntities db = new BIEntities(); 
        [ResponseType(typeof(VOrdenesFirmePropias))]
        public IHttpActionResult GetvConsultaOrdenesFirmePropias(string token)
        {
            using (BIEntities db1 = new BIEntities())
            {
                DataTable dtToken = ConvertToDatatable(db1.WS_VALIDARTOKEN(token.ToString(), 4).ToList());

                if (dtToken.Rows[0]["TOKEN"].ToString() == "0")
                {
                    return Ok(dtToken.Rows[0]["USUARIO"].ToString());
                } 
                else
                {
                    string entidad = dtToken.Rows[0]["NOMBREENTIDADID"].ToString();
                    return Ok(db.VOrdenesFirmePropias.Where(x => x.PuestodeBolsa == entidad));
                }
            }
        }

        private static DataTable ConvertToDatatable<T>(List<T> data)
        {
            System.ComponentModel.PropertyDescriptorCollection props = System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                System.ComponentModel.PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        /*
        // GET: VOrdenesFirmePropias
        public ActionResult Index()
        {
            return View(db.VOrdenesFirmePropias.ToList());
        }
        */
        /*
        // GET: VOrdenesFirmePropias/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOrdenesFirmePropias vOrdenesFirmePropias = db.VOrdenesFirmePropias.Find(id);
            if (vOrdenesFirmePropias == null)
            {
                return HttpNotFound();
            }
            return View(vOrdenesFirmePropias);
        }
        */
        /*
        // GET: VOrdenesFirmePropias/Create
        public ActionResult Create()
        {
            return View();
        }
        */
        /*
        // POST: VOrdenesFirmePropias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nemotecnico,ISIN,MonedaLiquidacion,NominalUnitario,TasaCupon,FechaPostura,HoraPostura,ValorNominal,ValorTransado,Precio,Rendimiento,HoraUltimaModificacion,PuestodeBolsa,Secuencia,CODRUEDA,PosicionCompraVenta,Duracion,PlazoLiquidacion,FechaLiquidacion,NroOperacionVinculada")] VOrdenesFirmePropias vOrdenesFirmePropias)
        {
            if (ModelState.IsValid)
            {
                db.VOrdenesFirmePropias.Add(vOrdenesFirmePropias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vOrdenesFirmePropias);
        }
      */
        /*
        // GET: VOrdenesFirmePropias/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOrdenesFirmePropias vOrdenesFirmePropias = db.VOrdenesFirmePropias.Find(id);
            if (vOrdenesFirmePropias == null)
            {
                return HttpNotFound();
            }
            return View(vOrdenesFirmePropias);
        }
        */
        /*
        // POST: VOrdenesFirmePropias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        */
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nemotecnico,ISIN,MonedaLiquidacion,NominalUnitario,TasaCupon,FechaPostura,HoraPostura,ValorNominal,ValorTransado,Precio,Rendimiento,HoraUltimaModificacion,PuestodeBolsa,Secuencia,CODRUEDA,PosicionCompraVenta,Duracion,PlazoLiquidacion,FechaLiquidacion,NroOperacionVinculada")] VOrdenesFirmePropias vOrdenesFirmePropias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vOrdenesFirmePropias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vOrdenesFirmePropias);
        }
   */
        /*
        // GET: VOrdenesFirmePropias/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOrdenesFirmePropias vOrdenesFirmePropias = db.VOrdenesFirmePropias.Find(id);
            if (vOrdenesFirmePropias == null)
            {
                return HttpNotFound();
            }
            return View(vOrdenesFirmePropias);
        }
        */
        /*
                // POST: VOrdenesFirmePropias/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public ActionResult DeleteConfirmed(decimal id)
                {
                    VOrdenesFirmePropias vOrdenesFirmePropias = db.VOrdenesFirmePropias.Find(id);
                    db.VOrdenesFirmePropias.Remove(vOrdenesFirmePropias);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
