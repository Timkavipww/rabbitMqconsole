////BetterWorksButNeedToUpgrade
//var factory = new ConnectionFactory
//{
//    HostName = RabbitMqConstants.HostName,
//    Port = RabbitMqConstants.Port,
//    UserName = RabbitMqConstants.UserName,
//    Password = RabbitMqConstants.Password,
//    VirtualHost = RabbitMqConstants.VirtualHost,
//};

//using var _connection = await factory.CreateConnectionAsync();
//using var _channel = await _connection.CreateChannelAsync();


//string queueName = "testQueue";

//await _channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

//Console.WriteLine("Введите сообщение для отправки (или 'exit' для выхода):");

//while (true)
//{
//    var input = Console.ReadLine();
//    if (input == "exit")
//        break;

//    var body = Encoding.UTF8.GetBytes(input!);

//    await _channel.BasicPublishAsync(exchange: "", routingKey: queueName, body: body);

//    Console.WriteLine($"[x] Отправлено: {input}");

//}

//var consumer = new AsyncEventingBasicConsumer(_channel);

//consumer.ReceivedAsync += async (_, ea) =>
//{
//    var body = ea.Body;
//    var message = Encoding.UTF8.GetString(body.ToArray());
//    Console.WriteLine($"[x] Получено: {message}");
//};

//await _channel.BasicConsumeAsync(queue: queueName, autoAck: true, consumer: consumer);

//Console.WriteLine("Нажмите любую клавишу для выхода...");
//Console.ReadKey();