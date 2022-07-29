using System.ComponentModel.DataAnnotations;

namespace GeradorQRCode.Models
{
    public class QRCode
    {
        [Display(Name = "Insira o texto para o QR Code")]
        [Required(ErrorMessage = "Insira um valor")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caracteres para este campo")]
        public string? QRCodeText { get; set; }

        public QRCode() {}

        public QRCode(string valor)
        {
            QRCodeText = valor;
        }
    }
}
