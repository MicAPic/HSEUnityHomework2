using Homework2.Config;
using Homework2.Core.Models;
using Homework2.Core.States;
using Homework2.Mechanics.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Homework2.Mechanics.Level
{
    [RequireComponent(typeof(Collider))]
    public class LevelFinishTrigger : MonoBehaviour
    {
        [Inject] private GameSettings _settings;
        [Inject] private GameStateModel _gameState;
        [Inject] private PlayerStatsModel _stats;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") is false) return;

            var currentScene = SceneManager.GetActiveScene().name;
            var nextLevel = _settings.GetNextLevelName(currentScene);

            if (nextLevel != null)
                SceneLoaderService.LoadScene(nextLevel);
            else
            {
                _gameState.SetState(GameState.Menu);
                _stats.Reset();
                SceneLoaderService.LoadMainMenu();
            }
        }
    }
}