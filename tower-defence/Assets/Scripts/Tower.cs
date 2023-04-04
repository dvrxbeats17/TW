using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int coast = 50;

    // фабрика -> слдит за созданием обьектов
    public bool CreateTower(Tower tower, Vector3 position)
    {
        var bank = FindObjectOfType<Bank>();

        if(bank == null)
            return false;
        if (bank.CurrentBalance < coast)
            return false;

        Instantiate(tower.gameObject, position, Quaternion.identity);
        bank.WithDraw(coast);
        return true;
    }
    
}
