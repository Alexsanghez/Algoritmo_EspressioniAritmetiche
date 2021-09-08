using System;
using System.Text;
using System.Collections.Generic;

namespace Parenthesis_Check
{
    class Program
    {


        static void Main(string[] args)
        {   
            //Metto in input una stringa
            string equation = Console.ReadLine();
            //Eseguo le due funzioni
            controlloParentesi(equation);
            controlloEquazione(equation);

        }

        // Funzione per capire se la stringa in input possiede parentesi bilanciate,
        static void controlloParentesi(string equ)
        {   
            // Creo uno stack dove impilare le parentesi
            Stack<char> equationElements = new Stack<char>();
            
            foreach (char element in equ)
            {
                //Controllo se ci sono parentesi e a seconda se e aperta o chiusa faccio un pop o un push dell ostack
                if (element == '(' || element == '[' || element == '{')
                {
                    if (element == '{' && equationElements.Count != 0 && equationElements.Peek() != '{')
                    {
                        break;
                    }
                    equationElements.Push(element);
                }

                else
                {
                    if ((element == ')' || element == ']' || element == '}') && equationElements.Count == 0)
                    {
                        equationElements.Push(element);
                        Console.WriteLine("Errore");
                        break;
                    }
                    else if (element == ')' && equationElements.Peek() == '(')
                    {
                        equationElements.Pop();
                    }
                    else if (element == ']' && equationElements.Peek() == '[')
                    {
                        equationElements.Pop();
                    }
                    else if (element == '}' && equationElements.Peek() == '{')
                    {
                        equationElements.Pop();
                    }


                }



            }
            Console.WriteLine(equationElements.Count == 0 ? "Parentesi bilanciate" : "Parentesi non bilanciate");
        }

        // Funzione per determinare se l'equazione e' uguale 
        static void controlloEquazione(string equazione)
        {    //Controllo se la stringa e' un equazione
            if(equazione.Contains('=')){
            //Creo un array per dividere in due parti la stringa    
            string[] membri = equazione.Split(" = ");
            
            StringBuilder stringafinale = new StringBuilder();

            //Per ogni elemento dell'array escludo spazi e parentesi
            foreach (var item in equazione)
            {
                if (item != '(' && item != ')' && item != '[' && item != ']' && item != '{' && item != '}' && item != ' ')
                {
                    stringafinale.Append(item);

                }

            }

            //Alla fine controllo se le due stringhe sono uguali 
            string[] stringadivisa = stringafinale.ToString().Split('=');
            Console.WriteLine(stringadivisa[0] == stringadivisa [1]? "Ambo i membri sono uguali":"I membri jnon sono uguali");
            }
            else{
               Console.WriteLine("Non hai inserito un'equazione");
            }
        }
    }
}
