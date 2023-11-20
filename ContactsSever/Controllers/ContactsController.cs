using ForrealServerBL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForrealSever.Controllers
{
    [Route("contactsAPI")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        #region Add connection to the db contextt using depency injection
        ForrealDBContext context;
        public ContactsController(ForrealDBContext context)
        {
            this.context = context;
        }

        #endregion
    }
}
