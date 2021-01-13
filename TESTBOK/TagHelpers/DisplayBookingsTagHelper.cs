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
        public IEnumerable<User> User { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public int divWidth = 0;
        public int divLeft = 0;
        public string bColor = "";
        

        public List<Booking> BookingsList = new List<Booking>();
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            foreach(var booking in Booking)
            {
                //Skall troligen jämföras mot StartTime
                if(booking.Resource.ResId == Id && booking.StartTime.ToString("yyyy-MM-dd") == Date)
                {
                    BookingsList.Add(booking);
                }
            }

            if(BookingsList.Count == 1)
            {
                var startBooking = BookingsList[0].StartTime;
                var endBooking = BookingsList[0].StopTime;
                var startPos = getPosition(startBooking);
                var endPos = getPosition(endBooking);
                divWidth = (endPos - startPos);
                //bColor = "#ac7244";
                bColor = getColor(BookingsList[0].UserId, BookingsList[0].PeriodicId);
                TagBuilder div = new TagBuilder("div");
                div.AddCssClass("dblock dotip");
                div.MergeAttribute(
                "style",
                $"left: { startPos }px ; width: { divWidth }px; background-color: { bColor }; color: { bColor }; border-color: { bColor };");
                //$"width: { divWidth }px; background-color: { bColor }; color: { bColor }; border-color: { bColor }; ");
                
                output.Content.SetHtmlContent(div);
            }
            else if (BookingsList.Count > 1)
            {
                foreach(var booking in BookingsList)
                {
                    var startBooking = booking.StartTime;
                    var endBooking = booking.StopTime;
                    var startPos = getPosition(startBooking);
                    var endPos = getPosition(endBooking);
                    divWidth = (endPos - startPos);
                    bColor = getColor(booking.UserId, booking.PeriodicId);
                    TagBuilder div = new TagBuilder("div");
                    div.AddCssClass("dblock dotip");
                    div.MergeAttribute(
                    "style",
                    $"left: { startPos }px ; width: { divWidth }px; background-color: { bColor }; color: { bColor }; border-color: { bColor };");
                    //$"width: { divWidth }px; background-color: rgb(172,114,68); color: rgb(172,114,68); border-color: rgb(172,114,68);");

                    output.Content.AppendHtml(div);
                 
                }
            }
        }
        public string getColor(int uid, int pid)
        {
            string userColor = "";
            var bUser = User.FirstOrDefault(u => u.UserId == uid);
            if (pid == 0)
            {
                userColor = bUser.SingleColor;
            }
            else
            {
                userColor = bUser.PeriodicColor;
            }

            return userColor;
        }
        public int getPosition(DateTime time)
        {
            var startHour = time.Hour;
            var hoursPos = startHour * 4;
            var startMin = time.Minute;
            var minutesPos = startMin / 15;

            return hoursPos + minutesPos;
        }
    }
}
