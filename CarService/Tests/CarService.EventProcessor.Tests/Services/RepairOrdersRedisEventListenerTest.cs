using CarService.EventProcessor.Interfaces;
using CarService.EventProcessor.Services;
using Moq;
using StackExchange.Redis;
using System.Threading.Tasks;
using Xunit;

namespace CarService.EventProcessor.Tests.Services
{
    public class RepairOrdersRedisEventListenerTest
    {
        private readonly Mock<IConnectionMultiplexer> _connection;
        private readonly ICommandFactory _commandFactory;
        private readonly Mock<ISubscriber> _subscriber;

        private const string CHANNEL_NAME = "repairOrders";
        private const string TEST_MESSAGE = "test message";

        public RepairOrdersRedisEventListenerTest()
        {
            _connection = new Mock<IConnectionMultiplexer>();
            _subscriber = new Mock<ISubscriber>();
            _connection.Setup(c => c.GetSubscriber(null)).Returns(_subscriber.Object);
            _commandFactory = new CommandFactory();
        }

        [Fact]
        public void RedisConnection_Success()
        {
            // Arrange
            _connection.Setup(c => c.IsConnected).Returns(true);

            // Assert
            Assert.True(_connection.Object.IsConnected);
        }

        [Fact]
        public async Task EventListener_OnMessage_Success()
        {
            // Arrange
            _subscriber.Setup(s => s.PublishAsync(CHANNEL_NAME, TEST_MESSAGE, CommandFlags.None)).ReturnsAsync(1);

            // Act
            var clientsRecivedMessage = await _subscriber.Object.PublishAsync(CHANNEL_NAME, TEST_MESSAGE);

            // Assert
            Assert.True(clientsRecivedMessage != 0);
        }
    }
}
