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
    public class vConsultaOrdenesFirmesController : ApiController
    {
        private BIEntities db = new BIEntities();

        // GET: api/vConsultaOrdenesFirmes  
        /*
        public IQueryable<vConsultaOrdenesFirme> GetvConsultaOrdenesFirme()
        { 
            return db.vConsultaOrdenesFirme;
        }*/

        [ResponseType(typeof(vConsultaOrdenesFirme))]
        public IHttpActionResult GetvConsultaOrdenesFirme(string token)
        {
            //vConsultaOrdenesFirme vConsultaOrdenesFirme = db.vConsultaOrdenesFirme.Find(id);
            //vConsultaOrdenesFirme vConsultaOrdenesFirme = db.Set(vConsultaOrdenesFirme).;
            using (BIEntities db1 = new BIEntities())
            {
              DataTable  dtToken = ConvertToDatatable(db1.WS_VALIDARTOKEN(token.ToString(), 1).ToList());

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
                return Ok(db.vConsultaOrdenesFirme);
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
        [ResponseType(typeof(vConsultaOrdenesFirme))]
        public IHttpActionResult GetvUsuarios(string token)
        {
            var autentificar = db.WS_AUTENTICARUSUARIO(usuario, clave, servicioid).ToList();
            if (autentificar.Count == 0)
            {
                return Ok("ERROR: USUARIO o CONTRASEÑA INVALIDA, VERIFIQUE");  //NotFound();
            }
            else
                return db.vConsultaOrdenesFirme;
        }
        */

        /*
        // GET: api/vConsultaOrdenesFirmes/5
        [ResponseType(typeof(vConsultaOrdenesFirme))]
        public IHttpActionResult GetvConsultaOrdenesFirme(string id)
        {
            vConsultaOrdenesFirme vConsultaOrdenesFirme = db.vConsultaOrdenesFirme.Find(id);
            if (vConsultaOrdenesFirme == null)
            {
                return NotFound();
            }

            return Ok(vConsultaOrdenesFirme);
        }

        // PUT: api/vConsultaOrdenesFirmes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvConsultaOrdenesFirme(string id, vConsultaOrdenesFirme vConsultaOrdenesFirme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vConsultaOrdenesFirme.PosicionCompraVenta)
            {
                return BadRequest();
            }

            db.Entry(vConsultaOrdenesFirme).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vConsultaOrdenesFirmeExists(id))
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

        // POST: api/vConsultaOrdenesFirmes
        [ResponseType(typeof(vConsultaOrdenesFirme))]
        public IHttpActionResult PostvConsultaOrdenesFirme(vConsultaOrdenesFirme vConsultaOrdenesFirme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vConsultaOrdenesFirme.Add(vConsultaOrdenesFirme);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vConsultaOrdenesFirmeExists(vConsultaOrdenesFirme.PosicionCompraVenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vConsultaOrdenesFirme.PosicionCompraVenta }, vConsultaOrdenesFirme);
        }

        // DELETE: api/vConsultaOrdenesFirmes/5
        [ResponseType(typeof(vConsultaOrdenesFirme))]
        public IHttpActionResult DeletevConsultaOrdenesFirme(string id)
        {
            vConsultaOrdenesFirme vConsultaOrdenesFirme = db.vConsultaOrdenesFirme.Find(id);
            if (vConsultaOrdenesFirme == null)
            {
                return NotFound();
            }

            db.vConsultaOrdenesFirme.Remove(vConsultaOrdenesFirme);
            db.SaveChanges();

            return Ok(vConsultaOrdenesFirme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vConsultaOrdenesFirmeExists(string id)
        {
            return db.vConsultaOrdenesFirme.Count(e => e.PosicionCompraVenta == id) > 0;
        }
        */
    }
}