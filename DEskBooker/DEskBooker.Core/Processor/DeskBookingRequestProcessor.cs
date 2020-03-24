using DEskBooker.Core.Domain;
using System;

namespace DEskBooker.Core.Processor
{
    public class DeskBookingRequestProcessor
    {
        public DeskBookingRequestProcessor()
        {
        }

        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (null == request)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return new DeskBookingResult
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date,
            };
        }
    }
}

