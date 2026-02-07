using UniRx;

namespace Homework2.Core.States
{
    public class GameStateModel
    {
        private readonly ReactiveProperty<GameState> _currentState = new(GameState.Menu);

        public IReadOnlyReactiveProperty<GameState> CurrentState => _currentState;

        public void SetState(GameState state)
        {
            _currentState.Value = state;
        }
    }
}