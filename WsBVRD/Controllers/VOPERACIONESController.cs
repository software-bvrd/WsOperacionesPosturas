using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WsBVRD;

namespace WsBVRD.Controllers
{
    public class VOPERACIONESController : ApiController
    {
        private BIEntities db = new BIEntities();

        //// GET: api/VOPERACIONES
        //public IQueryable<VOPERACIONES> GetVOPERACIONES()
        //{
        //    return db.VOPERACIONES;
        //}

        [ResponseType(typeof(VOPERACIONES))]
        public IHttpActionResult GetvConsultaOrdenesFirme(string token)
        {
            using (BIEntities db1 = new BIEntities())
            {
                DataTable dtToken = ConvertToDatatable(db1.WS_VALIDARTOKEN(token.ToString(), 2).ToList());

                if (dtToken.Rows[0]["TOKEN"].ToString() == "0")
                {
                    return Ok(dtToken.Rows[0]["USUARIO"].ToString());
                }

                else
                {
                    string entidad = dtToken.Rows[0]["NOMBREENTIDADID"].ToString();
                    //var data = db.VOPERACIONES.Where(x => x.PuestoComprador.Equals(dtToken.Rows[0]["TOKEN"].ToString()));
                    //return Ok(db.VOPERACIONES.Where(x => x.PuestoComprador.Equals(entidad) || (x.NombrePuestoVendedor.Equals(entidad))));
                    return Ok(db.VOPERACIONES.Where(x => x.PuestoComprador == entidad || (x.PuestoVendedor == entidad)));

                    //return Ok(data);
                    return Ok(db.VOPERACIONES);
            
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

        // GET: api/VOPERACIONES/5
        [ResponseType(typeof(VOPERACIONES))]
        public IHttpActionResult GetVOPERACIONES(long id)
        {
            VOPERACIONES vOPERACIONES = db.VOPERACIONES.Find(id);
            if (vOPERACIONES == null)
            {
                return NotFound();
            }

            return Ok(vOPERACIONES);
        }

        /*
        // PUT: api/VOPERACIONES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVOPERACIONES(long id, VOPERACIONES vOPERACIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vOPERACIONES.ID)
            {
                return BadRequest();
            }

            db.Entry(vOPERACIONES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VOPERACIONESExists(id))
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

        // POST: api/VOPERACIONES
        [ResponseType(typeof(VOPERACIONES))]
        public IHttpActionResult PostVOPERACIONES(VOPERACIONES vOPERACIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VOPERACIONES.Add(vOPERACIONES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VOPERACIONESExists(vOPERACIONES.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vOPERACIONES.ID }, vOPERACIONES);
        }

        // DELETE: api/VOPERACIONES/5
        [ResponseType(typeof(VOPERACIONES))]
        public IHttpActionResult DeleteVOPERACIONES(long id)
        {
            VOPERACIONES vOPERACIONES = db.VOPERACIONES.Find(id);
            if (vOPERACIONES == null)
            {
                return NotFound();
            }

            db.VOPERACIONES.Remove(vOPERACIONES);
            db.SaveChanges();

            return Ok(vOPERACIONES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VOPERACIONESExists(long id)
        {
            return db.VOPERACIONES.Count(e => e.ID == id) > 0;
        }
        */
    }
}