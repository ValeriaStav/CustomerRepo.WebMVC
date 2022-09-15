using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerManagement.Repositories;
using System.IdentityModel.Metadata;
using System.Web.Mvc;

namespace CustomerRepo.WebMVC.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IRepository<Address> _addressRepository;

        public IRepository<Address> Object { get; }

        public AddressesController()
        {
            _addressRepository = new AddressRepository();
        }

        public AddressesController(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: Address
        public ActionResult Index()
        {
            var address = _addressRepository.GetAll();
            return View(address);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _addressRepository.Update(address);
                return View(address);
            }
            
            if (!ModelState.IsValid)
            {
                ViewBag.Massage = "Value isn't valid";
                return View("Error");
            }

            return View("Index");
        }

        // GET: Address/Edit/5i
        public ActionResult Edit(int addressId)
        {
            var address = _addressRepository.Read(addressId);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(Address address)
        {            
            if (!ModelState.IsValid)
            {
                ViewBag.Massage = "Value isn't valid";
                return View(address);
            }

            if (ModelState.IsValid)
            {
                _addressRepository.Update(address);
                return View(address);
            }

            return HttpNotFound();
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            var address = _addressRepository.Read(id);
            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Address address)
        {
            try
            {
                var _noteRepository = new NoteRepository();
                var _addressRepository = new AddressRepository();

                _noteRepository.Delete(id);
                _addressRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(address);
            }
        }
    }
}
