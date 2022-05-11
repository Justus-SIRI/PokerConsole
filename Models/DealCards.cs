using System;
using System.Linq;

namespace PokerTask.Models
{
	public class DealCards: DeckOfCards
	{
		private Card[] PlayerHand { get; set; }
		private Card[] ComputerHand { get; set; }
		private Card[] SortedPlayerHand { get; set; }
		private Card[] SortedComputerHand { get; set; }

		//player will have a hand of 5 cards
		public DealCards()
		{
			PlayerHand = new Card[5];
			ComputerHand = new Card[5];
			SortedPlayerHand = new Card[5];
			SortedComputerHand = new Card[5];
		}

		public void Deal()
		{
			SetUpDeck(); //creates the deck of cards and shuffle them
			GetHand(); //populate player hand and computer hand
			SortCards();
			DisplayCards(); 
			EvaluateHands(); //Tell who won
		}

		public void GetHand()
		{
			//Get 5 cards for the player
			for (int i = 0; i < 5; i++)
				PlayerHand[i] = getDeck[i];

			//Get 5 cards for the computer
			for (int i = 5; i < 10; i++)
				ComputerHand[i - 5] = getDeck[i]; //index of the array starts from 0



		}

		public void SortCards()
		{
			var queryPlayer = from hand in PlayerHand
				orderby hand.MyValue
					select hand;

			var queryComputer = from hand in ComputerHand
				orderby hand.MyValue
				select hand;

			//player
			var index = 0;
			foreach (var element in queryPlayer.ToList())
			{
				SortedPlayerHand[index] = element;
				index++;
			}

			//computer
			index = 0;
			foreach (var element in queryComputer.ToList())
			{
				SortedComputerHand[index] = element;
				index++;
			}

		}

		public void DisplayCards()
		{
			Console.Clear();
			int x = 0; //position of the cursor we move ot left and right
			int y = 1; //position of the cursor, we move it up and down

			//display player hand
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("PLAYER'S HAND");
			for (int i = 0; i < 5; i++)
			{
				DrawCards.DrawCardOutline(x,y);
				DrawCards.DrawCardSuitValue(SortedPlayerHand[i],x , y);
				x++; //move to the right
			}

			y = 15; // 5 spaces under start drawing computer hand move the row of computer cards below the player cards
			x = 0; //reset position x
			Console.SetCursorPosition(x,14);
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("COMPUTER'S HAND");
			for (int i = 5; i < 10; i++)
			{
				DrawCards.DrawCardOutline(x,y);
				DrawCards.DrawCardSuitValue(SortedComputerHand[i - 5],x , y);
				x++; //move to the right
			}

		}

		public void EvaluateHands()
		{
			//create players computer and evaluation objects (passing SORTED hand to constructor)
			HandEvaluator playerHandEvaluator = new HandEvaluator(SortedPlayerHand);
			HandEvaluator computersHandEvaluator = new HandEvaluator(SortedComputerHand);

			//get the player's amd computer's hand
			Hand playerHand = playerHandEvaluator.EvaluateHand();
			Hand computerHand = computersHandEvaluator.EvaluateHand();

			//display each hand
			Console.WriteLine("\n\n\n\n\n Player's Hand: " + playerHand);
			Console.WriteLine("\n Computer's Hand: " + computerHand + "\n");

			//Evaluate hands
			if (playerHand > computerHand)
			{
				Console.WriteLine(" Player Wins");
			}else if (playerHand < computerHand)
			{
				Console.WriteLine(" Computer Wins");
			}
			else
			{
				//if hands are same, evaluate the values
				if(playerHandEvaluator.HandValues.Total > computersHandEvaluator.HandValues.Total)
					Console.WriteLine(" Player Wins");
				else if(playerHandEvaluator.HandValues.Total < computersHandEvaluator.HandValues.Total)
					Console.WriteLine(" Computer Wins");
				//if both have same poker hand (Eg: both have pair of queens)
				//player with the next card wins
				else if(playerHandEvaluator.HandValues.HighCard > computersHandEvaluator.HandValues.HighCard)
					Console.WriteLine(" Player Wins");
				else if(playerHandEvaluator.HandValues.HighCard < computersHandEvaluator.HandValues.HighCard)
					Console.WriteLine(" Computer Wins");
				else
					Console.WriteLine(" DRAW, NO one wins");
			}

		}

	}
}
