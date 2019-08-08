using System;

namespace BlackJack
{
  class Card
  {
    private string stringVal;
    private string suit;
    private int val;

    public string getStringVal{ get{return stringVal;} }
    public string getSuit{ get{return suit;} }
    public int getVal{ get{return val;} }
    public int changeVal{ get{return val;} set{val = value;} }

    public Card(string stringVal, string suit, int val){
      this.stringVal = stringVal;
      this.suit = suit;
      this.val = val;
    }
  }
}