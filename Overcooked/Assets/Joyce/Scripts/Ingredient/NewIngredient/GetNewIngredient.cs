using Unity.VisualScripting;
using UnityEngine;

public class GetNewIngredient : MonoBehaviour
{
    [SerializeField] GameObject ingredientPrefab;

    private GameObject theClone;
    private bool canGetIngredient;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            canGetIngredient = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            canGetIngredient = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canGetIngredient)
        {
            getNewIngredient();
        }
    }
    void getNewIngredient()
    {
        theClone = Instantiate(ingredientPrefab);
    }
}
