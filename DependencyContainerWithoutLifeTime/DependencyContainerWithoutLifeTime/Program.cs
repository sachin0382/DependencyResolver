using System;

namespace DependencyContainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DependencyContainer dependencyContainer = new DependencyContainer();
            dependencyContainer.AddDependency<HelloService>();
            dependencyContainer.AddDependency<ServiceConsumer>();
            dependencyContainer.AddDependency<MessageService>();

            DependencyResolver dependencyResolver = new DependencyResolver(dependencyContainer);
            var HelloService=dependencyResolver.GetService<HelloService>();
            HelloService.PrintHello();

            var serviceConsumer = dependencyResolver.GetService<ServiceConsumer>();
            serviceConsumer.PrintHello();

            Console.ReadLine();
        }
    }

    class HelloService
    {
        MessageService _messageService;
        public HelloService(MessageService messageService)
        {
            _messageService = messageService;
        }
        public void PrintHello()
        {
            Console.WriteLine($"Hello Service {_messageService.Message()}");
        }
    }

    class ServiceConsumer
    {
        private HelloService _helloService;
        public ServiceConsumer(HelloService helloService)
        {
            _helloService = helloService;
        }
        public void PrintHello()
        {
            Console.WriteLine("ServiceConsumer Called: ");
            _helloService.PrintHello();
        }
    }

    class MessageService
    {
        public string Message()
        {
            return " Message: Yo";
        }
    }
}
