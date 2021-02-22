using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MediatR;
using PasswordManager.Presentation.Filters;
using PasswordManagerCA.Core.Commands;
using PasswordManagerCA.Core.Entities;

namespace PasswordManager.Presentation.Controllers
{
    [AuthenticationFilter]
    public class ManageController : Controller
    {
        private readonly IMediator _mediator;


        public ManageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Accounts()
        {
            UserAccountsCommand currentUserAccounts = new UserAccountsCommand();
            currentUserAccounts.Id = (int)Session["user-id"];
            var response = await _mediator.Send(currentUserAccounts);
            if ((bool)response.isValid)
            {
                return View(response.UserAccounts);
            }
            return View(response.UserAccounts);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserAccountsAddCommand currentUserAccountsAdd)
        {
            currentUserAccountsAdd.UserId = (int)Session["user-id"];
            var response = await _mediator.Send(currentUserAccountsAdd);
            if ((bool)response.isValid)
            {
                return View();
            }
            return View("Accounts");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UserAccountsAddCommand());
        }
    }
}