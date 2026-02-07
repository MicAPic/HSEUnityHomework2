using UnityEngine;
using Zenject;

namespace Homework2.Config
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Homework2/GameSettings")]
    public class GameSettings : ScriptableObjectInstaller<GameSettings>
    {
        [field: Header("Player")]
        [field: SerializeField] public int MaxHealthPoints { get; private set; } = 100;
        [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
        [field: SerializeField] public float JumpForce { get; private set; } = 10f;

        [field: Header("Healing")]
        [field: SerializeField] public int HealCost { get; private set; } = 10;
        [field: SerializeField] public int HealAmount { get; private set; } = 25;

        [field: Header("Gameplay")]
        [field: SerializeField] public int ObstacleDamage { get; private set; } = 10;
        [field: SerializeField] public float GameOverDelay { get; private set; } = 3f;

        [field: Header("Levels")]
        [field: SerializeField] public string[] LevelNames { get; private set; }

        public string GetNextLevelName(string currentSceneName)
        {
            var currentIndex = System.Array.IndexOf(LevelNames, currentSceneName);
            var nextIndex = currentIndex + 1;

            if (nextIndex < LevelNames.Length)
                return LevelNames[nextIndex];

            return null;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(this).AsSingle();
        }
    }
}