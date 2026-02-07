using Homework2.Config;
using Homework2.Core.Models;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Homework2.UI.Views
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        [Inject] private PlayerStatsModel _stats;
        [Inject] private GameSettings _settings;

        private void Awake()
        {
            _slider.maxValue = _settings.MaxHealthPoints;
            _stats.HealthPoints
                .Subscribe(hp => _slider.value = hp)
                .AddTo(this);
        }
    }
}
