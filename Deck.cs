using System;
using System.Collections.Generic;

namespace BlackJack
{
  class Deck
  {
    private List<Card> cards = new List<Card>();

    public Deck(){
      Reset();
      Shuffle();
    }

    public List<Card> Reset(){
      string[] suit = {"Clubs", "Spades", "Hearts", "Diamonds"};
      string[] stringVal = {" A", " 2", " 3", " 4", " 5", " 6", " 7", " 8", " 9", "10", " J", " Q", " K"};
      int[] val = {11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10};

      foreach (string s in suit){
        for (int i = 0; i < stringVal.Length; i++){
          Card card = new Card(stringVal[i], s, val[i]);
          cards.Add(card);
        }
      }
      return cards;
    }

    public void Shuffle(){
      Random rand = new Random();
      for (int i = cards.Count - 1; i >= 0; i--){
        int randomSpot = rand.Next(i + 1);
        Card temp = cards[i];
        cards[i] = cards[randomSpot];
        cards[randomSpot] = temp;
      }
    }

    public Card Deal(){
      int cardsIdx = cards.Count - 1;
      Card cardToDeal = cards[cardsIdx];
      cards.RemoveAt(cardsIdx);
      return cardToDeal;
    }
  }
}