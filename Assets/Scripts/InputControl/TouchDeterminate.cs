using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts
{
    public class TouchDeterminate : MonoBehaviour
    {
        [SerializeField] private LayerMask _snakeLayerMask;
        [SerializeField] private LayerMask _interactableLayerMask;

        private UnityEngine.Camera _camera;


        private void OnEnable()
        {
            InputEvents.OnStartTouch += CreateRaycast;
        }


        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }


        private void CreateRaycast(Vector2 touchPosition)
        {
            //Vector3 ray = _camera.ScreenToWorldPoint(touchPosition);
            Ray ray = _camera.ScreenPointToRay(touchPosition);

            //RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero, Mathf.Infinity, _interactableLayerMask);
            var hit = Physics2D.GetRayIntersection(ray, 100, _interactableLayerMask);

            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<IInteractable>().Interact();
            }

        }


        private void OnDisable()
        {
            InputEvents.OnStartTouch -= CreateRaycast;
        }
    }
}