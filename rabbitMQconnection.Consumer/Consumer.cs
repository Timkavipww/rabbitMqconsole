public class Consumer
{
    private readonly IChannel _channel;

    public Consumer(IChannel channel)
    {
        _channel = channel;
    }

    public async Task StartListeningAsync()
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.ReceivedAsync += async (_, ea) =>
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            Console.WriteLine($"[x] Получено: {message}");
            await Task.Delay(0);
        };

        await _channel.BasicConsumeAsync(queue: RabbitMqConstants.QueueName, autoAck: true, consumer: consumer);
    }
}
