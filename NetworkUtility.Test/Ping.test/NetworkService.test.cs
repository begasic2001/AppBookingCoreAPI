using FluentAssertions;
using NetworkAbility.ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Test.Ping.test
{
    public class Network
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString() {
            // Arrange - variable , class , mocks
            
            var pingService = new NetworkService();
            
            // Act
            var result = pingService.SendPing();
            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }
    }
}
