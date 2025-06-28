// Allows objects to be moved with the mouse pointer


using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Draggable : 
    MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, 
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] SpriteRenderer sprite;
    public static bool isDragging = false;

    public void OnPointerEnter(PointerEventData data) {
        sprite.transform.DOScale(Vector3.one * 1.15f, 0.125f);
        sprite.color = new Color(0.95f, 0.95f, 0.95f, 1);
    }

    public void OnPointerExit(PointerEventData data) {
        sprite.transform.DOScale(Vector3.one, 0.25f);
        sprite.color = Color.white;
    }

    public void OnBeginDrag(PointerEventData data) {
        isDragging = true;
    }

    public void OnDrag(PointerEventData data) {
        Vector2 pos = Camera.main.ScreenToWorldPoint(data.position);
        transform.position = pos;
    }

    public void OnEndDrag(PointerEventData data) {
        // Snap to grid
        isDragging = false;
        transform.DOMove(new Vector2(RoundToHalf(transform.position.x), Mathf.RoundToInt(transform.position.y) + 0.5f), 0.15f);
    }

    private static float RoundToHalf(float value) {
        int roundedValue = Mathf.RoundToInt(value);

        if (value > roundedValue) return roundedValue + 0.5f;
        else return roundedValue - 0.5f;
    }
}
