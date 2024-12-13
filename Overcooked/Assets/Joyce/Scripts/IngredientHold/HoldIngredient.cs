using Unity.VisualScripting;
using UnityEngine;

public class HoldIngredient : MonoBehaviour
{
    [SerializeField] float pickupRange;
    [SerializeField] Transform holdPlace;

    private GameObject CurrentIngredient;
    private bool isholding = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            togglePickupOrDrop();
        }

        if (isholding)
        {
            updateIngredientPos();
        }
    }
    private void togglePickupOrDrop()
    {
        if (!isholding)
        {
            tryPickupIngredient();
        }
        else
        {
            dropIngredient();
        }
    }
    private void tryPickupIngredient()
    {
        Collider ingredientCollider = findNearestIngredient();
        if (ingredientCollider != null)
        {
            pickupIngredient(ingredientCollider.gameObject);
        }
    }
    private Collider findNearestIngredient()
    {
        Collider[] theIngredientColls = Physics.OverlapSphere(transform.position, pickupRange);
        foreach (Collider colliders in theIngredientColls)
        {
            if (colliders.CompareTag("Ingredient"))
            {
                return colliders;
            }
        }
        return null;
    }
    private void pickupIngredient(GameObject ingredient)
    {
        CurrentIngredient = ingredient;
        isholding = true;

        Rigidbody ingredientRB = CurrentIngredient.GetComponent<Rigidbody>();
        if (ingredient != null)
        {
            ingredientRB.isKinematic = true;
        }
        updateIngredientPos();
    }
    private void updateIngredientPos()
    {
        if (CurrentIngredient != null)
        {
            CurrentIngredient.transform.position = holdPlace.position;
        }
    }
    private void dropIngredient()
    {
        if (CurrentIngredient != null)
        {
            Rigidbody ingredientRB = CurrentIngredient.GetComponent<Rigidbody>();
            ingredientRB.isKinematic= false;
        }
        CurrentIngredient = null;
        isholding = false;
    }

}