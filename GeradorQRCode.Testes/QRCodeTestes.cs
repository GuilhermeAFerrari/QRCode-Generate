using GeradorQRCode.Models;

namespace GeradorQRCode.Testes
{
    public class QRCodeTestes
    {
        private QRCode qrcode;

        public QRCodeTestes()
        {
            qrcode = new QRCode("http://google.com.br");
        }

        [Fact]
        public void CreateQRCode_SendingValidValue()
        {
            Assert.Equal("http://google.com.br", qrcode.QRCodeText);
        }

        [Fact]
        public void CreateQRCode_NotIsEmpty()
        {
            Assert.NotEmpty(qrcode.QRCodeText);
        }

        [Fact]
        public void CreateQRCode_NotContains()
        {
            Assert.DoesNotContain("?", qrcode.QRCodeText);
        }
    }
}