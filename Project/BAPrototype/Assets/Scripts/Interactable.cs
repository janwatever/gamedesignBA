using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactionPrompt = "Press E to interact";
    private Transform holdPoint;
    private Rigidbody rb;
    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Drag(Transform newHoldPoint)
    {
        holdPoint = newHoldPoint;
        Debug.Log("Interacted with: " + gameObject.name);
        Vector3 targetPosition = holdPoint.position;
        
        rb.MovePosition(Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f));
        rb.isKinematic = true;
        
    }

    public void Drop()
    {
        
        rb.isKinematic = false;
    }
}
