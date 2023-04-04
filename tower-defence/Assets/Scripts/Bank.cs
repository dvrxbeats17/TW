using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 250;
    [SerializeField] private TextMeshProUGUI balanceOnDisplay;

    private int _currnetBalance;
    public int CurrentBalance
    {
        get { return _currnetBalance; } 
    }
    private void Start()
    {
        _currnetBalance = startingBalance;
        UpdateBalance();
    }
    public void Deposit(int value)
    {
        _currnetBalance += Mathf.Abs(value);
        UpdateBalance();

        if(_currnetBalance >= 500)
            ReloadScene();
    }
    public void WithDraw(int value)
    {
        _currnetBalance -= Mathf.Abs(value);
        UpdateBalance();

        if (_currnetBalance < 0)
            ReloadScene();
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void UpdateBalance()
    {
        balanceOnDisplay.text = $"Gold: {_currnetBalance}";
    }
}
