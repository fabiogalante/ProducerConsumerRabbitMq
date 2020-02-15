using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using(var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("NomeFila", false, false, false, null);


                const string message = "Mensagem que vai para a fila";
                var body = Encoding.UTF8.GetBytes(message);


                channel.BasicPublish("", "RoutingKeyNome", null, body);
                Console.WriteLine("Enviando mensagem {0}", message);
            }





            Console.WriteLine("Pressione [enter] para sair");
        }
    }
}
