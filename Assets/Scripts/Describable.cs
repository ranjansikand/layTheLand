// Allows an object to be described when hovered over


using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Describable : 
    MonoBehaviour, IPointerEnterHandler, IBeginDragHandler,
    IPointerClickHandler,  IPointerExitHandler
{
    public delegate void DescriptionEvent(string Name, string Description, Vector3 location);
    public static DescriptionEvent pointerEnter, pointerExit;

    [SerializeField] string Name;
    [SerializeField][TextArea] string Description;

    Coroutine hoverTimer;
    public static WaitForSeconds tooltipDelay = new WaitForSeconds(0.75f);

    public void OnPointerEnter(PointerEventData data) {
        hoverTimer = StartCoroutine(HoverTimerRoutine());
    }

    public void OnPointerClick(PointerEventData data) {
        StopCoroutine(hoverTimer);
        pointerExit("", "", Vector3.zero);
    }

    public void OnBeginDrag(PointerEventData data) {
        StopCoroutine(hoverTimer);
        pointerExit("", "", Vector3.zero);
    }

    public void OnPointerExit(PointerEventData data) {
        StopCoroutine(hoverTimer);
        pointerExit("", "", Vector3.zero);
    }

    IEnumerator HoverTimerRoutine() {
        yield return tooltipDelay;
        if (!Draggable.isDragging) pointerEnter(Name, Description, transform.position);
    }

}
