// Controls the tooltip


using UnityEngine;
using DG.Tweening;
using TMPro;

public class Tooltip : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text header, description;

    private void OnEnable() {
        Describable.pointerEnter += PointerEnter;
        Describable.pointerExit += PointerExit;
    }

    private void OnDisable() {
        Describable.pointerEnter -= PointerEnter;
        Describable.pointerExit -= PointerExit;
    }

    private void PointerEnter(string Name, string Description, Vector3 pos) {
        panel.SetActive(true);
        panel.transform.localScale = Vector3.zero;

        panel.transform.DOScale(Vector3.one * 1.25f, 0.125f).OnComplete(
            () => panel.transform.DOScale(Vector3.one, 0.25f)
        );

        header.text = Name;
        description.text = Description;

        panel.transform.position = CalculatePosition(new Vector3(pos.x, pos.y - 2f, 0));
    }

    private void PointerExit(string Name, string Description, Vector3 pos) {
        panel.transform.DOScale(Vector3.one * 1.1f, 0.05f).OnComplete(
            () => panel.transform.DOScale(Vector3.zero, 0.1f).OnComplete(
                () => panel.SetActive(false)
            )
        );
    }

    private Vector2 CalculatePosition(Vector2 pos) {
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane))
            + (3 * Vector3.one);
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane))
            + (-3 * Vector3.one);

        return new Vector3(Mathf.Clamp(
            pos.x, bottomLeft.x, topRight.x), 
            Mathf.Clamp(pos.y, bottomLeft.y, topRight.y), 
            0
        );
    }
}
