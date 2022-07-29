using GeradorQRCode.Models;
using IronBarCode;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace GeradorQRCode.Controllers
{
    public class QRCodeController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public QRCodeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View("qrcode");
        }

        public IActionResult CreateQRCode(QRCode qrcode)
        {
            try
            {
                GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(qrcode.QRCodeText, 200);
                barcode.AddBarcodeValueTextBelowBarcode();

                // Estilização do QRCode
                barcode.SetMargins(10);
                barcode.ChangeBarCodeColor(Color.DarkSlateGray);

                string path = Path.Combine(_environment.WebRootPath, "QRCodeGerado");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = Path.Combine(_environment.WebRootPath, "QRCodeGerado/qrcode.png");
                barcode.SaveAsPng(filePath);
                string fileName = Path.GetFileName(filePath);
                string imageUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/QRCodeGerado/" + fileName;
                ViewBag.URIQRCode = imageUrl;
            }
            catch (Exception)
            {

                throw;
            }

            return View("qrcode");
        }
    }
}
