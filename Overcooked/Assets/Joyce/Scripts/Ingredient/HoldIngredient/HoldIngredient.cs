using Unity.VisualScripting;
using UnityEngine;

public class HoldIngredient : MonoBehaviour
{
    [SerializeField] PlayerSwitch playerSwitchScript;
    [SerializeField] Transform holdPlace;
    [SerializeField] float pickupRange;

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
        CurrentIngredient = null;
        isholding = false;
    }

}