//----- C# II (Dor Ben Dor) ------
//          Tal Tsadikov
//--------------------------------

using Generics;

Deck<int> deck = new Deck<int>(40);

for (int i = 0; i < 40; i++)
{
    deck.AddCard(Random.Shared.Next(1, 20));
}

IntDice dice = new IntDice(1, 20);
RandomFighter<int> fighter = new RandomFighter<int>(deck, dice);

fighter.Fight();