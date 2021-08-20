using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WsBVRD;

namespace WsBVRD.Controllers
{
    public class vUsuariosController : ApiController
    {
        private BIEntities db = new BIEntities();

        // GET: api/vUsuarios
        //public IQueryable<vUsuarios>  GetvUsuarios()
        //{
        //    return db.vUsuarios1;
        //}
         
        [ResponseType(typeof(WS_AUTENTICARUSUARIO_Result))]
        public IHttpActionResult   GetvUsuarios(string usuario, string clave, int servicioid)
        {
            var autentificar = db.WS_AUTENTICARUSUARIO(usuario, clave, servicioid).ToList(); 
            if (autentificar.Count == 0)
            {  
                return Ok("ERROR: USUARIO o CONTRASEÑA INVALIDA, VERIFIQUE") ;  //NotFound();
            } 
            else
            return Ok(autentificar);
        }


        // GET: api/vUsuarios/5
        //[ResponseType(typeof(vUsuarios))]
        //public IHttpActionResult GetvUsuarios(string id)
        //{
        //    vUsuarios vUsuarios = db.vUsuarios1.Find(id);
        //    if (vUsuarios == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(vUsuarios);
        //}

        //[HttpGet, Route("api/TestProcedure/{country}")]
        /*
        [ResponseType(typeof(vUsuarios2))]
        public IHttpActionResult GetvUsuarios1(string usuario, string clave, int servicioid)
       {
           var parUSUARIO = new System.Data.SqlClient.SqlParameter
           {
               ParameterName = "@USUARIO",
               Value = usuario
           };

           var parCLAVE = new System.Data.SqlClient.SqlParameter
           {
               ParameterName = "@CLAVE",
               Value = clave
           };

           var parSERVICIOID = new System.Data.SqlClient.SqlParameter
           {
               ParameterName = "@SERVICIOID",
               Value = servicioid
           }; 
           var vUsuarios = db.Database.ExecuteSqlCommand("EXEC WS_AUTENTICARUSUARIO  @USUARIO,@CLAVE,@SERVICIOID", parUSUARIO, parCLAVE, parSERVICIOID); //.ToList();

           if (vUsuarios == null)
           {
               return NotFound();
           }

           return Ok(vUsuarios);
       } 

        // PUT: api/vUsuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvUsuarios(string id, vUsuarios vUsuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vUsuarios.NOMBRE)
            {
                return BadRequest();
            }

            db.Entry(vUsuarios).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vUsuariosExists(id))
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

        // POST: api/vUsuarios
        [ResponseType(typeof(vUsuarios))]
        public IHttpActionResult PostvUsuarios(vUsuarios vUsuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vUsuarios1.Add(vUsuarios);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vUsuariosExists(vUsuarios.NOMBRE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vUsuarios.NOMBRE }, vUsuarios);
        }

        // DELETE: api/vUsuarios/5
        [ResponseType(typeof(vUsuarios))]
        public IHttpActionResult DeletevUsuarios(string id)
        {
            vUsuarios vUsuarios = db.vUsuarios1.Find(id);
            if (vUsuarios == null)
            {
                return NotFound();
            }

            db.vUsuarios1.Remove(vUsuarios);
            db.SaveChanges();

            return Ok(vUsuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vUsuariosExists(string id)
        {
            return db.vUsuarios1.Count(e => e.NOMBRE == id) > 0;
        } 
        */
    }
}