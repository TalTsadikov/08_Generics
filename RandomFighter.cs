using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class RandomFighter<T> where T : struct, IComparable<T>
    {
        Deck<T> _deck;
        Dice<T> _dice;

        public RandomFighter(Deck<T> deck, Dice<T> dice)
        {
            _deck = deck;
            _dice = dice;
        }

        public void Fight()
        {
            int diceWin = 0;
            int deckWin = 0;
            int ties = 0;

            while (_deck.StartingDeck.Count > 0)
            {
                T diceResult = _dice.RandomNumber();
                T cardDrawn = _deck.StartingDeck[0];
                T deckResult;

                _deck.TryDraw(cardDrawn);
                deckResult = cardDrawn;

                int compareResult = diceResult.CompareTo(deckResult);

                if (compareResult > 0)
                {
                    diceWin++;
                }
                else if (compareResult < 0)
                {
                    deckWin++;
                }
                else
                {
                    ties++;
                }
            }

            Results(diceWin, deckWin, ties);
        }

        private void Results(int diceWins, int deckWins, int ties)
        {
            Console.WriteLine($"Die wins: {diceWins}, Deck wins: {deckWins}, Tie: {ties}");
        }
    }
}