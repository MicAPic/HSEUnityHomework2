using Zenject;
using Homework2.Commands;
using Homework2.Core.Models;
using Homework2.Core.States;

namespace Homework2.Installers
{
    public class ProjectContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerStatsModel>().AsSingle();
            Container.Bind<GameStateModel>().AsSingle();

            Container.Bind<TakeDamageCommand>().AsSingle();
            Container.Bind<CollectCoinCommand>().AsSingle();
            Container.Bind<TryHealCommand>().AsSingle();
            Container.Bind<GameOverCommand>().AsSingle();
        }
    }
}