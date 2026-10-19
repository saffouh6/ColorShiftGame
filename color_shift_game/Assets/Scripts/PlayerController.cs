using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    private Rigidbody rb;
    private Renderer playerRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerRenderer = GetComponent<Renderer>();
    }

    /*void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }*/
    void Update()
{
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    Transform cam = Camera.main.transform;
    Vector3 forward = cam.forward;
    Vector3 right = cam.right;
    forward.y = 0;
    right.y = 0;
    forward.Normalize();
    right.Normalize();

    Vector3 move = forward * v + right * h;
    rb.AddForce(move * speed);
}
   

    private void OnTriggerEnter(Collider other)
    {
        // Temas edilen sütunun tag kontrolü
        if (other.CompareTag("Red") || other.CompareTag("Blue") || other.CompareTag("Green") || other.CompareTag("Yellow"))
        {
            // Oyuncunun tag'ini sütunun tag'i ile güncelle
            gameObject.tag = other.tag;

            // Sütunun materyalini oyuncunun materyali yap
            Renderer pillarRenderer = other.GetComponent<Renderer>();
            if (pillarRenderer != null && playerRenderer != null)
            {
                playerRenderer.material = pillarRenderer.material;
            }

            Debug.Log("Yeni Rengimiz ve Tag: " + gameObject.tag);
        }

        // Bitiş alanına ulaşma kontrolü
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Level Completed!");
        }
    }
}