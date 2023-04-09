using UnityEngine;
using DG.Tweening;

public class mouseAnimation : MonoBehaviour
{
    [SerializeField] private Color _targetColor;
    [SerializeField] private float duration;

    private Renderer rendererC;

    private void Start()
    {
        rendererC = GetComponent<Renderer>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.DOMove(MousePOS(), 1f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            DOTween.Sequence()
            .Append(rendererC.material.DOColor(_targetColor, duration));
        }
        if(Input.GetKey(KeyCode.D))
        {
            Destroy(gameObject);
        }
    }

    private Vector3 MousePOS()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        new Plane(Vector3.forward, new Vector3(0f, 0f, -0.5f)).Raycast(ray, out float enter);
        return ray.GetPoint(enter);
    }
}