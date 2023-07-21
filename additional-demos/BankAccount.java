

class BankAccount 
{
    int accountNumber;
    static double interestRate=10;

    public static double getInterestRate(){return interestRate;}
    public static void setInterestRate(double value){interestRate=value;}
    public int getAccountNumber(){return accountNumber;}

    public BankAccount(int accountNumber){
        this.accountNumber=accountNumber;
    }

}