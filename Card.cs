namespace CardGame{
    public class Card{
        public string stringVal {get; set;}
        public string suit {get; set;}
        public int val {get; set;}
        public Card(string Suit, string StringVal, int Val){
            stringVal = StringVal;
            suit = Suit;
            val = Val;
        }
    }
}