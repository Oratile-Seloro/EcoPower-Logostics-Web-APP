using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderDetailsController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index(SuperStoreContext _context)
        {
            var superStoreContext = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
            return View(await superStoreContext.ToListAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int id, SuperStoreContext _context)
        {
            if (id == null || _orderDetailRepository == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailsId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "OrderId", "OrderId");//used declared _orderRepository to retrieve the methods in IGenericRepository to display order table information 
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductId");//used declared _productRepository to retrieve the methods in IGenericRepository to display product table information
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _orderDetailRepository.Create(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "OrderId", "OrderId", orderDetail.OrderId);//used declared _orderRepository to retrieve the methods in IGenericRepository to display order table information 
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductId", orderDetail.ProductId);//used declared _productRepository to retrieve the methods in IGenericRepository to display product table information
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _orderDetailRepository == null)
            {
                return NotFound();
            }

            var orderDetail = _orderDetailRepository.GetById(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "OrderId", "OrderId", orderDetail.OrderId);//used declared _orderRepository to retrieve the methods in IGenericRepository to display order table information
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductId", orderDetail.ProductId);//used declared _productRepository to retrieve the methods in IGenericRepository to display product table information
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _orderDetailRepository.Update(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "OrderId", "OrderId", orderDetail.OrderId);//used declared _orderRepository to retrieve the methods in IGenericRepository to display order table information
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductId", orderDetail.ProductId);//used declared _productRepository to retrieve the methods in IGenericRepository to display product table information
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int id, SuperStoreContext _context)
        {
            if (id == null || _orderDetailRepository == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailsId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_orderDetailRepository == null)
            {
                return Problem("Entity set 'SuperStoreContext.OrderDetails'  is null.");
            }
            var orderDetail = _orderDetailRepository.GetById(id);
            if (orderDetail != null)
            {
                _orderDetailRepository.Delete(orderDetail);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id, SuperStoreContext _context)
        {
            return (_context.OrderDetails?.Any(e => e.OrderDetailsId == id)).GetValueOrDefault();
        }
    }
}
