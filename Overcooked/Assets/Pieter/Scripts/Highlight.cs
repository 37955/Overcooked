using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Material defaultMaterial;
    public Material outlineMaterial;
    public float activationDistance = 5f;

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float distanceToPlayer1 = Vector3.Distance(player1.position, transform.position);
        float distanceToPlayer2 = Vector3.Distance(player2.position, transform.position);

        if (distanceToPlayer1 <= activationDistance || distanceToPlayer2 <= activationDistance)
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
        Material[] materials = meshRenderer.materials;
        if (materials[1] != material)
        {
            materials[1] = material;
            meshRenderer.materials = materials;
        }
    }
}
