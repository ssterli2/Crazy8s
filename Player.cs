using System;
using System.Collections.Generic;

namespace CardGame{
    public class Player{
        public string name {get; set;}
        public List<Card> hand {get; set;}
        public Player(string userName){
            hand = new List<Card>();
            name = userName;
        }
        public Card draw(Deck fromDeck){
            Card newCard = fromDeck.deal();
            hand.Add(newCard);
            return newCard;
        }
        public Card play(int idx, Deck played){
            
            if (hand[idx].val == 8){
                System.Console.WriteLine("What suit would you like to pick? ");
                played.aSuit = Console.ReadLine();
                if (played.aSuit != "Clubs" && played.aSuit != "Hearts" && played.aSuit != "Diamonds" && played.aSuit != "Spades"){
                    System.Console.WriteLine("Learn how to type, try again, this time with Clubs, Hearts, Diamonds, or Spades.");
                    play(idx, played);
                }
            }
            played.playedCards.Add(played.topCard);
            played.topCard = hand[idx];
            hand.RemoveAt(idx);
            return played.topCard;
        }
        public bool validatePlay(int idx, Deck cards){
            if (idx >= hand.Count || idx < 0){
                return false;
            }
            if (hand[idx].val == 8){
                //valid play
                play(idx, cards);
                return true;
            }
            else if (cards.topCard.val == 8){
                //check sudo suit
                if (hand[idx].suit == cards.aSuit){
                    //valid play
                    play(idx, cards);
                    return true;
                }
                else{
                    return false;
                }
            }
            else if (hand[idx].suit == cards.topCard.suit || hand[idx].val == cards.topCard.val ){
                //valid play
                play(idx, cards);
                return true;
            }
            else{
                return false;
            }
        }
        public void showHand(){
            int idx = 1;
            foreach (Card card in hand){
                System.Console.WriteLine("{0}) {1} of {2}",idx,card.stringVal,card.suit );
                idx++;
            }
        }
    }
}