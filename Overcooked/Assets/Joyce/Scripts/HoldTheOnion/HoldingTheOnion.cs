using UnityEngine;

public class HoldingTheOnion : MonoBehaviour
{
    [SerializeField] Vector3 placeForIngredients;
    private GameObject ingredient;
    private Rigidbody ingredientRB;
    private bool canHold;
    private bool isHolding = true;

    private void Start()
    {
        if (ingredient == null)
        {
            Debug.Log("Ingredient = null");
        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canHold)
            {
                isHolding = true;
            }
            else if(!canHold)
            {
                isHolding = false;
            }
        }

        if (isHolding)
        {
            ingredient.transform.SetParent(transform);
            ingredient.transform.localPosition = placeForIngredients;
        }
        else if (!isHolding && ingredient != null)
        {
            ingredient.transform.SetParent(null); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ingredient")
        {
            ingredient = collision.gameObject;
            canHold = true;
        }
        else
        {
            canHold = false;
        }
    }
}
