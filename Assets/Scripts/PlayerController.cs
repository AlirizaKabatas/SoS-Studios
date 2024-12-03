using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý

    void Update()
    {
        // WASD ile hareket
        float moveX = Input.GetAxis("Horizontal"); // A ve D veya Sol/Sað ok
        float moveY = Input.GetAxis("Vertical");   // W ve S veya Yukarý/Aþaðý ok

        // Yeni pozisyon hesaplama
        Vector2 newPosition = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // Player'ý hareket ettirme
        transform.Translate(newPosition);
    }
}
