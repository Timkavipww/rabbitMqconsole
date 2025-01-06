var factory = new ConnectionFactory
{
    HostName = RabbitMqConstants.HostName,
    Port = RabbitMqConstants.Port,
    UserName = RabbitMqConstants.UserName,
    Password = RabbitMqConstants.Password,
    VirtualHost = RabbitMqConstants.VirtualHost,
};

using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(
    queue: RabbitMqConstants.QueueName,
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var producer = new Producer(channel);
var consumer = new Consumer(channel);

await consumer.StartListeningAsync();

var messageQueue = new List<string>();
Console.WriteLine("Введите сообщение для отправки (или 'exit' для выхода):");
while (true)
{
    var input = Console.ReadLine();
    if (input == "exit")
        break;
    messageQueue.Add(input!);
    Console.WriteLine($"[x] Сообщение добавлено в очередь: {input}");
}
Console.WriteLine("Отправка сообщений...");

await producer.SendMessageAsync(messageQueue);

Console.WriteLine("Нажмите любую клавишу для выхода...");
Console.ReadKey();
