using System;

namespace Sea
{
    class Program
    {
        static void Main(string[] args)
        {
            Mitarbeiter mit1 = new Mitarbeiter("Leo Lustig", 11, 149, 17.5); //ersten des ersten mitarbeiter objektes


            Console.WriteLine("\nName:\t" + mit1.getName() + "\nArbeitszeit:\t" + mit1.getWHours() + "\nGehalt:\t" + mit1.getMWage() + " Euro");    //ausgabe der geforderten werte von Mitarbeiter Leo Lustig
            Console.WriteLine("\n---------------------------------------------" + "\n\nAlter Stundelohn:\t" + mit1.getHWage());                     // ausgabe des alten stunde lohn                    
            mit1.setWagebyProcent(2.5);                                                                                                             // Lohnerhöhung um 2,5 %
            Console.WriteLine("\nNeuer Stundelohn:\t" + mit1.getHWage() + "\n\n---------------------------------------------");                     // ausgabe neuer stundenlohn
            mit1.setWHours(153);                                                                                                                    // setzen der Arbeitszeit auf 153 Stunden
            Console.WriteLine("\nName:\t" + mit1.getName() + "\nArbeitszeit:\t" + mit1.getWHours() + "\nGehalt:\t" + mit1.getMWage() + " Euro");    // ausgabe der neuen Werte von Leo Lustig

            Mitarbeiter mit2 = new Mitarbeiter("Frieda Fleissig", 15, 203, 16.5);
            Console.WriteLine("\nName:\t" + mit2.getName() + "\nArbeitszeit:\t" + mit2.getWHours() + "\nGehalt:\t" + mit2.getMWage() + " Euro"); //ausgabe der geforderten werte von Mitarbeiterin Frieda Fleissig

        }


    }
}
