using System;
using System.Collections.Generic;

namespace BlackJack
{
  class Player
  {
    private string name;
    public int coins;
    public int bet;
    private List<Card> hand = new List<Card>();
    private int handScore;

    public int getHandScore{
      get
      {
        handScore = 0;
        foreach (var card in hand)
        {
          handScore += card.getVal;
        }
        return handScore;
      } 
    }
    public int getCardCount{ get{return hand.Count;} }
    public List<Card> getCards{ get{return hand;} }

    public Player(string name){
      this.name = name;
      coins = 100;
    }

    public Card Draw(Deck deck){
      Card dealtCard = deck.Deal();
      hand.Add(dealtCard);
      handScore += dealtCard.getVal;
      return dealtCard;
    }
    public Card Discard(int index){
      if (hand[index] == null){
        return null;
      }
      Card discardedCard = hand[index];
      hand.RemoveAt(index);
      return discardedCard;
    }
    public void DiscardAll()
    {
      hand.Clear();
      handScore = 0;
    }
    public void ShowCards()
    {
      foreach (var card in hand)
      {
        ShowCardA(card.getStringVal, card.getSuit);
      }
    }
    public void ShowSecondCard()
    {
        Card SecondCard = hand[1];
        ShowCardA(SecondCard.getStringVal, SecondCard.getSuit);
    }

    public void PlaceBet(int posNum)
    {
      bet = posNum;
      coins -= bet;
    }

    public void BetResult(bool isVictorious)
    {
      if(isVictorious)
      {
        coins += bet * 2;
      }
      bet = 0;
    }

    public void CheckAce()
    {
      var hasAce = true;
      while(getHandScore > 21 && hasAce)
      {
        hasAce = false;
        foreach (var card in getCards)
        {
          if(card.getVal == 11)
          {
            card.changeVal = 1;
            hasAce = true;
            break;
          }
        }
      }
    }

