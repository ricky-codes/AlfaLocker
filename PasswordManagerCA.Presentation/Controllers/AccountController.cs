using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MediatR;
using PasswordManagerCA.Core.Commands;
using PasswordManagerCA.Core.Entities;
using PasswordManagerCA.Infrastructure.Data.Config;
using PasswordManagerCA.SharedKernel.Interfaces;

namespace PasswordManager.Presentation.Controllers
{
    public class AccountController : Controller
    {

        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View(new UserRegistrationCommand());
        }

        [HttpPost]
        public async Task<ActionResult> Registration(UserRegistrationCommand appUserCommand)
        {
            var response = await _mediator.Send(appUserCommand);
            if(response.isValid)
            {
                Session["user-id"] = response.Id;
            }
            return RedirectToAction("Verification");
        }

        public ActionResult Verification()
        {
            return View(new UserVerificationCommand());
        }

        [HttpPost]
        public async Task<ActionResult> Verification(UserVerificationCommand userVerificationCommand)
        {
            userVerificationCommand.Id = (int)Session["user-id"];
            var response = await _mediator.Send(userVerificationCommand);
            if (response.isValid)
            {
                Session["user-id"] = response.Id;
                return RedirectToAction("Index", "Home");
            }
            return View(response);
        }


        public ActionResult Login()
        {
            return View(new UserLoginCommand());
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginCommand userLoginCommand)
        {
            var response = await _mediator.Send(userLoginCommand);
            if (response.isValid)
            {
                Session["user-id"] = response.Id;
                Session["user-username"] = response.AppUserUsername;
                Session["user-fullname"] = response.AppUserFullname;
                return RedirectToAction("Index", "Home");
            }
            return View(response);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session["user-id"] = null;
            Session["user-username"] = null;
            Session["user-fullname"] = null;
            return RedirectToAction("Index", "Home");
        }


        public async Task<ActionResult> Manage()
        {
            CurrentUserCommand currentUser = new CurrentUserCommand();
            currentUser.Id = (int)Session["user-id"];
            var response = await _mediator.Send(currentUser);
            return View(response);
        }

        [HttpPost]
        public async Task<ActionResult> Manage(UserManageCommand userManageCommand)
        {
            userManageCommand.Id = (int)Session["user-id"];
            var response = await _mediator.Send(userManageCommand);
            if (response.isValid)
            {
                Session["user-fullname"] = response.AppUserFirstname + " " + response.AppUserLastname; 
                return RedirectToAction("Index", "Home");
            }
            return View(response);
        }
    }
}