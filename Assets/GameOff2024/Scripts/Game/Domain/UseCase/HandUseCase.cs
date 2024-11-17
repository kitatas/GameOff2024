using System.Collections.Generic;
using System.Linq;
using GameOff2024.Game.Data.Entity;
using GameOff2024.Game.Utility;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class HandUseCase
    {
        private readonly DeckEntity _deckEntity;
        private readonly PlayerHandEntity _playerHandEntity;
        private readonly EnemyHandEntity _enemyHandEntity;

        public HandUseCase(DeckEntity deckEntity, PlayerHandEntity playerHandEntity, EnemyHandEntity enemyHandEntity)
        {
            _deckEntity = deckEntity;
            _playerHandEntity = playerHandEntity;
            _enemyHandEntity = enemyHandEntity;
        }

        public List<HandVO> GetPlayerHands()
        {
            return _playerHandEntity.hands
                .Select((v, i) => new HandVO(i, _deckEntity.GetCard(v)))
                .ToList();
        }

        public List<HandVO> GetEnemyHands()
        {
            return _enemyHandEntity.hands
                .Select((v, i) => new HandVO(i, _deckEntity.GetCard(v)))
                .ToList();
        }

        public HandVO GetPlayerHandLast() => GetPlayerHands().Last();
        public HandVO GetEnemyHandLast() => GetEnemyHands().Last();

        public bool IsPlayerScoreOver(int value) => GetPlayerHands().GetHandScore() >= value;
        public bool IsEnemyScoreOver(int value) => GetEnemyHands().GetHandScore() >= value;

        public UserAction GetEnemyAction() => IsEnemyScoreOver(17) ? UserAction.Stand : UserAction.Hit;

        public BattleResult GetResult()
        {
            var type = GetPlayerHands().GetHandScore() - GetEnemyHands().GetHandScore();
            return type switch
            {
                > 0 => BattleResult.Win,
                < 0 => BattleResult.Lose,
                0 => BattleResult.Draw,
            };
        }
    }
}