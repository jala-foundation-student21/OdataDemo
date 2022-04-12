using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;


namespace ODataWebAPI.Controllers
{
    public class CompaniesController : ODataController  
    {
        private BookStoreContext _bookStoreContext;

     

        public CompaniesController(BookStoreContext context)
        {
            _bookStoreContext = context;

            if (context.Companies.Count() == 0)
            {
                foreach (var b in DataSource.GetCompanies())
                {
                    context.Companies.Add(b);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_bookStoreContext.Companies);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_bookStoreContext.Companies.FirstOrDefault(c => c.Id == key));
        }



        [EnableQuery]
        public IActionResult Post([FromBody] Companies companies)
        {
            _bookStoreContext.Companies.Add(companies);
            _bookStoreContext.SaveChanges();
            return Created(companies);

        }

        [EnableQuery]
        public IActionResult Put(int key,[FromBody]Companies companies)
        {
            _bookStoreContext.Companies.Update(companies);
            _bookStoreContext.SaveChanges();
            return Updated(companies);

        }



        [EnableQuery]
        public IActionResult Delete (int key)
        {
            try
            {
                 _bookStoreContext.Remove(key);
                _bookStoreContext.SaveChanges();
               return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



    }
}
