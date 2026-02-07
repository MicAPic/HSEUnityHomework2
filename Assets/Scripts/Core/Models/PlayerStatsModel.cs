using Homework2.Config;
using UniRx;
using UnityEngine;
using Zenject;

namespace Homework2.Core.Models
{
    public class PlayerStatsModel
    {
        private readonly GameSettings _settings;
        private readonly ReactiveProperty<int> _healthPoints;
        private readonly ReactiveProperty<int> _coins;

        public IReadOnlyReactiveProperty<int> HealthPoints => _healthPoints;
        public IReadOnlyReactiveProperty<int> Coins => _coins;

        [Inject]
        public PlayerStatsModel(GameSettings settings)
        {
            _settings = settings;
            _healthPoints = new ReactiveProperty<int>(settings.MaxHealthPoints);
            _coins = new ReactiveProperty<int>(0);
        }

        public void Reset()
        {
            _healthPoints.Value = _settings.MaxHealthPoints;
            _coins.Value = 0;
        }

        public bool TakeDamage(int damage)
        {
            _healthPoints.Value = Mathf.Max(0, _healthPoints.Value - damage);
            return _healthPoints.Value <= 0;
        }

        public void CollectCoin()
        {
            _coins.Value++;
        }

        public bool TryHeal(int cost, int healAmount)
        {
            if (_coins.Value < cost)
            {
                return false;
            }

            _coins.Value -= cost;
            _healthPoints.Value = Mathf.Min(_healthPoints.Value + healAmount, _settings.MaxHealthPoints);
            return true;
        }
    }
}