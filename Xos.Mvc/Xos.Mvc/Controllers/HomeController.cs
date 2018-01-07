using System;
using System.Linq;
using System.Web.Mvc;
using Xos.Mvc.Framework.Controllers;
using Xos.Mvc.Framework.Filters;
using Xos.Mvc.Models;

namespace Xos.Mvc.Controllers
{
    // Example of how to inherit from the framework classes
    public class HomeController : BaseController
    {
        // Create an instance of the application repository which derives from the Framework/Infrastructure/BaseRepository. The repository pattern is implemented
        // with generics and accepts a generic type which is a class constraint. The application context, which derives from Framework/Infrastructure/BaseDbContext
        // is passed in to the application repository's constructor method for use in EF calls.
        // NOTE: This implementation makes use of the DbContext built in behavior to search for a connection string with a name that matches the DbContext class name.
        // In this case ApplicationContext.
        ApplicationRepository<SampleModel> _repository = new ApplicationRepository<SampleModel>(new ApplicationContext());

        public HomeController(){}

        // GET: Home
        // Example of the application of the LogAttribute. If there was a logging implementation in the Framework/Filters/LogAttribute action filter, then it would execute
        // when this action is called. This could be applied at the controller scope (all actions in the controller) or the action scope.
        [Log]
        public ActionResult Index()
        {
            // demonstrate use of the repository pattern by adding an item then retrieving it.
            var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            _repository.Add(new SampleModel
            {
                Id = 1,
                ItemName = "Sample Item",
                CreatedBy = "me",
                CreatedOn = DateTime.Now,
                LastModifiedBy = "me",
                LastModifiedOn = DateTime.Now,
                RowVersion = BitConverter.GetBytes(timestamp),
                IsDeleted = false
            });
            _repository.Save();

            // retrieve the items using the repository method.
            IQueryable<SampleModel> viewModel = _repository.GetAll();

            return View(viewModel);
        }
    }
}