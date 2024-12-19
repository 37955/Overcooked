using Unity.VisualScripting;
using UnityEngine;

public class GetNewIngredient : MonoBehaviour
{
    [SerializeField] GameObject ingredientPrefab;

    private GameObject playerColl;
    private GameObject theClone;
    private bool canGetIngredient;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            canGetIngredient = true;
        }
        Debug.Log("Can get ingredient");
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            canGetIngredient = false;
        }
        Debug.Log("Nope you can't get ingredient");
    }

    private void Start()
    {

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
