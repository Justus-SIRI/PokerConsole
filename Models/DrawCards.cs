using System;
using System.Collections.Generic;
using System.Text;

namespace PokerTask.Models
{
	public class DrawCards
	{
		//draw card outlines
		public static void DrawCardOutline(int xcoor, int ycoor)
		{
			Console.ForegroundColor = ConsoleColor.Black;

			//12 is the width of the card 12 --
			int x = xcoor * 12;
			int y = ycoor;

			Console.SetCursorPosition(x,y);
			Console.Write(" __________\n"); //top edge of the card

			//________..10lines drawn
			for (int i = 0; i < 10; i++)
			{
				//offset the y
				Console.SetCursorPosition(x,y+1+i);

				Console.WriteLine(i != 9 ? "|          |" : "|__________|");
			}

		}

		public static void DrawCardSuitValue(Card card,int xcoor, int ycoor)
		{
			char cardSuit = ' ';
			int x = xcoor * 12;
			int y = ycoor;

			//encode each byte array into a character
			//heart and diamonds are red, clubs and spades are black
			switch (card.MySuit)
			{
				case Card.SUIT.Hearts:
					cardSuit = '\u2665';
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case Card.SUIT.Diamonds:
					cardSuit = '\u2666';
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case Card.SUIT.Clubs:
					cardSuit = '\u2663';
					Console.ForegroundColor = ConsoleColor.Black;
					break;
				case Card.SUIT.Spades:
					cardSuit = '\u2660';
					Console.ForegroundColor = ConsoleColor.Black;
					break;
			}

			//display the encoded character and value of the card
			Console.SetCursorPosition(x+5,y+5);
			Console.Write(cardSuit);
			Console.SetCursorPosition(x+4,y+7);
			Console.Write(card.MyValue);

		}

	}
}
