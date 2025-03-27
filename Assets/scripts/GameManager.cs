using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalCoins = 0;

    public void AddCoin(int coinValue)
    {
        totalCoins += coinValue;
    }
}
