using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket h�z�

    void Update()
    {
        // WASD ile hareket
        float moveX = Input.GetAxis("Horizontal"); // A ve D veya Sol/Sa� ok
        float moveY = Input.GetAxis("Vertical");   // W ve S veya Yukar�/A�a�� ok

        // Yeni pozisyon hesaplama
        Vector2 newPosition = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // Player'� hareket ettirme
        transform.Translate(newPosition);
    }
}
