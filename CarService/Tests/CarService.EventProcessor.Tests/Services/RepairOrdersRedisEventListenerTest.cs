using CarService.EventProcessor.Interfaces;
using CarService.EventProcessor.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Moq;
using StackExchange.Redis;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.EventProcessor.Tests.Services
{
    public class RepairOrdersRedisEventListenerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly ICommandFactory _commandFactory;
        private readonly IConnectionMultiplexer _connection;
        private readonly ISubscriber _subscriber;
        private readonly ChannelMessageQueue _channel;
        private readonly IConfiguration _configuration;
        private readonly RepairOrdersRedisEventListener _eventListener;

        private const string CONNECTION_STRING = "localhost:6379";
        private const string CHANNEL_NAME = "repairOrders";
        private const string TEST_MESSAGE = "test message";

        public RepairOrdersRedisEventListenerTest()
        {
            _mediator = new Mock<IMediator>();
            _commandFactory = new CommandFactory();
            _connection = ConnectionMultiplexer.Connect(CONNECTION_STRING);
            _subscriber = _connection.GetSubscriber();
            _channel = _subscriber.Subscribe(CHANNEL_NAME);
            _configuration = BuildConfigurationForEventListener();
            _eventListener = new RepairOrdersRedisEventListener(_configuration, _mediator.Object, _commandFactory);
        }

        private IConfiguration BuildConfigurationForEventListener()
        {
            var settings = @"{""ConnectionStrings"" : {""Redis"" : ""localhost:6379""}}";
            var builder = new ConfigurationBuilder();
            builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(settings)));

            return builder.Build();
        }

        [Fact]
        public void RedisConnection_Success()
        {
            Assert.True(_connection.IsConnected);
        }

        [Fact]
        public async Task EventListener_OnMessage_Success()
        {
            // Act
            await _subscriber.PublishAsync(CHANNEL_NAME, TEST_MESSAGE);
            var message = await _channel.ReadAsync();

            // Assert
            Assert.True(message.Message.HasValue);
            Assert.Equal(TEST_MESSAGE, message.Message.ToString());
        }
    }
}
