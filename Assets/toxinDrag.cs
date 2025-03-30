using UnityEngine;

public class toxinDrag : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 origin;
    private bool dragging;
    
    void Start() {
        origin = transform.position;
        dragging = false;
    }

    private Vector3 offset;
   
    private void OnMouseDown() {
        dragging = true;
    }

    void Update() {
        if (dragging) {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            
            transform.position = new Vector3(mouse.x, mouse.y, transform.position.z);
        }
    }

    private void OnMouseUp() {
        dragging = false;
        Debug.Log("Toxin was moved");
        Debug.Log(transform.position);
        transform.position = origin;
    }
}
