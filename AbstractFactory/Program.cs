// See https://aka.ms/new-console-template for more information
using AbstractFactory;

Payment payment = new Payment();

payment.OrderPayment(out int orderid);

Console.ReadKey();