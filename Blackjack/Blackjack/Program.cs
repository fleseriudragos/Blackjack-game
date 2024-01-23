using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int carte = 0;
            string culoare = "";
            int sumaj, sumad;
            Console.WriteLine("Hello player. Welcome to a game of Blackjack.");
            string nextgame = "y";
            string acej= "";
            bool aced;
            string continua = "";
            int carte1;
            string culoare1 = "";
            do
            {
                sumad = 0;
                sumaj = 0;
                acej = "";
                aced = false;
                Console.WriteLine("The dealer dealt you the first card, which is: ");
                draw(ref carte, ref culoare);
                if (carte == 11) Console.WriteLine("The Ace of " + culoare);
                else if (carte == 12) Console.WriteLine("The Jack of " + culoare);
                else if (carte == 13) Console.WriteLine("The Queen of " + culoare);
                else if (carte == 14) Console.WriteLine("The King of " + culoare);
                else Console.WriteLine("The " + carte + " of " + culoare);
                if (carte == 11) { Console.WriteLine("Please choose if your ace should have the value 1 or 11. Type 1 for 1 and 2 for 11.");
                    acej = Console.ReadLine();
                    if (acej == "1") sumaj = sumaj + 1;
                    else sumaj = sumaj + 11;
                    acej = "";
                }
                else if (carte < 10) sumaj = sumaj + carte;
                else sumaj = sumaj + 10;//toate cartile peste 10 inafara de as au valoarea 10 la blackjack

                Console.WriteLine("The dealer dealt himself the first card.");
                draw(ref carte, ref culoare);
                carte1 = carte;
                culoare1 = culoare;
                if (carte == 11) { aced = true; sumad = sumad + carte; }
                else if (carte < 10) sumad = sumad + carte;
                else sumad = sumad + 10;//toate cartile peste 10 inafara de as au valoarea 10 la blackjack

                Console.WriteLine("The dealer dealt you the second card, which is: ");
                draw(ref carte, ref culoare);
                if (carte == 11) Console.WriteLine("The Ace of " + culoare);
                else if (carte == 12) Console.WriteLine("The Jack of " + culoare);
                else if (carte == 13) Console.WriteLine("The Queen of " + culoare);
                else if (carte == 14) Console.WriteLine("The King of " + culoare);
                else Console.WriteLine("The " + carte + " of " + culoare);
                if (carte == 11) { if (sumaj == 10) { Console.WriteLine("Congratulations! You have Blackjack! You won! Do you want to play another hand? Press y for yes and n for no.");
                        nextgame = Console.ReadLine();
                        continue; } }
                else if (carte == 11) {
                    Console.WriteLine("Please choose if your ace should have the value 1 or 11. Type 1 for 1 and 2 for 11.");
                    acej = Console.ReadLine();
                    if (acej == "1") sumaj = sumaj + 1;
                    else sumaj = sumaj + 11;
                    acej = "";
                }
                else sumaj = sumaj + carte;

                Console.WriteLine("The dealer dealt himself the second card, which is: ");
                draw(ref carte, ref culoare);
                if (carte == 11) Console.WriteLine("The Ace of " + culoare);
                else if (carte == 12) Console.WriteLine("The Jack of " + culoare);
                else if (carte == 13) Console.WriteLine("The Queen of " + culoare);
                else if (carte == 14) Console.WriteLine("The King of " + culoare);
                else Console.WriteLine("The " + carte + " of " + culoare);
                if (carte == 11) { if (aced == false) sumad = sumad + carte;
                    else sumad = sumad + 1;//transformam al doilea as in 1 automat, deoarece sarea suma peste 21
                }
                else if (carte < 10) sumad = sumad + carte;
                else sumad = sumad + 10;//toate cartile peste 10 inafara de as au valoarea 10 la blackjack

                // Verificam daca jucatorul mai doreste o carte
                continua = "d";
                while (continua == "d" && sumaj < 21)
                {
                    Console.WriteLine("Do you want to stay or draw another card? Type d to draw or anything else to stay.");
                    continua=Console.ReadLine();
                    if (continua != "d") continue;
                    Console.WriteLine("The dealer dealt you the card, which is: ");
                    draw(ref carte, ref culoare);
                    if (carte == 11) Console.WriteLine("The Ace of " + culoare);
                    else if (carte == 12) Console.WriteLine("The Jack of " + culoare);
                    else if (carte == 13) Console.WriteLine("The Queen of " + culoare);
                    else if (carte == 14) Console.WriteLine("The King of " + culoare);
                    else Console.WriteLine("The " + carte + " of " + culoare);
                    if (carte == 11)
                    {
                        if (sumaj > 10) sumaj = sumaj + 1;
                        else sumaj = sumaj + carte;
                    }
                    else sumaj = sumaj + carte;
                }
            
                if (sumaj > 21) {
                    Console.WriteLine("You lost. Do you want to play another game? Please write y for yes and n for no.");
                    nextgame = Console.ReadLine();
                    continue;
                }

                //daca jucatorul nu a sarit peste 21, e randul dealer-ului sa isi arate cartile si sa extraga
                Console.WriteLine("The dealer's first card was ");
                if (carte1 == 11) Console.WriteLine("The Ace of " + culoare1);
                else if (carte1 == 12) Console.WriteLine("The Jack of " + culoare1);
                else if (carte1 == 13) Console.WriteLine("The Queen of " + culoare1);
                else if (carte1 == 14) Console.WriteLine("The King of " + culoare1);
                else Console.WriteLine("The " + carte1 + " of " + culoare1);

                // aici e extragerea cartilor pentru dealer, pana are peste 16 scorul
                while(sumad < 17)
                {
                    Console.WriteLine("The dealer dealt himself the card, which is: ");
                    draw(ref carte, ref culoare);
                    if (carte == 11) Console.WriteLine("The Ace of " + culoare);
                    else if (carte == 12) Console.WriteLine("The Jack of " + culoare);
                    else if (carte == 13) Console.WriteLine("The Queen of " + culoare);
                    else if (carte == 14) Console.WriteLine("The King of " + culoare);
                    else Console.WriteLine("The " + carte + " of " + culoare);
                    if (carte == 11)
                    {
                        if (sumad > 10) sumad = sumad + 1;
                        else sumad = sumad + carte;
                    }
                    else sumad = sumad + carte;
                }

                if ( sumad > 21) Console.WriteLine("Congratulations! You won!");
                else if ( sumad < 22)
                {
                    if (sumaj > sumad) Console.WriteLine("Congratulations! You won!");
                    else if (sumaj < sumad) Console.WriteLine("You lost.");
                    else Console.WriteLine("It is a tie.");
                }
                
                Console.WriteLine("Do you want to play another game? Please write y for yes and n for no.");
                nextgame = Console.ReadLine();
            }while(nextgame =="y");

        }

        static public void draw(ref int a,ref string b)
        {
            Random random = new Random();
            int carte = random.Next(1, 52);
            switch (carte)
            {
                case 1:
                    a = 2;
                    b = "Hearts";
                    break;

                case 2:
                    a = 3;
                    b = "Hearts";
                    break;

                case 3:
                    a = 4;
                    b = "Hearts";
                    break;

                case 4:
                    a = 5;
                    b = "Hearts";
                    break;

                case 5:
                    a = 6;
                    b = "Hearts";
                    break;

                case 6:
                    a = 7;
                    b = "Hearts";
                    break;

                case 7:
                    a = 8;
                    b = "Hearts";
                    break;

                case 8:
                    a = 9;
                    b = "Hearts";
                    break;

                case 9:
                    a = 10;
                    b = "Hearts";
                    break;

                case 10:
                    a = 11; // Ace
                    b = "Hearts";
                    break;

                case 11:
                    a = 12; // Jack
                    b = "Hearts";
                    break;

                case 12:
                    a = 13; // Queen
                    b = "Hearts";
                    break;

                case 13:
                    a = 14; // King
                    b = "Hearts";
                    break;

                case 14:
                    a = 2;
                    b = "Spades";
                    break;

                case 15:
                    a = 3;
                    b = "Spades";
                    break;

                case 16:
                    a = 4;
                    b = "Spades";
                    break;

                case 17:
                    a = 5;
                    b = "Spades";
                    break;

                case 18:
                    a = 6;
                    b = "Spades";
                    break;

                case 19:
                    a = 7;
                    b = "Spades";
                    break;

                case 20:
                    a = 8;
                    b = "Spades";
                    break;

                case 21:
                    a = 9;
                    b = "Spades";
                    break;

                case 22:
                    a = 10;
                    b = "Spades";
                    break;

                case 23:
                    a = 11; // Ace
                    b = "Spades";
                    break;

                case 24:
                    a = 12; // Jack
                    b = "Spades";
                    break;

                case 25:
                    a = 13; // Queen
                    b = "Spades";
                    break;

                case 26:
                    a = 14; // King
                    b = "Spades";
                    break;

                case 27:
                    a = 2;
                    b = "Diamonds";
                    break;

                case 28:
                    a = 3;
                    b = "Diamonds";
                    break;

                case 29:
                    a = 4;
                    b = "Diamonds";
                    break;

                case 30:
                    a = 5;
                    b = "Diamonds";
                    break;

                case 31:
                    a = 6;
                    b = "Diamonds";
                    break;

                case 32:
                    a = 7;
                    b = "Diamonds";
                    break;

                case 33:
                    a = 8;
                    b = "Diamonds";
                    break;

                case 34:
                    a = 9;
                    b = "Diamonds";
                    break;

                case 35:
                    a = 10;
                    b = "Diamonds";
                    break;

                case 36:
                    a = 11; // Ace
                    b = "Diamonds";
                    break;

                case 37:
                    a = 12; // Jack
                    b = "Diamonds";
                    break;

                case 38:
                    a = 13; // Queen
                    b = "Diamonds";
                    break;

                case 39:
                    a = 14; // King
                    b = "Diamonds";
                    break;

                case 40:
                    a = 2;
                    b = "Clubs";
                    break;

                case 41:
                    a = 3;
                    b = "Clubs";
                    break;

                case 42:
                    a = 4;
                    b = "Clubs";
                    break;

                case 43:
                    a = 5;
                    b = "Clubs";
                    break;

                case 44:
                    a = 6;
                    b = "Clubs";
                    break;

                case 45:
                    a = 7;
                    b = "Clubs";
                    break;

                case 46:
                    a = 8;
                    b = "Clubs";
                    break;

                case 47:
                    a = 9;
                    b = "Clubs";
                    break;

                case 48:
                    a = 10;
                    b = "Clubs";
                    break;

                case 49:
                    a = 11; // Ace
                    b = "Clubs";
                    break;

                case 50:
                    a = 12; // Jack
                    b = "Clubs";
                    break;

                case 51:
                    a = 13; // Queen
                    b = "Clubs";
                    break;

                case 52:
                    a = 14; // King
                    b = "Clubs";
                    break;
            }

        }
    }
}