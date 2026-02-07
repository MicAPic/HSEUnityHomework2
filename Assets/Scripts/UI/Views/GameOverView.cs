using Homework2.Config;
using Homework2.Core.Models;
using Homework2.Core.States;
using Homework2.Mechanics.Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace Homework2.UI.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private Canvas _gameOverPanel;

        [Inject] private GameStateModel _gameState;
        [Inject] private GameSettings _settings;
        [Inject] private PlayerStatsModel _stats;

        private void Awake()
        {
            _gameOverPanel.enabled = false;

            _gameState.CurrentState
                .Where(state => state is GameState.GameOver)
                .Subscribe(_ => ShowGameOver())
                .AddTo(this);
        }

        private void ShowGameOver()
        {
            _gameOverPanel.enabled = true;

            Observable.Timer(System.TimeSpan.FromSeconds(_settings.GameOverDelay))
                .Merge(
                    Observable.EveryUpdate()
                        .Where(_ => Input.anyKeyDown)
                        .Take(1)
                        .Select(_ => 0L)
                )
                .Take(1)
                .Subscribe(_ => ReturnToMenu())
                .AddTo(this);
        }

        private void ReturnToMenu()
        {
            _stats.Reset();
            _gameState.SetState(GameState.Menu);
            SceneLoaderService.LoadMainMenu();
        }
    }
}
