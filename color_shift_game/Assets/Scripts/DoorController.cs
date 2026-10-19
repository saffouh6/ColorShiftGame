using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Collider doorCollider;

    void Awake()
    {
        doorCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Temas eden obje Oyuncu mu kontrol et
        if (other.CompareTag("Player"))
        {
            // Eğer Kapının Tag'i ile Oyuncunun Tag'i AYNISAYSA:
            if (gameObject.tag == other.tag)
            {
                // Is Trigger mantığıyla içinden geçmesine izin ver
                doorCollider.isTrigger = true;
                Debug.Log("Aynı renk! Geçişe izin verildi.");
            }
            else
            {
                // Farklı renkse engel olsun (duvar kalsın)
                doorCollider.isTrigger = false;
                Debug.Log("Farklı renk! Geçemezsin.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Oyuncu kapıdan tamamen çıktıktan sonra kapıyı tekrar duvar haline getir
        if (other.CompareTag("Player"))
        {
            doorCollider.isTrigger = false;
        }
    }
}