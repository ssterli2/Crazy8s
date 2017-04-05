using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame{
    public class Deck{
        public List<Card> cards = new List<Card>();
        public string aSuit {get; set;}
        public List<Card> playedCards = new List<Card>();
        public Card topCard {get; set;
            public Deck(){
                setup();
                shuffle();
            }
            public Card deal(){
                Card temp = cards.First();
                cards.RemoveAt(0);
                return temp;
            } 
            public void setup(){
                cards = new List<Card>();
                string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
                string[] stringVals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
                foreach (string str in suits){
                    for (int i = 1; i <= 13; i++){
                        cards.Add(new Card(str, stringVals[i-1], i));
                    }
                }
            }
             public void reset(){
                cards = playedCards;
                playedCards.Clear();
                shuffle();
            }
            public void shuffle(){
                Random dealer = new Random();
                for (int i = 0; i < cards.Count; i++){
                    int idx = dealer.Next(0,cards.Count);
                    Card temp = cards[idx];
                    cards[idx] = cards[i];
                    cards[i] = temp;
                }
            }
        }
}