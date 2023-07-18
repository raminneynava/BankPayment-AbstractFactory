// See https://aka.ms/new-console-template for more information
using AbstractFactory;

Payment payment = new Payment();


payment.OrderPayment(Payment.AvalableBank.Mellat, 100);
payment.OrderPayment(Payment.AvalableBank.Meli, 100);

Console.ReadKey();