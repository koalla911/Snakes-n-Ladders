using SnakesNLadders.Assets.Scripts.Pooler.PoolerPot;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Interactables
{
    public class InteractableVase : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _pot;
        [SerializeField] private ParticleSystem _potParticle;

        private Collider2D _collider;
        private float _disactivateTime = 3f;
        private PoolActivatePot _itemActive;


        private void OnEnable()
        {
            _collider.enabled = true;
            _pot.SetActive(true);
        }


        private void Awake()
        {
            ComponentReference();
        }


        public void ComponentReference()
        {
            _collider = gameObject.GetComponent<BoxCollider2D>();
            _itemActive = gameObject.GetComponentInParent<PoolActivatePot>();

        }


        public void Interact()
        {
            _itemActive.ItemActivate(transform);

            gameObject.SetActive(false);
        }
    }
}