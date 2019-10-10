using AutoMapper;
using System;

namespace ev.lib.persistence.converters
{
    public class DateTimeToUnixTimeValueConverter : IValueConverter<DateTime, long>
    {
        public long Convert(DateTime sourceMember, ResolutionContext context)
        {
            var dto = new DateTimeOffset(sourceMember);

            return dto.ToUnixTimeMilliseconds();
        }
    }
}
