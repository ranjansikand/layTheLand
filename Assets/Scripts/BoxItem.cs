// Respawn after being moved


using UnityEngine;
using UnityEngine.EventSystems;

public class BoxItem : MonoBehaviour, IEndDragHandler
{
    Sandbox sandbox;
    Vector3 pos;
    bool moved = false;

    private void OnEnable() {
        pos = transform.position;
        sandbox = GameObject.FindObjectOfType<Sandbox>();
    }

    public void OnEndDrag(PointerEventData data) {
        if (!moved) {
            sandbox.Respawn(gameObject, pos);
            moved = true;
        }        
    }
}
