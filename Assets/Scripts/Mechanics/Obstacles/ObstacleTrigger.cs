using Homework2.Commands;
using Homework2.Config;
using UnityEngine;
using Zenject;

namespace Homework2.Mechanics.Obstacles
{
    [RequireComponent(typeof(Collider))]
    public class ObstacleTrigger : MonoBehaviour
    {
        [Inject] private TakeDamageCommand _takeDamageCommand;
        [Inject] private GameSettings _settings;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player") is false) return;
            _takeDamageCommand.Execute(_settings.ObstacleDamage);
        }
    }
}