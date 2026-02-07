using Homework2.Application;
using Homework2.Core.States;
using Zenject;

namespace Homework2.Commands
{
    public class GameOverCommand : ICommand
    {
        private readonly GameStateModel _gameState;

        [Inject]
        public GameOverCommand(GameStateModel gameState)
        {
            _gameState = gameState;
        }

        public void Execute()
        {
            _gameState.SetState(GameState.GameOver);
        }
    }
}