using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerHealth = 3; // Oyuncu can�
    public int enemyHealth = 3; // D��man can�

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerTakeDamage()
    {
        playerHealth--;
        if (playerHealth <= 0)
        {
            GameOver();
        }
    }

    public void EnemyTakeDamage(EnemyShipMini enemy)
    {
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            Destroy(enemy.gameObject);
        }
    }

    void GameOver()
    {
        Debug.Log("Oyun Bitti!");
        // Oyun biti� ekran� ekle
    }
}
