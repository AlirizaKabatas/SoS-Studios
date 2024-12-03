using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2; // D��man�n ba�lang�� sa�l���

    void OnTriggerEnter2D(Collider2D other)
    {
        // E�er �arpan obje lazer ise
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(1); // 1 hasar al
            Destroy(other.gameObject); // Lazer yok edilir
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage; // Sa�l��� azalt

        if (health <= 0)
        {
            Die(); // Sa�l�k s�f�ra ula��rsa yok ol
        }
    }

    void Die()
    {
        Destroy(gameObject); // D��man� yok et
        // Buraya patlama efekti veya ses ekleyebilirsiniz
    }
}
