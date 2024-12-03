using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket h�z�
    public Vector2 screenBounds; // Ekran s�n�rlar�
    public Collider2D boundaryCollider; // S�n�rlar� belirleyen collider (edit�rden atanacak)

    private Vector2 objectSize;

    void Start()
    {
        objectSize = GetComponent<SpriteRenderer>().bounds.extents; // Geminin boyutu
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        // WASD ile hareket
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 newPosition = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // Yeni pozisyon hesapla ve s�n�rla
        Vector3 nextPosition = transform.position + (Vector3)newPosition;

        // Ekran s�n�rlar�yla oyuncuyu s�n�rlama
        nextPosition.x = Mathf.Clamp(nextPosition.x, -screenBounds.x + objectSize.x, screenBounds.x - objectSize.x);
        nextPosition.y = Mathf.Clamp(nextPosition.y, -screenBounds.y + objectSize.y, screenBounds.y - objectSize.y);

        // Collider s�n�rlar�yla oyuncuyu s�n�rla
        if (boundaryCollider != null)
        {
            Vector3 colliderMin = boundaryCollider.bounds.min;
            Vector3 colliderMax = boundaryCollider.bounds.max;

            nextPosition.x = Mathf.Clamp(nextPosition.x, colliderMin.x + objectSize.x, colliderMax.x - objectSize.x);
            nextPosition.y = Mathf.Clamp(nextPosition.y, colliderMin.y + objectSize.y, colliderMax.y - objectSize.y);
        }

        // Pozisyonu uygula
        transform.position = nextPosition;
    }
}
