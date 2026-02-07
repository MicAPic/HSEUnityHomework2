using Homework2.Application;
using Homework2.Core.Models;
using Zenject;

namespace Homework2.Commands
{
    public class CollectCoinCommand : ICommand
    {
        private readonly PlayerStatsModel _stats;

        [Inject]
        public CollectCoinCommand(PlayerStatsModel stats)
        {
            _stats = stats;
        }

        public void Execute()
        {
            _stats.CollectCoin();
        }
    }
}