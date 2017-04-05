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
            idx--;
            if (idx >= hand.Count || idx < 0){
                return null;
            }
            Card temp = hand[idx];
            played.topCard = temp;
            hand.RemoveAt(idx);
            return temp;
        }
        public bool validatePlay(int idx, Deck cards){
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
    }
}