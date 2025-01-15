using UnityEngine;

public class PutInPan : MonoBehaviour
{
    [SerializeField] StateCheckerIngredient stateCheckerScript;
    [SerializeField] IngredientCollisionDetector collisionDetectorScript;
    HoldIngredientCount holdIngredientCountScript;
    private void Start()
    {
        holdIngredientCountScript = FindObjectOfType<HoldIngredientCount>();

        if (holdIngredientCountScript != null)
        {
            Debug.Log("Wel script");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && collisionDetectorScript.TouchesPan && stateCheckerScript.CanCook && holdIngredientCountScript.ingredientCount < 3)
        {
            Debug.Log("Should destroy");
            Destroy(gameObject);
            holdIngredientCountScript.ingredientCount ++;
        }
    }

}
