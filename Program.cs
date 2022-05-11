using System;
using PokerTask.Models;

namespace PokerTask
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//DrawCards.DrawCardOutline(0,0);

			//Card card = new Card();

			//card.MySuit = Card.SUIT.Hearts;
			//card.MyValue = Card.VALUE.Ace;

			//DrawCards.DrawCardSuitValue(card,0,0);

			//Console.ReadKey();
			Console.BackgroundColor = ConsoleColor.White;
			Console.Title = "Poker Game";
			DealCards dc = new DealCards();

			dc.Deal();


		}
	}
}
