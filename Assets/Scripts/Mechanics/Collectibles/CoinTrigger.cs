using Homework2.Commands;
using UnityEngine;
using Zenject;

namespace Homework2.Mechanics.Collectibles
{
    [RequireComponent(typeof(Collider))]
    public class CoinTrigger : MonoBehaviour
    {
        [Inject] private CollectCoinCommand _collectCoinCommand;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") is false) return;

            _collectCoinCommand.Execute();
            Destroy(gameObject); //TODO: пулить такие объекты
        }
    }
}