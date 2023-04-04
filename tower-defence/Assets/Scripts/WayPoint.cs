using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private bool isPlaycable;
    public bool IsPlaycable
    {
        get { return isPlaycable; }
    }
    [SerializeField] private Tower tower;


    private void OnMouseDown()
    {
        if (!isPlaycable)
            return;
        bool isPlaced = tower.CreateTower(tower, transform.position);
        isPlaycable = !isPlaced;
    }
}
