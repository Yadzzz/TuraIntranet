using System.Reflection;

namespace TuraIntranet.Services.Logistics
{
    public class ShipmentsDeviationChecklistService
    {
        private string htmlTemplate = string.Empty;

        public ShipmentsDeviationChecklistService()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"wwwroot/components/ChecklistDeviationTemplate.txt");
            this.htmlTemplate = File.ReadAllText(path);
        }

        public string GetHtmlTemplate(string supplier, string shipmentCompany, string deliveryDate, string responsbileConsignee, string orderNumber, string totalParcelsAndPallets,
                                        string receivedAt, string responsibleSorageEmloyee, string partDelivery, bool signedByShipmentLabel, bool signedVisDosa,
                                        bool damagedGoods, bool acceptablePallets, bool correctPalletHeight, bool hasDeliveryNote,
                                        bool OrderNumberOnDeliveryNote, bool ConcealedFreigtDamage, bool deliveryNoteDeviations, bool sortedBoxwise, bool orderTransferred,
                                        bool taggedMixedBoxes)
        {
            string template = this.htmlTemplate;
            template = template.Replace("{LEVERANTOR}", supplier);
            template = template.Replace("{FRAKTBOLAG}", shipmentCompany);
            template = template.Replace("{ANKOMSTDATUM}", deliveryDate);
            template = template.Replace("{ANSVARIGGDSM}", responsbileConsignee);
            template = template.Replace("{ORDERNR}", orderNumber);
            template = template.Replace("{ANTALLKOLLINPALLAR}", totalParcelsAndPallets);
            template = template.Replace("{INLAGRINGSDATUM}", receivedAt);
            template = template.Replace("{ANSVARIGINLAGRING}", responsibleSorageEmloyee);
            template = template.Replace("{PARTLEV}", partDelivery);

            if (signedByShipmentLabel)
                template = template.Replace("<input type=\"checkbox\" id=\"Underskrivet via fraktsedel\" name=\"Underskrivet via fraktsedel\">", "<input type=\"checkbox\" id=\"Underskrivet via fraktsedel\" name=\"Underskrivet via fraktsedel\" checked>");
            if (signedVisDosa)
                template = template.Replace("<input type=\"checkbox\" id=\"Underskrivet via dosa\" name=\"Underskrivet via dosa\">", "<input type=\"checkbox\" id=\"Underskrivet via dosa\" name=\"Underskrivet via dosa\" checked>");
            if (damagedGoods)
                template = template.Replace("<input type=\"checkbox\" id=\"Fraktskador\" name=\"Fraktskador\">", "<input type=\"checkbox\" id=\"Fraktskador\" name=\"Fraktskador\" checked>");
            if (acceptablePallets)
                template = template.Replace("<input type=\"checkbox\" id=\"Godtagbara\" name=\"Godtagbara\">", "<input type=\"checkbox\" id=\"Godtagbara\" name=\"Godtagbara\" checked>");
            if (correctPalletHeight)
                template = template.Replace("<input type=\"checkbox\" id=\"Ok pall\" name=\"Ok pall\">", "<input type=\"checkbox\" id=\"Ok pall\" name=\"Ok pall\" checked>");
            if (ConcealedFreigtDamage)
                template = template.Replace("<input type=\"checkbox\" id=\"Dolda fraktskador\" name=\"Dolda fraktskador\">", "<input type=\"checkbox\" id=\"Dolda fraktskador\" name=\"Dolda fraktskador\" checked>");
            if (hasDeliveryNote)
                template = template.Replace("<input type=\"checkbox\" id=\"Bifogade följesedlar\" name=\"Bifogade följesedlar\">", "<input type=\"checkbox\" id=\"Bifogade följesedlar\" name=\"Bifogade följesedlar\" checked>");
            if (OrderNumberOnDeliveryNote)
                template = template.Replace("<input type=\"checkbox\" id=\"scales\" name=\"Ordernr pa foljesedeln\">", "<input type=\"checkbox\" id=\"scales\" name=\"Ordernr pa foljesedeln\" checked>");
            if (orderTransferred)
                template = template.Replace("<input type=\"checkbox\" id=\"scales\" name=\"Order overford\">", "<input type=\"checkbox\" id=\"scales\" name=\"Order overford\" checked>");
            if (deliveryNoteDeviations)
                template = template.Replace("<input type=\"checkbox\" id=\"Avvikelser pa foljesedeln\" name=\"Avvikelser pa foljesedeln\">", "<input type=\"checkbox\" id=\"Avvikelser pa foljesedeln\" name=\"Avvikelser pa foljesedeln\" checked>");
            if (taggedMixedBoxes)
                template = template.Replace("<input type=\"checkbox\" id=\"Uppmarkta Blandlador\" name=\"Uppmarkta Blandlador\">", "<input type=\"checkbox\" id=\"Uppmarkta Blandlador\" name=\"Uppmarkta Blandlador\" checked>");
            if (sortedBoxwise)
                template = template.Replace("<input type=\"checkbox\" id=\"Sortrent\" name=\"Sortrent\">", "<input type=\"checkbox\" id=\"Sortrent\" name=\"Sortrent\" checked>");

            return template;
        }
    }
}
