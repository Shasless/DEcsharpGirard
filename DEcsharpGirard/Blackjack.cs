using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace DEcsharpGirard
{
    public class Ex8
    {
        public  void run()
        {
            string a = "";
            
            while (a != "q")
            {
                Console.WriteLine("Welcome in ex 8  Blackjack ");
                Blackjack bl = new Blackjack();
                bl.game();
                Console.WriteLine("press q to quit or just enter to  to do it again");
                a = Console.ReadLine();

           

            }
        }
    }

    public class Blackjack
    {
        private List<String> Deck = new List<string>(52);
        private List<String> HandP =new List<string>(52);
        private List<String> HandD =new List<string>(52);
        private int CardC=4;
        private bool loose = false;

        public void game()
        {
            initDeck();
            Shuffle();
            HandD.Add(Deck[0]);
            HandD.Add(Deck[2]);
            HandP.Add(Deck[1]);
            HandP.Add(Deck[3]);
            showHand();
            if (count(HandP) == 21)
            {
                Console.WriteLine(" BLACKJACK YOU WIN");

            }
            else
            {
                Action();
            }
            
            
        }

        private void Action()
        {
            String a = "";
            while(!loose)
            {
                Console.WriteLine(" 1 : Draw");
                Console.WriteLine(" 2 : Stop");
                a = Console.ReadLine();
                if (a == "1")
                {
                    HandP.Add(Deck[CardC]);
                    showHand();
                    CardC++;
                }
                if (a == "2")
                {
                    DealerTurn();
                    break;
                }
            }

            if (loose)
            {
                Console.WriteLine("You Burst");
            }
        }

        private void DealerTurn()
        {
            while (count(HandD) < 17)
            {
                HandD.Add(Deck[CardC]);
                CardC++;
            }
            
            Console.Write("Dealer Hand :");
            for (int i = 0; i < HandD.Count; i++)
            {
                Console.Write(HandD[i]);
                Console.Write(" ");
            }
            Console.Write(" -->");
            Console.WriteLine(count(HandD));
            
            Console.Write("Player Hand :");
            for (int i = 0; i < HandP.Count; i++)
            {
                Console.Write(HandP[i]);
                Console.Write(" ");
            }
            Console.Write(" -->");
            Console.WriteLine(count(HandP));

            if (count(HandD) == count(HandP))
            {
                Console.WriteLine("TIE");
            }else if (count(HandD) > count(HandP) && count(HandD)<=21 )
            {
                Console.WriteLine("The Dealer WIN");
            }
            else
            {
                if (count(HandD) > 21)
                {
                    Console.Write("THE DEALER BURST ");
                }
                Console.WriteLine("YOU WIN");
            }
        }
        private void showHand()
        {
            Console.Write("Dealer Hand :");
            Console.Write(HandD[0]);
            Console.WriteLine(" X");
            
            Console.Write("Player Hand :");
            for (int i = 0; i < HandP.Count; i++)
            {
                Console.Write(HandP[i]);
                Console.Write(" ");
            }
            Console.Write(" -->");
            Console.WriteLine(count(HandP));
            if (count(HandP)>21)
            {
                loose = true;
            }
            
        }
        private void initDeck()
        {
            Deck =new List<string>
            {
                // Clubs
                "AC", "KC", "QC", "JC", "TC", "9C", "8C", "7C", "6C", "5C", "4C", "3C", "2C",
                // Hearts
                "AH", "KH", "QH", "JH", "TH", "9H", "8H", "7H", "6H", "5H", "4H", "3H", "2H",
                // Spades
                "AS", "KS", "QS", "JS", "TS", "9S", "8S", "7S", "6S", "5S", "4S", "3S", "2S",
                // Diamonds
                "AD", "KD", "QD", "JD", "TD", "9D", "8D", "7D", "6D", "5D", "4D", "3D", "2D",
                
            };
            
        }

        private int count(List<String> Hand)
        {
            int n = 0;
            int b;
            char a;
            string aa;
            int ascount = 0;
            
            for (int i = 0; i < Hand.Count; i++)
            {
                a= Hand[i][0];
                aa = Char.ToString(a);
                if (aa.Contains('A')  && (n+11)<=21)
                {
                    n += 11;
                    ascount++;

                }else if (aa.Contains('A'))
                {
                    n += 1;
                }
                else
                {
                    try
                    {
                        b = Int32.Parse(aa);
                        n += b;
                    }
                    catch
                    {
                        n += 10;
                    }
                }
                
            }

            if (n > 21 && ascount>0)
            {
                n -= 10;
                ascount--;
                if (n > 21)
                {
                    n -= ascount * 10;
                }
            }

            return n;
        }
        
        private  void Shuffle()  
        {  
            int n = Deck.Count;  
            Random rng = new Random(); 
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                String v = Deck[k];  
                Deck[k] = Deck[n];  
                Deck[n] = v;  
            }  
        }
    }
}