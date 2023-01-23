using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Deck<T> where T : struct, IComparable<T>
    {
        protected int size;
        protected int remaining => _deck.Count;

        protected List<T> _deck;
        protected List<T> _discardPile;

        public List<T> StartingDeck
        {
            get { return _deck; }
        }

        public List<T> DiscardPile
        {
            get { return _deck; }
        }

        public Deck(int size)
        {
            this.size = size;
            _deck = new List<T>();
            _discardPile = new List<T>();
        }

        public void Shuffle()
        {
            List<T> shuffleDeck = new();
            int randomCard;

            for (int i = 0; i < _deck.Count; i++)
            {
                randomCard = Random.Shared.Next(0, _deck.Count);
                shuffleDeck.Add(_deck[randomCard]);
                _deck.RemoveAt(randomCard);
            }

            for (int i = 0; i < shuffleDeck.Count; i++)
            {
                _deck.Add(shuffleDeck[i]);
            }
        }

        public void Reshuffle()
        {
            foreach (var item in _discardPile)
            {
                _deck.Add(item);
            }

            _discardPile.Clear();
            Shuffle();
        }

        public bool TryDraw(T card)
        {
            if (_deck.Count > 0 && _deck.Contains(card))
            {
                _deck.Remove(card);
                _discardPile.Add(card);
                return true;
            }
            return false;
        }

        public T Peek()
        {
            if (_deck.Count > 0)
            {
                return _deck[0];
            }
            return default(T);
        }

        public void AddCard(T card)
        {
            _deck.Add(card);
        }
    }
}