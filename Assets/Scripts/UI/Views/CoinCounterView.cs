using Homework2.Core.Models;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Homework2.UI.Views
{
    public class CoinCounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinText;

        [Inject] private PlayerStatsModel _stats;

        private void Awake()
        {
            _stats.Coins
                .Subscribe(coins => _coinText.text = $"Coins: {coins}")
                .AddTo(this);
        }
    }
}
