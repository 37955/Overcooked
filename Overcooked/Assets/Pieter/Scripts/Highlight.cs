using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the Inspector
    public Material defaultMaterial; // Assign the default material in the Inspector
    public Material outlineMaterial; // Assign the outline material in the Inspector
    public float activationDistance = 5f; // Distance at which the outline is enabled

    private MeshRenderer meshRenderer;

    void Start()
    {
        // Get the MeshRenderer
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // Check the distance between the player and this object
        float distance = Vector3.Distance(player.position, transform.position);

        // Enable outline material if within range, otherwise disable
        if (distance <= activationDistance)
        {
            SetMaterial(outlineMaterial);
        }
        else
        {
            SetMaterial(defaultMaterial);
        }
    }

    void SetMaterial(Material material)
    {
        // Update only the outline material slot (assuming it's at Element 1)
        Material[] materials = meshRenderer.materials;
        if (materials[1] != material) // Check to avoid redundant assignments
        {
            materials[1] = material;
            meshRenderer.materials = materials;
        }
    }
}
