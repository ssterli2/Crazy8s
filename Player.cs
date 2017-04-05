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
        public Card discard(int idx){
            idx--;
            if (idx >= hand.Count || idx < 0){
                return null;
            }
            Card temp = hand[idx];
            hand.RemoveAt(idx);
            return temp;
        }
    }
}