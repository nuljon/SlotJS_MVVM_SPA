using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SlotJS_MVVM_SPAS.Models;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;

namespace SlotJS_MVVM_SPAS.Controllers
{
    [Authorize]
    public class MeController : ApiController
    {
        private ApplicationUserManager _userManager;

        public MeController()
        {
        }

        public MeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        
        // GET api/Me this method GETS player data based on the thread i.e. session
        public GetViewModel Get()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return new GetViewModel() { Credits = user.Credits, PlayerName = user.PlayerName, userid = User.Identity.GetUserId()};
        }

        //  PUT api/Me/id
        // make sure our client is authorized - client sends auth in header
        //[Authorize]
        [HttpPut]
        // this time find Player with id as part of url
        public HttpResponseMessage PutUser(string id, PutModel putdata)
        {
            // create an instance of db context
            PlayerDb db = new PlayerDb();
            // create an instance of the user matching id sent by client
            User user  = db.Users.Find(id);
            // update the user credits in db from json data sent by client
            user.Credits = putdata.cred;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(
                  HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}  