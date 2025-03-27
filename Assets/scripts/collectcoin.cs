using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public int coinValue = 1;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>(); // Trova il GameManager nella scena 
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            gameManager.AddCoin(coinValue);

            Destroy(gameObject);
        }

    }
}
