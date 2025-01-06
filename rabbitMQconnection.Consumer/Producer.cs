public class Producer
{
    private readonly IChannel _channel;

    public Producer(IChannel channel)
    {
        _channel = channel;
    }

    public async Task SendMessageAsync(IEnumerable<string> messages )
    {
        foreach (var message in messages)
        {
            var body = Encoding.UTF8.GetBytes(message);
            await _channel.BasicPublishAsync(exchange: "", routingKey: RabbitMqConstants.QueueName, body: body);
            Console.WriteLine($"[x] Отправлено: {message}");
        }
    }
}
