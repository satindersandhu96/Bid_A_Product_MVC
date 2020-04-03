using Bid_A_Product_MVC.Data;
using Bid_A_Product_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bid_A_Product_MVC.Controllers
{
    [Authorize]
    public class BidsController : Controller
    {
        private readonly Bid_A_Product_DbContext _context;

        public BidsController(Bid_A_Product_DbContext context)
        {
            _context = context;
        }

        // GET: Bids
        public async Task<IActionResult> Index()
        {
            var bid_A_Product_DbContext = _context.Bid.Include(b => b.Buyer).Include(b => b.Product).Include(b => b.Seller);
            return View(await bid_A_Product_DbContext.ToListAsync());
        }

        // GET: Bids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid
                .Include(b => b.Buyer)
                .Include(b => b.Product)
                .Include(b => b.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // GET: Bids/Create
        public IActionResult Create()
        {
            ViewData["BuyerId"] = new SelectList(_context.Set<Buyer>(), "Id", "BuyerAccountNumber");
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductName");
            ViewData["SellerId"] = new SelectList(_context.Set<Seller>(), "Id", "SellerName");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,BuyerId,SellerId,BidPrice")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerId"] = new SelectList(_context.Set<Buyer>(), "Id", "BuyerAccountNumber", bid.BuyerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductName", bid.ProductId);
            ViewData["SellerId"] = new SelectList(_context.Set<Seller>(), "Id", "SellerName", bid.SellerId);
            return View(bid);
        }

        // GET: Bids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }
            ViewData["BuyerId"] = new SelectList(_context.Set<Buyer>(), "Id", "BuyerAccountNumber", bid.BuyerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductName", bid.ProductId);
            ViewData["SellerId"] = new SelectList(_context.Set<Seller>(), "Id", "SellerName", bid.SellerId);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,BuyerId,SellerId,BidPrice")] Bid bid)
        {
            if (id != bid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bid.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerId"] = new SelectList(_context.Set<Buyer>(), "Id", "BuyerAccountNumber", bid.BuyerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductName", bid.ProductId);
            ViewData["SellerId"] = new SelectList(_context.Set<Seller>(), "Id", "SellerName", bid.SellerId);
            return View(bid);
        }

        // GET: Bids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid
                .Include(b => b.Buyer)
                .Include(b => b.Product)
                .Include(b => b.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bid = await _context.Bid.FindAsync(id);
            _context.Bid.Remove(bid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidExists(int id)
        {
            return _context.Bid.Any(e => e.Id == id);
        }
    }
}
