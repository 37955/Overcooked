using UnityEngine;

public class putIngredientInPan : MonoBehaviour
{
    ingredientCount ingredientCountScript;
    [SerializeField] stateOfIngredient stateScript;
    
    private GameObject[] thePans;
    
    private Collider panColl;

    private bool touchingPan;

    private void Start()
    {
        ingredientCountScript = FindObjectOfType<ingredientCount>();
        thePans = GameObject.FindGameObjectsWithTag("pan");
        foreach (GameObject pan in thePans)
        {
            panColl = pan.GetComponent<Collider>();
        }
    }

    private void Update()
    {
        if(touchingPan && stateScript.canCook && Input.GetKeyDown(KeyCode.LeftControl) && ingredientCountScript.ingredients <3)
        {
            Debug.Log("Object should be in the pan rn");
            ingredientCountScript.ingredients++;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == panColl)
        {
            Debug.Log("Touching the pan");
            touchingPan = true;
        }
    }
}
