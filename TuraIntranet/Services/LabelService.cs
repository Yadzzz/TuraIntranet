using TuraIntranet.Data.Backoffice.Koss;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace TuraIntranet.Services
{
    public class LabelService
    {
        private Dictionary<string, string> _labelSenderAdresses;

        public LabelService()
        {
            this._labelSenderAdresses = new()
            {
                {"LabelSenderAddress_sv", "Avs:\nMy Portapro/\nTurascandinavia AB\nEnergigatan 15 B\n434 37  Kungsbacka" },
                {"LabelSenderAddress_dk", "Avs:\nTurascandinavia AB\nBregnerødvej 132B\n3460 Birkerød" },
                {"LabelSenderAddress_no", "Avs:\nTurascandinavia AB\nPostboks 150 Oppsal\n0619 Oslo" }
            };
        }

        public byte[] GenerateLablel(KossRma rma, string kossName)
        {
            string key = "LabelSenderAddress_" + rma.Country;

            string adress = string.Empty;
            if(this._labelSenderAdresses.TryGetValue(key, out adress))
            {
                
            }
            else
            {
                adress = "Avs:\nMy Portapro/\nTurascandinavia AB\nEnergigatan 15 B\n434 37  Kungsbacka";
            }

            return this.GetKossRmaAddressLabel(rma, adress, kossName);
        }

        private byte[] GetKossRmaAddressLabel(KossRma rma, string adress, string kossName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (rma.Country == "sv")
            {
                return this.GetKossRmaAdressLabelForSweden(rma, adress, kossName);
            }
            else if(rma.Country == "no")
            {
                return this.GetKossRmaAdressLabelForNorway(rma, adress, kossName);
            }

            var pdf = new PdfDocument();
            var page = pdf.AddPage();
            page.Width = XUnit.FromMillimeter(62);
            page.Height = XUnit.FromMillimeter(55);

            //page.Orientation = PdfSharp.PageOrientation.Landscape;


            var gfx = XGraphics.FromPdfPage(page);
            //gfx.RotateTransform(-90);
            var Rfont = new XFont("Arial", 10, XFontStyle.Bold);

            float marginLeft = (float)XUnit.FromMillimeter(4);
            int marginTop = 8;
            gfx.DrawString(rma.FirstName + " " + rma.LastName, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));

            if (!string.IsNullOrEmpty(rma.CoAddress))
            {
                marginTop += 5;
                gfx.DrawString("C/O " + rma.CoAddress, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));
            }
            marginTop += 5;
            gfx.DrawString(rma.StreetAddress, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));

            marginTop += 5;


            gfx.DrawString(rma.Zipcode + "  " + rma.City, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));
            var pen = new XPen(XColor.FromArgb(Color.Black), 2);
            //marginTop += 5;
            gfx.DrawLine(pen, XUnit.FromMillimeter(4), XUnit.FromMillimeter(28.5), XUnit.FromMillimeter(58), XUnit.FromMillimeter(28.5));

            XTextFormatter tf = new XTextFormatter(gfx);
            var font = new XFont("Arial", 10);
            marginTop += 11;


            tf.DrawString(adress, font, XBrushes.Black, new XRect(marginLeft, XUnit.FromMillimeter(marginTop), XUnit.FromMillimeter(62), XUnit.FromMillimeter(marginTop)));

            var sFont = new XFont("arial", 6);
            float modelTop = string.IsNullOrEmpty(rma.CoAddress) ? ((float)marginTop) : ((float)(marginTop - 5));
            modelTop -= 1;
            gfx.DrawString(kossName, sFont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(modelTop)));

            gfx.DrawLine(XPens.Black, 10, 90, 165, 140);
            gfx.DrawLine(XPens.Black, 10, 140, 165, 90);


            using (var ms = new MemoryStream())
            {
                pdf.Save(ms, false);
                pdf.Close();
                return ms.ToArray();
            }
        }

        private byte[] GetKossRmaAdressLabelForSweden(KossRma rma, string adress, string kossName)
        {
            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var pdf = new PdfDocument();
            var page = pdf.AddPage();
            page.Width = XUnit.FromMillimeter(88);
            page.Height = XUnit.FromMillimeter(55);

            //page.Orientation = PdfSharp.PageOrientation.Landscape;


            var gfx = XGraphics.FromPdfPage(page);
            //gfx.RotateTransform(-90);
            var Rfont = new XFont("Arial", 11, XFontStyle.Bold);

            float marginLeft = (float)XUnit.FromMillimeter(4);
            int marginTop = 8;
            gfx.DrawString(rma.FirstName + " " + rma.LastName, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));

            if (!string.IsNullOrEmpty(rma.CoAddress))
            {
                marginTop += 5;
                gfx.DrawString("C/O " + rma.CoAddress, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));
            }
            marginTop += 5;
            gfx.DrawString(rma.StreetAddress, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));
            marginTop += 5;


            gfx.DrawString(rma.Zipcode + "  " + rma.City, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));
            var pen = new XPen(XColor.FromArgb(Color.Black), 2);
            //marginTop += 5;
            gfx.DrawLine(pen, XUnit.FromMillimeter(4), XUnit.FromMillimeter(28.5), XUnit.FromMillimeter(58), XUnit.FromMillimeter(28.5));

            XTextFormatter tf = new XTextFormatter(gfx);
            var font = new XFont("Arial", 11);
            marginTop += 11;


            tf.DrawString(adress, font, XBrushes.Black, new XRect(marginLeft, XUnit.FromMillimeter(marginTop), XUnit.FromMillimeter(62), XUnit.FromMillimeter(marginTop)));

            var sFont = new XFont("arial", 7);
            float modelTop = string.IsNullOrEmpty(rma.CoAddress) ? ((float)marginTop) : ((float)(marginTop - 5));
            modelTop -= 1;
            gfx.DrawString(kossName, sFont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(modelTop))); //CHANGE TO KOSS NAME

            gfx.DrawLine(XPens.Black, 10, 90, 178, 140);
            gfx.DrawLine(XPens.Black, 10, 140, 178, 90);


            using (var ms = new MemoryStream())
            {
                pdf.Save(ms, false);
                pdf.Close();
                return ms.ToArray();
            }
        }

        private byte[] GetKossRmaAdressLabelForNorway(KossRma rma, string adress, string kossName)
        {
            var pdf = new PdfDocument();
            var page = pdf.AddPage();
            page.Width = XUnit.FromMillimeter(57);
            page.Height = XUnit.FromMillimeter(32);

            //page.Orientation = PdfSharp.PageOrientation.Landscape;


            var gfx = XGraphics.FromPdfPage(page);
            //gfx.RotateTransform(-90);
            var Rfont = new XFont("Arial", 8, XFontStyle.Bold);

            float marginLeft = (float)XUnit.FromMillimeter(4);
            int marginTop = 4;
            gfx.DrawString(rma.FirstName + " " + rma.LastName, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));

            if (!string.IsNullOrEmpty(rma.CoAddress))
            {
                marginTop += 4;
                gfx.DrawString("C/O " + rma.CoAddress, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));
            }
            marginTop += 4;
            gfx.DrawString(rma.StreetAddress, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));

            marginTop += 4;


            gfx.DrawString(rma.Zipcode + "  " + rma.City, Rfont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(marginTop)));
            var pen = new XPen(XColor.FromArgb(Color.Black), 2);
            //marginTop += 5;
            gfx.DrawLine(pen, XUnit.FromMillimeter(4), XUnit.FromMillimeter(20), XUnit.FromMillimeter(53), XUnit.FromMillimeter(20));

            XTextFormatter tf = new XTextFormatter(gfx);
            var font = new XFont("Arial", 6);
            marginTop += 5;


            tf.DrawString(adress, font, XBrushes.Black, new XRect(marginLeft, XUnit.FromMillimeter(21.5), XUnit.FromMillimeter(57), XUnit.FromMillimeter(21.5)));

            var sFont = new XFont("arial", 5);
            float modelTop = string.IsNullOrEmpty(rma.CoAddress) ? ((float)marginTop) : ((float)(marginTop - 4));
            modelTop -= 1;
            gfx.DrawString(kossName, sFont, XBrushes.Black, new PointF(marginLeft, (float)XUnit.FromMillimeter(19)));

            //page.Rotate = 90;

            using (var ms = new MemoryStream())
            {
                pdf.Save(ms, false);
                pdf.Close();
                return ms.ToArray();
            }
        }
    }
}
