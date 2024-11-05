using System;

namespace React_ASPNETCore.Models
{
    public class DateTimeWithTimezone
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Timezone { get; set; }

        public DateTimeWithTimezone(DateTime date, TimeSpan time, string timezone)
        {
            Date = date.Date;   // Strip time part
            Time = time;
            Timezone = timezone;
        }

        public DateTime LocalDateTime
        {
            get
            {
                return Date.Add(Time);
            }
        }

        // Method to get DateTime with the timezone offset
        public DateTimeOffset GetDateTimeOffset()
        {
            var dateTime = LocalDateTime;
            var timezoneOffset = TimeZoneInfo.FindSystemTimeZoneById(Timezone).GetUtcOffset(dateTime);

            return new DateTimeOffset(dateTime, timezoneOffset);
        }

        public override string ToString()
        {
            return $"{Date:yyy-MM-dd} {Time} {(Timezone)}";
        }
    }
}
