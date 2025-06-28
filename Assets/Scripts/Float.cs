// Float up and down


using UnityEngine;
using DG.Tweening;

public class Float : MonoBehaviour
{
    [SerializeField] float motionAmount = -0.15f, time = 0.25f;

    private void Start() {
        transform.DOLocalMoveY(transform.localPosition.y + motionAmount, time).SetLoops(-1);
    }
}
