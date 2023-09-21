using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(_orderRepository.GetAll());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _orderRepository == null)
            {
                return NotFound();
            }

            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerId"); //used declared _customerRepository to retrieve the methods in IGenericRepository to display customer table information
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (ModelState.IsValid)
            {
                _orderRepository.Create(order);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerId", order.CustomerId); //used declared _customerRepository to retrieve the methods in IGenericRepository to display customer table information along with the order table customerID
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _orderRepository == null)
            {
                return NotFound();
            }

            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerId", order.CustomerId); //used declared _customerRepository to retrieve the methods in IGenericRepository to display customer table information along with the order table customerID
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _orderRepository.Update(order);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerId", order.CustomerId); //used declared _customerRepository to retrieve the methods in IGenericRepository to display customer table information along with the order table customerID
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _orderRepository == null)
            {
                return NotFound();
            }

            var order = _orderRepository.GetOrderById(id); //Fetched method from IOrderRepository to display OrderID
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_orderRepository == null)
            {
                return Problem("Entity set 'SuperStoreContext.Orders'  is null.");
            }
            var order = _orderRepository.GetById(id); //Fetched method from IGenericRepository
            if (order != null)
            {
                _orderRepository.Delete(order);
            }


            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id, SuperStoreContext _context)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
