using Homework2.Config;
using Homework2.Core.States;
using Homework2.Mechanics.Services;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Homework2.UI.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        [Inject] private GameStateModel _gameState;
        [Inject] private GameSettings _gameSettings;

        private void Awake()
        {
            _playButton.OnClickAsObservable()
                .Subscribe(_ => StartGame())
                .AddTo(this);

            _exitButton.OnClickAsObservable()
                .Subscribe(_ => SceneLoaderService.QuitApplication())
                .AddTo(this);
        }

        private void StartGame()
        {
            _gameState.SetState(GameState.Playing);
            SceneLoaderService.LoadScene(_gameSettings.LevelNames[0]);
        }
    }
}
