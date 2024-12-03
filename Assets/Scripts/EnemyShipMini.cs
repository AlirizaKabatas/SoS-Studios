using UnityEngine;

public class EnemyShipMini : MonoBehaviour
{
    // Konumlar aras�nda ge�i� yapacak olan hedefler
    public Transform[] targetPositions; // Hedef pozisyonlar (konum1, konum2, vb.)
    public float speed = 1f;  // Ge�i�in h�z� (ne kadar yava�sa o kadar smooth olur)
    private int currentTargetIndex = 0; // �u anki hedefin indexi
    private Transform currentTarget; // �u anki hedef Transform
    private float lerpTime = 0f; // Lerp zamanlay�c�

    void Start()
    {
        // �lk hedefi ba�lat
        if (targetPositions.Length > 0)
        {
            currentTarget = targetPositions[currentTargetIndex];
        }
    }

    void Update()
    {
        // E�er hedef varsa, gemiyi ona do�ru hareket ettir
        if (currentTarget != null)
        {
            MoveSmoothlyTowardsTarget();
        }
    }

    void MoveSmoothlyTowardsTarget()
    {
        // Lerp zaman�n� art�r
        lerpTime += Time.deltaTime * speed;

        // Hedefe do�ru yumu�ak bir �ekilde hareket et
        transform.position = Vector3.Lerp(transform.position, currentTarget.position, lerpTime);

        // E�er hedefe ula��ld�ysa, bir sonraki hedefe ge�i� yap
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            // S�radaki hedefin index'ini bul ve hedefi de�i�tir
            currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
            currentTarget = targetPositions[currentTargetIndex];

            // Lerp zamanlay�c�s�n� s�f�rla
            lerpTime = 0f;
        }
    }
}
