using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using student_apis.Models;

namespace student_apis.Controllers
{
    public class studentController : ApiController
    {
        NPMDevDBEntities npm = new NPMDevDBEntities();
        [HttpPost]
        public HttpResponseMessage Mode(STUDENT1 obj)
        {    
            try
            { var check = npm.STUDENT1.FirstOrDefault(e => e.STD_ID == obj.STD_ID);

                if (check != null)
                {
                    npm.Entry(check).CurrentValues.SetValues(obj);
                    npm.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "successful");

                }
                else
                {
                    npm.STUDENT1.Add(obj);
                    npm.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "successful");


                }
                   


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "invalid");


            }


        }
        [HttpGet]
        public HttpResponseMessage get_method(int id)
        {
            try
            {

                if (id != 0)
                {

                    var data = npm.STUDENT1.Where(e => e.STD_ID == id).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                   
                }
                else
                {
                    var data = npm.STUDENT1.ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "invalid");


            }


        }


        [HttpPut]
        public HttpResponseMessage update_method(STUDENT1 obj)
        {
            try
            {
                var data = npm.STUDENT1.Find(obj.STD_ID);
                if (data != null)
                {
                    npm.Entry(data).CurrentValues.SetValues(obj);
                    npm.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "successful");


                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "failed");


                }
                return Request.CreateResponse(HttpStatusCode.OK, "200 ok");


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "invalid");


            }

        }

        [HttpDelete]
        public HttpResponseMessage Delete_method(STUDENT1 obj)
        {
            try
            {
                var data = npm.STUDENT1.Find(obj.STD_ID);
                if (data != null)
                {
                    npm.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                    npm.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "successful");


                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "failed");


                }
                return Request.CreateResponse(HttpStatusCode.OK, "200 ok");


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "invalid");


            }


        }
    }
}








    

