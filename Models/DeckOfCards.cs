using System;
using System.Collections.Generic;
using System.Text;

namespace PokerTask.Models
{
	public class DeckOfCards: Card
	{
		private static readonly int NUM_OF_CARDS = 52;//Number of cards in the deck
		private Card[] deck; //array of all playing cards
		private static readonly int ShuffleTimes = 1000;

		public DeckOfCards()
		{
			deck = new Card[NUM_OF_CARDS];
		}
		//Get current deck
		public Card[] getDeck
		{
			get { return deck; }
		}
		//crate a deck of 52 cards: 13 Values each with 4 suits
		public void SetUpDeck()
		{
			int i = 0;
			//loop through the 4 values in SUIT
			foreach (SUIT s in Enum.GetValues(typeof(SUIT)))
			{
				//loop through face values of the card
				foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
				{
					
					deck[i] = new Card { MySuit = s, MyValue = v };//un-shuffled
					i++;
				}
			}
			//shuffle cards after populating
			ShuffleCards();
		}
		//shuffle the deck
		public void ShuffleCards()
		{
			Random rand = new Random();
			Card temp;
			//run the shuffle 1000 times
			for (int shfle_times = 0; shfle_times < ShuffleTimes; shfle_times++)
			{
				for (int i = 0; i < NUM_OF_CARDS; i++)
				{
					//swap the cards
					int secondCardIndex = rand.Next(13);//There are 13 cards of one suit
					//assign current card to temp variable
					temp = deck[i];
					deck[i] = deck[secondCardIndex];
					deck[secondCardIndex] = temp;
				}
			}
		}

	}
}
