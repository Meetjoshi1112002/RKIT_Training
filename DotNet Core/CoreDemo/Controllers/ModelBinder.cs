using CoreDemo.ModelBinder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*
 * This all thing overwrite the default behaviour of the model binder :>
 * 
 * [BindProperty]
 * [BindProperties]
 * [FromQuery]
 * [FromRoute]
 * [FromBody]
 * [FromForm]
 * [FromHeader]
 * 
 * Default Behaviour:
 *                  Simple data will be bind by query string
 *                  Complex data from body
 
 */
namespace CoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelBinder : ControllerBase
    {
        [BindProperty(SupportsGet =true)]
        public Demo SampleProperty { get; set; }

        public string Sampe2 { get; set; }

        [HttpGet]                                       // Now when we want form data in get apis , then make supportget = true for 
        public string GetName()
        {
            return SampleProperty.Name;
        }

        [HttpPost]
        public string GetDemo([FromQuery]Demo obj)          // FromQuery force model binder to make complex obj from query string
        {
            return obj.Name;
        }

        [HttpGet]
        public string[] CustomModelBinderExample([ModelBinder(typeof(CustomBinder1))] string[] coutires) 
        {
            return coutires;
        }
    }


    public class Demo
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
