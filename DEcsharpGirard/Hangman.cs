using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace DEcsharpGirard
{
    public class Ex7
    {
        public  void run()
        {
            
            string a = "";
            
            while (a != "q")
            {
                Console.WriteLine("Welcome in ex 7  Hangman ");
                Hangman hg = new Hangman();
                hg.game();
                Console.WriteLine("press q to quit or just enter to play again");
                a = Console.ReadLine();

           

            }
        }
    }
    
    
     public class Hangman
    {
        private List<String> Words = new List<string>(52);
        private List<String> wrongLetter = new List<string>(5);
        private String Word;
        private String a;
        private List<int> DisLetter= new List<int>(52);
        private int disbaseletter;  
        private int life = 5;  


        public void game()
        {
            initWord();

            while (true)
            {

                Display();
         
                try
                    {
                        Console.Write("Please enter a letter to guess: ");
                        char guess = char.Parse(Console.ReadLine().ToLower());
                        if (((guess >= 'A' && guess <= 'Z') || (guess >= 'a' && guess <= 'z')))
                        {
                            VerifLetter(guess.ToString());
                        }
                        else
                        {
                            Console.WriteLine("It's not even a letter, you loose a life");
                            life--;
                        }


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }

                if (verifend() == 0)
                {
                    Console.Write("You loose, the world was ");
                    Console.WriteLine(Word);
                    break;
                }else if (verifend() == 2)
                {
                    Console.WriteLine("You Win");
                    break;
                }
                
            }
            
        }

        public void initWord()
        {
            
            Random rng = new Random(); 
            int k = rng.Next(27);  

            Words =new List<string>
            {
                "test","object","culture","curious","dance","gift","golden","governement","piano","possibility","read","remarkable","remote","require","Console","player","underscore","proper","Words","between","Strings","Right","throw","simulate","bowling","strike","spare","display"
                
            };
            Word = Words[k];

            if (Word.Length >= 10)
            {
                disbaseletter = 3;
            }else if (Word.Length >= 7)
            {
                disbaseletter = 2;
                
            }
            else
            {
                disbaseletter = 1;
            }

            while (true)
            {
       
                 k = rng.Next(Word.Length);
      
                 if(!DisLetter.Contains(k))
                 {                         

                     DisLetter.Add(k);
                     disbaseletter--;
                     if (disbaseletter == 0)
                     {
                         break;
                     }

                 }

            }
            
        }
        

        public void Display()
        {
            Console.WriteLine("WORD : ");
            for (int i = 0; i < Word.Length; i++)
            {
                if (DisLetter.Contains(i))
                {
                    Console.Write(Word[i]);
                }
                else
                {
                    Console.Write('_');
                }
            }
            Console.WriteLine(' ');

            foreach (var letter in wrongLetter)
            {
                Console.Write(' ');

                Console.Write(letter);

            }
            Console.WriteLine(' ');


        }

        private void VerifLetter(string letter)
        {
            int verifappend = DisLetter.Count;
            if (Word.Contains(letter))
            {

                for (int i = Word.IndexOf(letter); i > -1; i = Word.IndexOf(letter, i + 1))
                {
                    if (!DisLetter.Contains(i))
                    {
                        DisLetter.Add(i);
                    }
                }

                if (verifappend == DisLetter.Count)
                {
                    Console.WriteLine("You already have try this letter right ?");
                }
                else
                {
                    Console.WriteLine("Good Guess");
                }
                
                
                
            }
            else
            {
                wrongLetter.Add(letter);
                life--;
                Console.WriteLine("Wrong Guess");
            }
        }

        private int verifend()
        {
            if (life == 0)
            {
                return 0;

            }

            if (Word.Length == DisLetter.Count)
            {
                return 2;
            }

            return 1;
        }
        
        

      
    }

}