    public void ShowCardA(string val, string suit) {
        string val2 = val + " ";
        if (suit == "Spades")
        {
            System.Console.WriteLine( " _______");
            System.Console.WriteLine($"|{val}     |");
            System.Console.WriteLine($"|   .   |");
            System.Console.WriteLine( "|  /.\\  |");
            System.Console.WriteLine( "| (_._) |");
            System.Console.WriteLine( "|   |   |");
            System.Console.WriteLine($"|    {val2}|");
            System.Console.WriteLine($"|_______|");
        }
        if (suit == "Diamonds")
        {
            System.Console.WriteLine( " _______");
            System.Console.WriteLine( $"|{val}     |");
            System.Console.WriteLine($"|   ^   |");
            System.Console.WriteLine( "|  / \\  |");
            System.Console.WriteLine( "|  \\ /  |");
            System.Console.WriteLine( "|   .   |");
            System.Console.WriteLine( $"|    {val2}|");
            System.Console.WriteLine("|_______|");
        }
        if (suit == "Clubs")
        {
            System.Console.WriteLine( " _______");
            System.Console.WriteLine($"|{val}     |");
            System.Console.WriteLine("|   _   |");
            System.Console.WriteLine( "|  ( )  |");
            System.Console.WriteLine( "| (_'_) |");
            System.Console.WriteLine( "|   |   |");
            System.Console.WriteLine($"|    {val2}|");
            System.Console.WriteLine($"|_______|");
        }
        if (suit == "Hearts")
        {
            System.Console.WriteLine(" _______");
            System.Console.WriteLine($"|{val}     |");
            System.Console.WriteLine("|  _ _  |");
            System.Console.WriteLine( "| ( v ) |");
            System.Console.WriteLine( "|  \\ /  |");
            System.Console.WriteLine( "|   .   |");
            System.Console.WriteLine($"|    {val2}|");
            System.Console.WriteLine("|_______|");
        }
    }
    public void PrintWin()
    {
      System.Console.WriteLine("  ___    ___ ________  ___  ___          ___       __   ________  ________   ___  ___  ___       ");
      System.Console.WriteLine(" |\\  \\  /  /|\\   __  \\|\\  \\|\\  \\        |\\  \\     |\\  \\|\\   __  \\|\\   ___  \\|\\  \\|\\  \\|\\  \\   ");
      System.Console.WriteLine(" \\ \\  \\/  / | \\  \\|\\  \\ \\  \\\\\\  \\       \\ \\  \\    \\ \\  \\ \\  \\|\\  \\ \\  \\\\ \\  \\ \\  \\ \\  \\ \\  \\  ");
      System.Console.WriteLine("  \\ \\    / / \\ \\  \\\\\\  \\ \\  \\\\\\  \\       \\ \\  \\  __\\ \\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\ \\  \\ \\  \\ \\  \\   ");
      System.Console.WriteLine("   \\/  /  /   \\ \\  \\\\\\  \\ \\  \\\\\\  \\       \\ \\  \\|\\__\\_\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\ \\__\\ \\__\\ \\__\\   ");
      System.Console.WriteLine(" __/  / /      \\ \\_______\\ \\_______\\       \\ \\____________\\ \\_______\\ \\__\\\\ \\__\\|__|\\|__|\\|__|   ");
      System.Console.WriteLine("|\\___/ /        \\|_______|\\|_______|        \\|____________|\\|_______|\\|__| \\|__|   ___  ___  ___ ");
      System.Console.WriteLine("\\|___|/                                                                           |\\__\\|\\__\\|\\__\\");
      System.Console.WriteLine("                                                                                  \\|__|\\|__|\\|__|");

    }
    public void PrintLose() 
    {
      System.Console.WriteLine("  ___    ___ ________  ___  ___          ___       ________  ________  _________  ___       ");
      System.Console.WriteLine(" |\\  \\  /  /|\\   __  \\|\\  \\|\\  \\        |\\  \\     |\\   __  \\|\\   ____\\|\\___   ___\\\\  \\      ");
      System.Console.WriteLine(" \\ \\  \\/  / | \\  \\|\\  \\ \\  \\\\\\  \\       \\ \\  \\    \\ \\  \\|\\  \\ \\  \\___|\\|___ \\  \\_\\ \\  \\     ");
      System.Console.WriteLine("  \\ \\    / / \\ \\  \\\\\\  \\ \\  \\\\\\  \\       \\ \\  \\    \\ \\  \\\\\\  \\ \\_____  \\   \\ \\  \\ \\ \\  \\    ");
      System.Console.WriteLine("   \\/  /  /   \\ \\  \\\\\\  \\ \\  \\\\\\  \\       \\ \\  \\____\\ \\  \\\\\\  \\|____|\\  \\   \\ \\  \\ \\ \\__\\   ");
      System.Console.WriteLine(" __/  / /      \\ \\_______\\ \\_______\\       \\ \\_______\\ \\_______\\____\\_\\  \\   \\ \\__\\ \\|__|   ");
      System.Console.WriteLine("|\\___/ /        \\|_______|\\|_______|        \\|_______|\\|_______|\\_________\\   \\|__|     ___ ");
      System.Console.WriteLine("\\|___|/                                                        \\|_________|            |\\__\\");
      System.Console.WriteLine("                                                                                       \\|__|");
    }
    
    public void PrintPush()
    {
      System.Console.WriteLine(" ___  _________  ________           ________          ________  ___  ___  ________  ___  ___  ___       ");
      System.Console.WriteLine("|\\  \\|\\___   ___\\   ____\\         |\\   __  \\        |\\   __  \\|\\  \\|\\  \\|\\   ____\\|\\  \\|\\  \\|\\  \\      ");
      System.Console.WriteLine("\\ \\  \\|___ \\  \\_\\ \\  \\___|_        \\ \\  \\|\\  \\       \\ \\  \\|\\  \\ \\  \\\\  \\ \\  \\___|\\ \\  \\\\  \\ \\  \\     ");
      System.Console.WriteLine(" \\ \\  \\   \\ \\  \\ \\ \\_____  \\        \\ \\   __  \\       \\ \\   ____\\ \\  \\\\  \\ \\_____  \\ \\   __  \\ \\  \\    ");
      System.Console.WriteLine("  \\ \\  \\   \\ \\  \\ \\|____|\\  \\        \\ \\  \\ \\  \\       \\ \\  \\___|\\ \\  \\\\  \\|____|\\  \\ \\  \\ \\  \\ \\__\\   ");
      System.Console.WriteLine("   \\ \\__\\   \\ \\__\\  ____\\_\\  \\        \\ \\__\\ \\__\\       \\ \\__\\    \\ \\_______\\____\\_\\  \\ \\__\\ \\__\\|__|   ");
      System.Console.WriteLine("    \\|__|    \\|__| |\\_________\\        \\|__|\\|__|        \\|__|     \\|_______|\\_________\\|__|\\|__|   ___ ");
      System.Console.WriteLine("                   \\|_________|                                             \\|_________|           |\\__\\");
      System.Console.WriteLine("                                                                                                   \\|__|");
    }

  }
}


                                                                                            
