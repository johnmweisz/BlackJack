using System;
using System.Collections.Generic;

namespace BlackJack
{
	class Program
	{
		static void Main(string[] args)
		{

			System.Console.WriteLine("Welcome to Black Jack!");
			var again = "y";
			Boolean isGameOver = false;
			Deck deck = new Deck();
			deck.Shuffle();
			Player dealer = new Player("dealer");
			Player player = new Player("player");

			while(again == "y" && !isGameOver)
			{
				System.Console.WriteLine("New Round has started...");

				var isRoundOver = false;
				Boolean isWinner;

				var bet = 0;

				dealer.Draw(deck);
				player.Draw(deck);
				dealer.Draw(deck);
				player.Draw(deck);

				Console.WriteLine("Dealers visible card:");
				dealer.ShowSecondCard();
				Console.WriteLine("");
				Console.WriteLine("Your cards are:");
				player.ShowCards();
				Console.WriteLine("");

				//Ask for bet.
				while(true)
				{
					Console.WriteLine($"Bet between 1 and {player.coins}");
					string tryint = Console.ReadLine();
					if (Int32.TryParse(tryint, out int intBet))
					{
						bet = intBet;
					}
					else
					{
						bet = 0;
					}
					if(bet >= 1 && bet <= player.coins)
					{
						player.PlaceBet(bet);
						Console.WriteLine($"Player has {player.coins} coins remaining.");
						break;
					}
				}

				// Player draws.
				while(!isRoundOver && player.getHandScore <= 21)
				{
					// Ask if player hits or stays.
					Console.WriteLine("Hit? y/n");
					string input = Console.ReadLine();
					// If player hits, draw and show new card.
					if (input == "y"){
						Card dealtCard = player.Draw(deck);
						player.ShowCardA(dealtCard.getStringVal, dealtCard.getSuit);
					}
					// If player stays, round ends and dealer may draw.
					else
					{
						isRoundOver = true;
					}
					// Change Ace value to 1 if necessary.
					player.CheckAce();
				}

				// Dealer draws.
				while (dealer.getHandScore < 15)
				{
					dealer.Draw(deck);
					Console.WriteLine($"Dealer draws card #{dealer.getCardCount}.");
					// Change Ace value to 1 if necessary.
					dealer.CheckAce();
				}

				//Round is over, display all cards.
				Console.WriteLine("");
				Console.WriteLine("~~~~~~Dealers cards are:~~~~~~");
				dealer.ShowCards();
				Console.WriteLine($"Dealer total is {dealer.getHandScore}.");
				Console.WriteLine("");
				Console.WriteLine("~~~~~~Your cards are:~~~~~~");
				player.ShowCards();
				Console.WriteLine($"Player total is {player.getHandScore}.");
				
				// Check win condition.
				if (player.getHandScore > 21)
				{
					isWinner = false;
					player.PrintLose();
				}
				else if (dealer.getHandScore > 21)
				{
					isWinner = true;
					player.PrintWin();
				}
				else if (dealer.getHandScore == player.getHandScore)
				{
					isWinner = false;
					player.coins += bet;
					player.PrintPush();
				}
				else if (dealer.getHandScore > player.getHandScore)
				{
					isWinner = false;
					player.PrintLose();
				}
				else
				{
					isWinner = true;
					player.PrintWin();
				}

				// Clear cards and reset deck.
				player.DiscardAll();
				dealer.DiscardAll();
				deck.Reset();
				deck.Shuffle();

				//Update Coins (and reset bet).
				player.BetResult(isWinner);

				// Display winnings.
				Console.WriteLine($"Player has {player.coins} coins.");

				// Check if player can play again.
				if(player.coins <= 0)
				{
					isGameOver = true;
					break;
				}
				// Play again or end game.
				Console.WriteLine("Play again? y/n");
				again = Console.ReadLine();
			}

			// Display game end condition result.
			if (player.coins > 0 )
			{
				Console.WriteLine($"Player ended the game with {player.coins} coins.");
			}
			else
			{
				Console.WriteLine("You are broke.  Goodbye!");
			}
		}
	}
}
