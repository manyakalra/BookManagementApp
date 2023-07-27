using ConceptArchitect.Finance.Core;



var bank = new Bank("ICICI", 12);
bank.OpenAccount("Sanjay Mall", "p@ss", 20000);
bank.OpenAccount("Fagun Pandya", "p@ss", 20000);
bank.OpenAccount("Amit Singh", "p@ss", 20000);

var atm= new ATM(bank);

atm.Start();

Console.WriteLine("ATM Shutdown");
