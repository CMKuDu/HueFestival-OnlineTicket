using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Models;
using BlazorZXingJs;
using HueFestival_OnlineTicket.Model;
using System.Drawing.Imaging;
using System.Drawing;
using ZXing.QrCode;
using ZXing;
using ZXing.Windows.Compatibility;
using BarcodeFormat = ZXing.BarcodeFormat;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketBooksController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketBooksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TicketBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketBook>>> GetTicketBooks()
        {
          if (_context.TicketBooks == null)
          {
              return NotFound();
          }
            return await _context.TicketBooks.ToListAsync();
        }

        // GET: api/TicketBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketBook>> GetTicketBook(int id)
        {
          if (_context.TicketBooks == null)
          {
              return NotFound();
          }
            var ticketBook = await _context.TicketBooks.FindAsync(id);

            if (ticketBook == null)
            {
                return NotFound();
            }

            return ticketBook;
        }

        // PUT: api/TicketBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketBook(int id, TicketBook ticketBook)
        {
            if (id != ticketBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketBookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TicketBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketBook>> PostTicketBook(TicketBook ticketBook)
        {
          if (_context.TicketBooks == null)
          {
              return Problem("Entity set 'DataContext.TicketBooks'  is null.");
          }
            _context.TicketBooks.Add(ticketBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketBook", new { id = ticketBook.Id }, ticketBook);
        }

        // DELETE: api/TicketBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketBook(int id)
        {
            if (_context.TicketBooks == null)
            {
                return NotFound();
            }
            var ticketBook = await _context.TicketBooks.FindAsync(id);
            if (ticketBook == null)
            {
                return NotFound();
            }

            _context.TicketBooks.Remove(ticketBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketBookExists(int id)
        {
            return (_context.TicketBooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [HttpPost("createqrcode")]
        public async Task<ActionResult<Ticket>> GenerateQRCode(Ticket ticket)
        {
            BarcodeWriter writer = new BarcodeWriter();
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                Width = 300,
                Height = 300,
                DisableECI = true,
                CharacterSet = "UTF-8"
            };
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            var data = new
            {
                TicketName = ticket.NameTicket,
                TicketTypeName = _context.TicketTypes.Where(x => x.id == ticket.TicketTypeId).Select(x => x.Nametypeticket).FirstOrDefault(),
                TicketBook = _context.TicketBooks.Where(x => x.Id == ticket.Id).Select(x => x.TickId).FirstOrDefault(),
                Customer = _context.Customers.Where(x => x.Id == ticket.Id).Select(x => x.Namecustomer).FirstOrDefault(),
                Fdate = ticket.CreatedDate
            }.ToString();

            Console.WriteLine(data);
            Bitmap qrCodeBitmap = writer.Write(data);

            MemoryStream ms = new MemoryStream();
            qrCodeBitmap.Save(ms, ImageFormat.Png);
            byte[] qrCodeBytes = ms.ToArray();

            string imagePath = "Img/QRTicket/qrticket" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".png";
            qrCodeBitmap.Save(imagePath, ImageFormat.Png);

            return File(qrCodeBytes, "image/png");
        }
        [HttpPost("qrcode")]
        public IActionResult DecodeQRCode(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using (var stream = file.OpenReadStream())
            {
                var reader = new BarcodeReader();
                var result = reader.Decode(new BitmapLuminanceSource(new Bitmap(stream)));

                if (result != null)
                {
                    string decodedData = result.Text;
                    return Ok(decodedData);
                }
                else
                {
                    return BadRequest("Unable to decode QR code.");
                }
            }
        }
    }
}
