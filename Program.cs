using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Program
    {
        public static void setupGame(List<Player> playerList){
            //how many players (2) enter names
            System.Console.WriteLine("Player 1, what is your name? ");
            string name = Console.ReadLine();
            Player player1 = new Player(name);
            System.Console.WriteLine("Player 2, what is your name? ");
            name = Console.ReadLine();
            Player player2 = new Player(name);
            //create player List
            
            playerList.Add(player1);
            playerList.Add(player2);
            return;
        }
        public static Deck setupDeck(List<Player> playerList){
            //build deck
            Deck gameDeck = new Deck();
            //deal
            for (int x = 0; x < 5; x++){
                playerList[0].draw(gameDeck);
                playerList[1].draw(gameDeck);
            }
            //flip top card
            gameDeck.topCard = gameDeck.deal();
            while (gameDeck.topCard.val == 8){
                gameDeck.cards.Add(gameDeck.topCard);
                gameDeck.topCard = gameDeck.deal();
            }
            return gameDeck;
        }
        public static void playGame(Player player, Deck gameDeck){
            System.Console.WriteLine("{0}, This is your current hand: ",player.name);
            player.showHand();
            System.Console.WriteLine("Pick the number of the card you would like to play or zero to draw.");
            string selectStr = Console.ReadLine();
            if (selectStr.Length == 0){
                selectStr = "-1";
            }
            int select = Int32.Parse(selectStr);
            if (select == 0){
                player.draw(gameDeck);
            }
            else{
                if (!player.validatePlay(select-1, gameDeck)){
                    System.Console.WriteLine("Not a valid play, try again.");
                    playGame(player, gameDeck);
                }
               
            }

        }
        public static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");\
            List<Player> playerList = new List<Player>();
            setupGame(playerList);
            Deck gameDeck = setupDeck(playerList);
            bool continueGame = true;
            while (continueGame){
                if (gameDeck.topCard.val == 8){
                    System.Console.WriteLine("The card to match is the {0} of {1}",gameDeck.topCard.stringVal, gameDeck.aSuit);
                }
                else{
                    System.Console.WriteLine("The card to match is the {0} of {1}",gameDeck.topCard.stringVal, gameDeck.topCard.suit);
                }
                playGame(playerList[0], gameDeck);
                if (playerList[0].hand.Count == 0){
                    System.Console.WriteLine("Congratulations {0}, you WON!!!!!!!!",playerList[0].name);
                    continueGame = false;
                    break;
                }
                if (gameDeck.cards.Count == 0){
                    gameDeck.reset();
                }
                if (gameDeck.topCard.val == 8){
                    System.Console.WriteLine("The card to match is the {0} of {1}",gameDeck.topCard.stringVal, gameDeck.aSuit);
                }
                else{
                    System.Console.WriteLine("The card to match is the {0} of {1}",gameDeck.topCard.stringVal, gameDeck.topCard.suit);
                }
                playGame(playerList[1], gameDeck);
                if (playerList[1].hand.Count == 0){
                    System.Console.WriteLine("Congratulations {0}, you WON!!!!!!!!",playerList[1].name);
                    continueGame = false;
                    break;
                }
                if (gameDeck.cards.Count == 0){
                    gameDeck.reset();
                }
            }
        }
    }
}
