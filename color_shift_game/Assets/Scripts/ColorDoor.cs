using UnityEngine;

public class ColorDoor : MonoBehaviour
{
    // Fiziksel çarpışma gerçekleştiğinde çalışır
    private void OnCollisionEnter(Collision collision)
    {
        // Çarpan obje oyuncu mu kontrol et
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            // Oyuncunun Tag'i ile Kapının Tag'i aynı mı?
            if (collision.gameObject.CompareTag(gameObject.tag))
            {
                // Renkler EŞLEŞİYORSA: Kapının katı engelini kaldır (Trigger yap), böylece içinden geçebiliriz!
                GetComponent<Collider>().isTrigger = true;
                Debug.Log("Renkler aynı! Kapıdan geçebilirsin.");
            }
            else
            {
                // Renkler FARKLIYSA: Kapı katı duvar olarak kalır ve oyuncuyu engeller.
                Debug.Log("Yanlış renk! Oyuncu rengi: " + collision.gameObject.tag + " - Kapı rengi: " + gameObject.tag);
            }
        }
    }

    // Oyuncu kapının içinden geçip arkasına çıktığında kapıyı tekrar katı yap
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }
}