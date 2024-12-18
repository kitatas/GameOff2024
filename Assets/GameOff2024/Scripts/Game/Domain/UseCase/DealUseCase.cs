using GameOff2024.Game.Data.Entity;
using GameOff2024.Game.Domain.Repository;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class DealUseCase
    {
        private readonly DeckEntity _deckEntity;
        private readonly PlayerHandEntity _playerHandEntity;
        private readonly EnemyHandEntity _enemyHandEntity;
        private readonly UpsetEntity _upsetEntity;
        private readonly CardRepository _cardRepository;

        public DealUseCase(DeckEntity deckEntity, PlayerHandEntity playerHandEntity, EnemyHandEntity enemyHandEntity,
            UpsetEntity upsetEntity, CardRepository cardRepository)
        {
            _deckEntity = deckEntity;
            _playerHandEntity = playerHandEntity;
            _enemyHandEntity = enemyHandEntity;
            _upsetEntity = upsetEntity;
            _cardRepository = cardRepository;
        }

        public void Init()
        {
            _deckEntity.Build(_cardRepository.FindsAll());
        }

        public void SetUp()
        {
            _deckEntity.Refresh();
            _playerHandEntity.Clear();
            _enemyHandEntity.Clear();
            _upsetEntity.SetUp(_deckEntity.Draw());

            // 初期カード配布
            for (int i = 0; i < GameConfig.INIT_CARD_NUM; i++)
            {
                DealToPlayer();
                DealToEnemy();
            }
        }

        public void DealToPlayer()
        {
            _playerHandEntity.Add(_deckEntity.Draw());
        }

        public void DealToEnemy()
        {
            _enemyHandEntity.Add(_deckEntity.Draw());
        }

        public CardVO GetSecretCard() => _deckEntity.GetCard(_upsetEntity.index);

        public void ActivateUpset()
        {
            _upsetEntity.SetUpset(true);
        }
    }
}