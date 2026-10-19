using UnityEngine;

public class ColorPillar : MonoBehaviour
{
    [SerializeField] private Material pillarMaterial;
    private Renderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<Renderer>();

        // Eğer Inspector'dan özel materyal atandıysa onu uygula
        if (pillarMaterial != null && meshRenderer != null)
        {
            meshRenderer.material = pillarMaterial;
        }
    }
}