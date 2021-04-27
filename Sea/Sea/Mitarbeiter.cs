using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea
{
    class Mitarbeiter
    {
        private string name;    // Name
        private int pNo;        //Personal Nummer
        private int wHours;     //Arbeitsstund
        private double hWage;   //StundenLohn

        public Mitarbeiter(string n, int p)     //Konstruktur zu erstellen einenes einfachen Mitarbeiterobjektes, mit den Attributen Name und Personalnummer  
        {
            this.name = n;      
            this.pNo = p;
        }
        public Mitarbeiter(string n, int p,int w, double h) //erstellen eines vollen Mitarbeiterobjektes mit allen Attributen
        {
            this.name = n;
            this.pNo = p;
            this.wHours = w;
            this.hWage = h;
        }
        
        //get und set Methoden für Arbeitsstunden(WHour work hours) auf Grund der Kapselung
        public void setWHours(int h)    
        {
            wHours = h;
        }

        public int getWHours()
        {
            return wHours;
        }



        //get und set Methoden für den Stundenlohn (HWage hoursWage)
        public void setHWage(double w)
        {
            hWage= w;
        }

        public double getHWage()
        {
            return hWage;
        }


        //get Methode für Name, soll keine set Methode haben, da der Name über den konstruktur gesetzt wird
        public string getName()
        {
            return name;
        }

        //get Methode für Personalnummer, soll keine set Methode haben, da der Personalnummer über den konstruktur gesetzt wird
        public int getPNo()
        {

            return pNo;
        
        }


        //erhöhen des Stundenlohns um eine prozentzahl, soll als dezimal zahl angeben werden
        /*
        *Zum beispiel
        *this.setWagebyProcent(2.5);
        *erhöht das Gehalt um 2,5%
        */
        public void setWagebyProcent(double pro)
        {
            double temp = hWage / 100; // 1% des Stundenlohns 

            hWage = hWage + temp * pro;
        }


        //Gibt den Lohn auf einen Monat zurück
  
        public double getMWage()    //Monatslohn
        {  
            //prüft ob ein Wert vorhanden ist, falls nicht gibt die funktion 0 zurück

            if (wHours > 0 && hWage > 0 && wHours<160)     //die vorgabe war das die Berechnung sich ab 160 Arbeitsstunden ändert,              
            {
                return wHours * hWage;                     //normale berechnung ohne zusatz zahlungen
            }
            else if (wHours > 0 && hWage > 0 && wHours > 160)
            {
                return getMWageZ();                       //berechnung vom Gehalt wenn der mitarbeiter mehr als 160 stunden gearbeitet hat
            }

            return 0;
        }

        public double getMWagewithInput(int h)    //berechnet den stundenlohn anhand einer eingabe
        { 
         
                return h * hWage;                //h stunden mal Stundenlohnn
          
        }

        public double getMWageZ()
        {
            
            int overtime180 = wHours - 180;                     //Berechnet Arbeitsstunden über 180 stunden
            int overtime = wHours - 160- overtime180;           //Berechnet Arbeitzeit zwischen 160 und 180 stunden kann durch änderung der berechnung von overtime180 angepasst werden
            double firstZins = 10;                              //prozentsatz erste zusatz zahlung bei über 160 Arbeits stunden
            double secoundZins = 5;                             //prosentsatz 2. Zusatzzahlung bei einer Abreitszeit von mehr als 180 stunden

            if (wHours<160){

                return getMWage();                              //ruft Monatslohnbetrechnung auf
            }
            else if (wHours >160 && wHours <= 180)              
            {
                //berechent gehahlt für Überstunden, und erhört diese um den Prozentsatz firstZins   || getMWagewithInput(overtime) gibt das restlich gehalt aus und addiert beides
                return getHigherValuebyProcent(getMWagewithInput(overtime), firstZins) + getMWagewithInput(overtime); 
            }
            else if(wHours>180)
            {
                double b = getHigherValuebyProcent(getMWagewithInput(overtime), firstZins);     //berechent gehahlt für Überstunden, und erhört diese um den Prozentsatz firstZins
                double a = getMWagewithInput(160);                                              //berechenen des Gehaltes für die ersten 160 arbeitszeit
                double c = getHigherValuebyProcent(getMWagewithInput(overtime180), firstZins);  //berechent gehahlt für Überstunden, und erhört diese um den Prozentsatz firstZins schritt ein, laut aufgabe und lösung des lehres soll erst um 10% erhört und dann nochmal um 5% erhöht werden bei mehr 180 stunden arbeitszeit
                c = getHigherValuebyProcent(c, secoundZins);    //zweiter Schritt, höhen umweitere 5 %
                return a + b + c;
            }
            return 0; 

        }

        public double getHigherValuebyProcent(double x,double p)    //x ist ein eingegebener Wert, zum beispiel ein gehalt. p ist ein prozentwert.  
        {                                                           //x wird um den wert faktur von p herhöt
            if(x>0){
                double temp = x / 100;
                return x + temp * p;
            }
            return 0;
        }

    }
}
