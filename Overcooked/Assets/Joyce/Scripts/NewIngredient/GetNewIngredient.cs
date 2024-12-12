using Unity.VisualScripting;
using UnityEngine;

public class GetNewIngredient : MonoBehaviour
{
    [SerializeField] GameObject ingredientPrefab;
    private GameObject theIngredient;
    private bool playerInRange;
    private bool ingredientIsOnBox;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
        if (collision.gameObject.tag == "Ingredient")
        {
            ingredientIsOnBox = false;
        }
    }

    private void Update()
    {
        if (playerInRange && !ingredientIsOnBox && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("function is aangeroepen");
            getNewIngredient();
        }
    }

    void getNewIngredient()
    {
        theIngredient = Instantiate(ingredientPrefab);
        ingredientIsOnBox = true;
    }
}
