using UnityEngine;

public class LazerShoot : MonoBehaviour
{
    public GameObject lazerPrefab; // Lazer prefab'�
    public Transform lazerSpawnPoint; // Lazerin ��k�� noktas�
    public float lazerSpeed = 10f; // Lazerin h�z�

    void Update()
    {
        // Mouse 1'e t�klama
        if (Input.GetMouseButtonDown(0))
        {
            ShootLazer();
        }
    }

    void ShootLazer()
    {
        // Lazer objesini spawn et
        GameObject lazer = Instantiate(lazerPrefab, lazerSpawnPoint.position, lazerSpawnPoint.rotation);

        // Lazerin Rigidbody2D'sine h�z uygula
        Rigidbody2D rb = lazer.GetComponent<Rigidbody2D>();
        rb.velocity = lazer.transform.up * lazerSpeed; // Lazer kendi local Y ekseninde hareket eder

        // Lazerin otomatik yok olma s�resi
        Destroy(lazer, 5f);
    }
}
