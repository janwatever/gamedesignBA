using UnityEngine;
using Prototype.Manager;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private GameObject item;
    private InputManager _inputManager;
    private Interactable currentInteractable;

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
    }
    private void Update()
    {
        if(_inputManager.Interact)
        {
            if (currentInteractable == null)
            {
                Ray ray = new Ray(transform.position, transform.forward);
                if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactableLayer))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        Debug.Log("Started dragging");
                        currentInteractable = interactable;
                        currentInteractable.Drag(holdPoint);
                    }
                }
            }
            else
            {
                currentInteractable.Drag(holdPoint); // Continue dragging
            }
        }
        else
        {
            if (currentInteractable != null)
            {
                Debug.Log("Stopped dragging");
                currentInteractable.Drop();
                currentInteractable = null;
            }
        }
        
        // Ray ray = new Ray(transform.position, transform.forward);

        // if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactableLayer))
        // {
        //     Interactable interactable = hit.collider.GetComponent<Interactable>();

        //     if (_inputManager.Interact == true)
        //     {
        //         if (interactable != null)
        //         {
        //             Debug.Log("Left Click is pressed");
        //             interactable.Drag(holdPoint);

        //         }
        //         else
        //         {
        //             return;
        //         }
        //     }
        //     else
        //     {
        //         Debug.Log("Left Click is released");
        //         interactable.Drop();
        //     }
        // }


    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the interaction ray in the editor
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * interactRange);
    }
}
