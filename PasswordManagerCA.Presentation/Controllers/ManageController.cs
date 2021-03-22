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

        [HttpGet]
        public async Task<ActionResult> Accounts()
        {
            UserAccountsCommand currentUserAccounts = new UserAccountsCommand();
            currentUserAccounts.UserId = (int)Session["user-id"];
            var response = await _mediator.Send(currentUserAccounts);
            if (response == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(response);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new UserAccountsAddCommand());
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserAccountsAddCommand newAccount)
        {
            newAccount.UserId = (int)Session["user-id"];
            var response = await _mediator.Send(newAccount);
            if ((bool)response.isValid)
            {
                return RedirectToAction("Accounts", "Manage");
            }
            return View(response);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            UserAccountsDeleteCommand deleteCommand = new UserAccountsDeleteCommand { Id = id };
            var response = await _mediator.Send(deleteCommand);
            return RedirectToAction("Accounts", "Manage");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            UserAccountsDetailsCommand requestedDetails = new UserAccountsDetailsCommand { Id = id };
            var response = await _mediator.Send(requestedDetails);
            return View(response);
        }

    }
}