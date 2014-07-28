using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Archimind.Platform.ServiceModel.Security.Contracts;
using Archimind.Platform.ServiceModel.Security.Client;
using System.Linq.Expressions;
using Archimind.Platform.BusinessEntities.Services;
using Serialize.Linq;
using Serialize.Linq.Extensions;
using Serialize.Linq.Nodes;
using PagedList;

namespace Archimind.Platform.Security.UI.Web.Controllers
{
    // @TODO: transform DTO to Business Entity
    public class UserController : Controller
    {
        #region Members

        private ISecurityStoreService securityStoreService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        public UserController()
            : base()
        {
            this.securityStoreService = new SecurityStoreClient("wsHttp");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="securityStoreService">The security store service.</param>
        /// <exception cref="System.ArgumentNullException">securityStoreService</exception>
        public UserController(ISecurityStoreService securityStoreService)
            : base()
        {
            if (securityStoreService == null)
            {
                throw new ArgumentNullException("securityStoreService");
            }

            this.securityStoreService = securityStoreService;
        }

        #endregion

        #region Public Methods

        //
        // GET: /User/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            // Check sort order parameter.

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";

            if (!string.IsNullOrEmpty(searchString))
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            // Get the data users from the service.
            // @TODO: Cache this data.

            // Check the search parameter.

            Expression<Func<User, bool>> filterExpression = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                // Build the expression.

                filterExpression = (Expression<Func<User, bool>>)(user => user.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            // Create request.

            SecurityStoreGetUsersWithFiltersRequest filterRequest =
                new SecurityStoreGetUsersWithFiltersRequest("abc");
            filterRequest.FilterExpressionNode = filterExpression.ToExpressionNode();

            // Get response.

            SecurityStoreGetUsersWithFiltersResponse filterResponse =
                this.securityStoreService.GetUsersWithFilters(filterRequest);

            var users = from u in filterResponse.Users select u;
            
            // Apply sort order parameter.

            switch (sortOrder)
            {
                case "Name_desc":
                    users = users.OrderByDescending(user => user.Name);
                    break;
                default:
                    users = users.OrderBy(user => user.Name);
                    break;
            }

            // Request the view.
            
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View("Index", users.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(string id)
        {
            SecurityStoreGetUserByIdRequest request =
                new SecurityStoreGetUserByIdRequest("abc", id);

            SecurityStoreGetUserByIdResponse response =
                this.securityStoreService.GetUserById(request);

            UserData user = response.User;

            return View("Details", user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Name, Address, Phone, Email")]
            UserData user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SecurityStoreCreateUserRequest request =
                        new SecurityStoreCreateUserRequest("abc", user);

                    SecurityStoreCreateUserResponse response =
                        this.securityStoreService.CreateUser(request);

                    return RedirectToAction("Index");
                }
            }
            catch(Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }

            return View("Create", user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(string id)
        {
            SecurityStoreGetUserByIdRequest request =
                new SecurityStoreGetUserByIdRequest("abc", id);

            SecurityStoreGetUserByIdResponse response =
                this.securityStoreService.GetUserById(request);

            UserData user = response.User;

            return View("Edit", user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id, Name, Address, Phone, Email")]
            UserData user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SecurityStoreUpdateUserRequest request =
                        new SecurityStoreUpdateUserRequest("abc", user);

                    SecurityStoreUpdateUserResponse response =
                        this.securityStoreService.UpdateUser(request);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }

            return View("Edit", user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(string id, bool? saveChangesError = false)
        {
            SecurityStoreGetUserByIdRequest request =
                new SecurityStoreGetUserByIdRequest("abc", id);

            SecurityStoreGetUserByIdResponse response =
                this.securityStoreService.GetUserById(request);

            UserData user = response.User;

            return View("Delete", user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SecurityStoreDeleteUserRequest request =
                        new SecurityStoreDeleteUserRequest("abc", id);

                    SecurityStoreDeleteUserResponse response =
                        this.securityStoreService.DeleteUser(request);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}
