using System;
using System.Collections.Generic;
using System.Text;

namespace PokerTask.Models
{
	//This class will have the suit for the card and the value, the suit being hearts, spade, diamonds or clubs and value for the value will be 2,4...10 and then Jack, queen and Ace
	public class Card
	{
		public enum SUIT
		{
			Hearts = '\u2665',
			Spades = '\u2660',
			Diamonds = '\u2666',
			Clubs = '\u2663'
		}
		public enum VALUE
		{
			Two=2,
			Three = 3,
			Four=4,
			Five=5,
			Six=6,
			Seven=7,
			Eight=8,
			Nine=9,
			Ten=10,
			Jack,
			Queen,
			King,
			Ace
		}
		//properties
		public SUIT MySuit { get; set; }
		public VALUE MyValue { get; set; }
	}
}
