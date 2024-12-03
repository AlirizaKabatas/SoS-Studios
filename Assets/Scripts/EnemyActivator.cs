using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    public float activationDelay = 10f; // Ba�lang��ta bekleme s�resi
    private bool isActive = false; // Enemy'nin aktif olup olmad���
    private Collider2D enemyCollider; // Enemy collider
    private Renderer enemyRenderer; // Enemy renderer

    private EnemyShipMini enemyShipMini; // Enemy'nin hareket scripti (varsa)

    void Start()
    {
        // Componentleri al
        enemyCollider = GetComponent<Collider2D>();
        enemyRenderer = GetComponent<Renderer>();
        enemyShipMini = GetComponent<EnemyShipMini>();

        // Ba�lang��ta hareket etmeyi engelle
        if (enemyCollider != null) enemyCollider.enabled = false; // �arp��ma engellensin
        if (enemyRenderer != null) enemyRenderer.enabled = false; // G�r�n�rl�k engellensin

        // Ba�lang��ta enemy'nin hareket etmesini engelle
        if (enemyShipMini != null) enemyShipMini.enabled = false;

        // Zamanlay�c�y� ba�lat
        Invoke("ActivateEnemy", activationDelay); // Belirlenen s�re sonunda aktif et
    }

    void ActivateEnemy()
    {
        // Enemy'yi aktif hale getir
        isActive = true;

        // Collider ve Renderer'� etkinle�tir
        if (enemyCollider != null) enemyCollider.enabled = true;
        if (enemyRenderer != null) enemyRenderer.enabled = true;

        // Enemy'nin hareketini aktive et (varsa)
        if (enemyShipMini != null) enemyShipMini.enabled = true;
    }
}
