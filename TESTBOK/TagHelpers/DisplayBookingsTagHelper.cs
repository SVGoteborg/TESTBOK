using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESTBOK.Models;

namespace TESTBOK.TagHelpers
{
    public class DisplayBookingsTagHelper : TagHelper
    {
        public IEnumerable<Booking> Booking { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public int divWidth = 0;

        public List<Booking> BookingsList = new List<Booking>();
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            foreach(var booking in Booking)
            {
                if(booking.Resource.ResId == Id && booking.StartDate.ToString("yyyy-MM-dd") == Date)
                {
                    BookingsList.Add(booking);
                }
            }

            if(BookingsList.Count == 1)
            {
                var startHour = BookingsList[0].StartTime.Hour;
                var endHour = BookingsList[0].StopTime.Hour;
                divWidth = (endHour - startHour) * 4;
                TagBuilder div = new TagBuilder("div");
                div.AddCssClass("dblock");
                div.MergeAttribute(
                "style",
                $"width: { divWidth }px;  background-color: rgb(172,114,68);");
                
                output.Content.SetHtmlContent(div);
            }
            else if (BookingsList.Count > 1)
            {
                foreach(var booking in BookingsList)
                {
                    var startHour = booking.StartTime.Hour;
                    var endHour = booking.StopTime.Hour;
                    divWidth = (endHour - startHour) * 4;
                    TagBuilder div = new TagBuilder("div");
                    div.AddCssClass("dblock");
                    div.MergeAttribute(
                    "style",
                    $"width: { divWidth }px;  background-color: rgb(172,114,68);");

                    output.Content.AppendHtml(div);
                 
                }
            }
        }
    }
}
