using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WsBVRD;
using EntityState = System.Data.EntityState;

namespace WsBVRD.Controllers
{
    public class vConsultaEmisionesWEBController : ApiController
    {
        private BIEntities db = new BIEntities();

        // GET: api/vConsultaEmisionesWEB
        /*
        public IQueryable<vConsultaEmisionesWEB> GetvConsultaEmisionesWEB()
        {
            return db.vConsultaEmisionesWEB;
        }

        // GET: api/vConsultaEmisionesWEB/5
        [ResponseType(typeof(vConsultaEmisionesWEB))]
        public IHttpActionResult GetvConsultaEmisionesWEB(decimal id)
        {
            vConsultaEmisionesWEB vConsultaEmisionesWEB = db.vConsultaEmisionesWEB.Find(id);
            if (vConsultaEmisionesWEB == null)
            {
                return NotFound();
            }

            return Ok(vConsultaEmisionesWEB);
        }
        */

        [ResponseType(typeof(vConsultaEmisionesWEB))]
        public IHttpActionResult GetvConsultaEmisionesWEB(string token)
        {
            //vConsultaOrdenesFirme vConsultaOrdenesFirme = db.vConsultaOrdenesFirme.Find(id);
            //vConsultaOrdenesFirme vConsultaOrdenesFirme = db.Set(vConsultaOrdenesFirme).;
            using (BIEntities db1 = new BIEntities())
            {
                DataTable dtToken = ConvertToDatatable(db1.WS_VALIDARTOKEN(token.ToString(), 3).ToList());

                if (dtToken.Rows[0]["TOKEN"].ToString() == "0")
                {
                    return Ok(dtToken.Rows[0]["USUARIO"].ToString());
                }

                /*var validatoken = db.WS_VALIDARTOKEN(token.ToString(), 1).ToList();
                //var validatoken1 = db.WS_VALIDARTOKEN(token.ToString(), 1);

                //DataTable dataTable = ConvertListToDataTable(validatoken); // new DataTable(typeof(WS_VALIDARTOKEN_Result)); //.ToList();  //DataTable(typeof(T).Name);
                if (validatoken.Count == 0)
                {
                      return Ok("TOKEN INVALIDO PARA EL SERVICIO: ORDENES EN FIRME");
                }*/
                else
                {
                    //IQueryable<vConsultaOrdenesFirme> query;
                    //return 
                    //query = from Subjects in db.vConsultaOrdenesFirme();

                    //return Ok(GetvConsultaOrdenesFirme());
                    return Ok(db.vConsultaEmisionesWEB);
                    //vConsultaOrdenesFirme vConsultaOrdenesFirme = db.vConsultaOrdenesFirme();
                    //return Ok(vConsultaOrdenesFirme);
                }
            }
        }



        private static DataTable ConvertToDatatable<T>(List<T> data)
        {
            System.ComponentModel.PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
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
        // PUT: api/vConsultaEmisionesWEB/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvConsultaEmisionesWEB(decimal id, vConsultaEmisionesWEB vConsultaEmisionesWEB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vConsultaEmisionesWEB.ValorNominal)
            {
                return BadRequest();
            }

            db.Entry(vConsultaEmisionesWEB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vConsultaEmisionesWEBExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        */

        /*
        // POST: api/vConsultaEmisionesWEB
        [ResponseType(typeof(vConsultaEmisionesWEB))]
        public IHttpActionResult PostvConsultaEmisionesWEB(vConsultaEmisionesWEB vConsultaEmisionesWEB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vConsultaEmisionesWEB.Add(vConsultaEmisionesWEB);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vConsultaEmisionesWEBExists(vConsultaEmisionesWEB.ValorNominal))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vConsultaEmisionesWEB.ValorNominal }, vConsultaEmisionesWEB);
        }
        */
        /*
        // DELETE: api/vConsultaEmisionesWEB/5
        [ResponseType(typeof(vConsultaEmisionesWEB))]
        public IHttpActionResult DeletevConsultaEmisionesWEB(decimal id)
        {
            vConsultaEmisionesWEB vConsultaEmisionesWEB = db.vConsultaEmisionesWEB.Find(id);
            if (vConsultaEmisionesWEB == null)
            {
                return NotFound();
            }

            db.vConsultaEmisionesWEB.Remove(vConsultaEmisionesWEB);
            db.SaveChanges();

            return Ok(vConsultaEmisionesWEB);
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

        private bool vConsultaEmisionesWEBExists(decimal id)
        {
            return db.vConsultaEmisionesWEB.Count(e => e.ValorNominal == id) > 0;
        }
    }
}