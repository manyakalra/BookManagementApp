public class Program {
    public static void main(String[]args){
        BankAccount a1=new BankAccount(1);
        BankAccount a2=new BankAccount(2);

        //What we should do
        BankAccount.setInterestRate(15);

        System.out.println(a1.getAccountNumber());
        System.out.println(a1.getInterestRate());
        System.out.println(a2.getInterestRate());

        //what we shouldn't do but can still do
        a1.setInterestRate(20);
        
        System.out.println(a1.getInterestRate());
        System.out.println(a2.getInterestRate());
        
    }
}
