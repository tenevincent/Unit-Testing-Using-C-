using DEskBooker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DEskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTests
    {

        private readonly DeskBookingRequestProcessor _processor;

        public DeskBookingRequestProcessorTests()
        {
            _processor = new DeskBookingRequestProcessor();
        }

 

        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            // Arrange
            var request = new DeskBookingRequest
            {
                FirstName = "Thomas",
                LastName = "Huber",
                Email = "vincent.tene@gmail.com",
                Date = new DateTime(2020, 03, 24)
            };

            

            // Act
            DeskBookingResult result = _processor.BookDesk(request);

            Assert.NotNull(result);
            Assert.Equal(request.FirstName, request.FirstName);
            Assert.Equal(request.LastName, request.LastName);
            Assert.Equal(request.Email, request.Email);
            Assert.Equal(request.Date, request.Date);
        }


        [Fact]
        public void ShouldThrownExceptionIfRequestIsNull()
        {
            
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));
            Assert.Equal("request", exception.ParamName);
        }
    }
}
