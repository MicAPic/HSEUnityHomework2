using Homework2.Core.Models;
using Zenject;

namespace Homework2.Commands
{
    public class TakeDamageCommand
    {
        private readonly PlayerStatsModel _stats;
        private readonly GameOverCommand _gameOverCommand;

        [Inject]
        public TakeDamageCommand(PlayerStatsModel stats, GameOverCommand gameOverCommand)
        {
            _stats = stats;
            _gameOverCommand = gameOverCommand;
        }

        public void Execute(int damage)
        {
            var isDead = _stats.TakeDamage(damage);

            if (isDead)
            {
                _gameOverCommand.Execute();
            }
        }
    }
}