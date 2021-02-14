//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Creating_MVC_Form.DB;
//using Microsoft.Extensions.Options;
//using MVC_Form_Intern_Aditya.Models;

//namespace Creating_MVC_Form.API
//{
//    //[Route("api/[controller]")]
//    //[ApiController]
//    //public class RegistrationController : ControllerBase
//    //{
//    //}


//    [Route("api/[controller]/[Action]")]
//    [ApiController]
//    public class RegisterController : ControllerBase
//    {
//        DB.DBRegistration datatest = new DB.DBRegistration();

//        private readonly IOptions<ModelConnectionString> appSettings;
//        public RegisterController(IOptions<ModelConnectionString> app)
//        {
//            appSettings = app;
//        }

//        [HttpGet]
//        [ActionName("GetRegisterlist")]
//        // api/Register/GetRegisterlist
//        public IEnumerable<ModelRegistration> GetRegisteredlist()
//        {
//            return datatest.GetRegisteredlist(appSettings.Value.DefaultConnection);
//        }
//        [HttpGet]
//        [ActionName("EditRegisteredlist")]
//        // api/Register/GetRegisterlist?id=1
//        public IEnumerable<ModelRegistration> EditRegistered(int id)
//        {
//            return datatest.EditRegistered(id, appSettings.Value.DefaultConnection);
//        }
//        [HttpPost]
//        [ActionName("SaveRegister")]
//        //  api/Register/SaveRegister
//        public string Post(ModelRegistration stud)
//        {
//            return datatest.Post(stud, appSettings.Value.DefaultConnection);
//        }
//        [HttpPut]
//        [ActionName("UpdateRegister")]
//        //  api/Register/UpdateRegister
//        public string Put(ModelRegistration stud)
//        {
//            return datatest.Put(stud, appSettings.Value.DefaultConnection);
//        }
//        [HttpDelete]
//        [ActionName("DeleteRegister")]
//        //  api/Register/DeleteRegister
//        public string Delete(int id, string deletedBy)
//        {
//            return datatest.Delete(id, deletedBy, appSettings.Value.DefaultConnection);
//        }
//    }

//}
