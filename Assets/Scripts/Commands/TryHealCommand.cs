using Homework2.Application;
using Homework2.Config;
using Homework2.Core.Models;
using Zenject;

namespace Homework2.Commands
{
    public class TryHealCommand : ICommand<bool>
    {
        private readonly PlayerStatsModel _stats;
        private readonly GameSettings _settings;

        [Inject]
        public TryHealCommand(PlayerStatsModel stats, GameSettings settings)
        {
            _stats = stats;
            _settings = settings;
        }

        public bool Execute()
        {
            return _stats.TryHeal(_settings.HealCost, _settings.HealAmount);
        }
    }
}