using ConceptArchitect.Finance.Core;



var bank = new Bank("ICICI", 12);
bank.OpenAccount("savings","Sanjay Mall", "p@ss", 20000);
bank.OpenAccount("current","Fagun Pandya", "p@ss", 20000);
bank.OpenAccount("overdraft","Amit Singh", "p@ss", 20000);

var atm= new ATM(bank);

atm.Start();

Console.WriteLine("ATM Shutdown");
