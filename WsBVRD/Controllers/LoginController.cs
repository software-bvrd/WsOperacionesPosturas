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
using EntityState = System.Data.EntityState;

namespace WsBVRD.Controllers
{
    public class LoginController : ApiController
    {
        private BIEntities db = new BIEntities(); 

        // GET: api/vConsultaOrdenesFirmes/5
        [ResponseType(typeof(WS_AUTENTICARUSUARIO_Result))]
        /*public IHttpActionResult Login(string USUARIO,string CLAVE, int SERVICIOID)
        {
           
            //var data = db.WS_AUTENTICARUSUARIO_Result();
            WS_AUTENTICARUSUARIO_Result _AUTENTICARUSUARIO_Result = new WS_AUTENTICARUSUARIO_Result();
            var data = _AUTENTICARUSUARIO_Result(USUARIO,CLAVE,SERVICIOID);
            // db.WS_AUTENTICARUSUARIO_Result Find(id);
            _AUTENTICARUSUARIO_Result.
            if (vConsultaOrdenesFirme == null)
            {
                return NotFound();
            }

            return Ok(vConsultaOrdenesFirme);
           
        }*/

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