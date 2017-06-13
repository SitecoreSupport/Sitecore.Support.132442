using Sitecore.Analytics.Pipelines.CreateVisits;
using Sitecore.Diagnostics;
using System;
using System.Linq;

namespace Sitecore.Support.Analytics.Pipelines.CreateVisits
{
    public class XForwardedFor : Sitecore.Analytics.Pipelines.CreateVisits.XForwardedFor
    {
        protected override string GetIpFromHeader(string header)
        {
            Assert.ArgumentNotNull(header, "header");
            string[] array = header.Split(new char[]
            {
                ','
            });
            int headerIpIndex = base.HeaderIpIndex;
            string text = (headerIpIndex < array.Length) ? array[headerIpIndex] : array.LastOrDefault<string>();
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            string[] array2 = text.Split(new char[]
            {
                ':'
            }, StringSplitOptions.RemoveEmptyEntries);
            if (array2.Length > 1)
            {
                text = array2[0];
            }
            return text.Trim();
        }
    }
}
