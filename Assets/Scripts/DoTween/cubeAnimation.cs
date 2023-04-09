using UnityEngine;
using DG.Tweening;

public class cubeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _dotweenObject;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float duration;

    private Renderer rendererC;

    private void Start()
    {
        rendererC = GetComponent<Renderer>();
        DOTween.Sequence()
            .Append(rendererC.material.DOColor(_targetColor, duration)).SetDelay(2f)
            .AppendInterval(5f)
            .AppendCallback(EndAnimation);

        transform.DOMove(new Vector3(5f, 2f, -0.5f), 2f);
        transform.DORotate(new Vector3(0f, 90f, 180f), 3f).SetDelay(2f);
        transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), 1.5f).SetDelay(2f);

        transform.DOMove(new Vector3(0f, 0f, 0f), 2f).SetDelay(4.1f);
        transform.DORotate(new Vector3(0f, 0f, 0f), 3f).SetDelay(4.1f);
        transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1.5f).SetDelay(4.1f);
    }

    private void EndAnimation()
    {
        Destroy(gameObject);
    }

}