using System.Collections.Generic;
using UnityEngine;

namespace GameOff2024.Game.Data.Entity
{
    public sealed class DeckEntity
    {
        private readonly List<CardVO> _cards;
        private int _index;

        public DeckEntity()
        {
            _cards = new List<CardVO>(CardConfig.MAX_RANK * CardConfig.SUITS.Length);

            foreach (var suit in CardConfig.SUITS)
            {
                for (int i = 1; i <= CardConfig.MAX_RANK; i++)
                {
                    _cards.Add(new CardVO(suit, i));
                }
            }
        }

        public void Refresh()
        {
            _index = 0;
            Shuffle();
        }

        /// <summary>
        /// Fisher-Yates shuffle
        /// </summary>
        private void Shuffle()
        {
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                var j = Random.Range(0, i + 1);
                (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
            }
        }

        public int Draw() => _index++;

        public CardVO GetCard(int index) => _cards[index];
    }
}