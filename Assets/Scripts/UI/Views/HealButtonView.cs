using Homework2.Commands;
using Homework2.Config;
using Homework2.Core.Models;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Homework2.UI.Views
{
    public class HealButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _healCostText;

        [Inject] private PlayerStatsModel _stats;
        [Inject] private GameSettings _settings;
        [Inject] private TryHealCommand _tryHealCommand;

        private void Awake()
        {
            _healCostText.text = $"-{_settings.HealCost}";
            _stats.Coins
                .Subscribe(coins => _button.interactable = coins >= _settings.HealCost)
                .AddTo(this);

            _button.OnClickAsObservable()
                .Subscribe(_ => _tryHealCommand.Execute())
                .AddTo(this);
        }
    }
}
