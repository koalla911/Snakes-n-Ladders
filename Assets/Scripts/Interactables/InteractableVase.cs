using SnakesNLadders.Assets.Scripts.Pooler.PoolerPot;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Interactables
{
    public class InteractableVase : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _pot;
        [SerializeField] private ParticleSystem _potParticle;

        private PoolActivateCoin _poolActivateCoin;
        private Collider2D _collider;
        private float _disactivateTime = 3f;


        private void Awake()
        {
            ComponentReference();
        }


        public void ComponentReference()
        {
            _poolActivateCoin = gameObject.GetComponent<PoolActivateCoin>();
            _collider = gameObject.GetComponent<BoxCollider2D>();
        }


        public void Interact()
        {
            StartCoroutine(_poolActivateCoin.SetActiveCoroutineCoin());
            _collider.enabled = false;
            _pot.SetActive(false);
            _potParticle.Play();

            StartCoroutine(Utils.DisableAfterSeconds(_disactivateTime, gameObject));
        }
    }
}