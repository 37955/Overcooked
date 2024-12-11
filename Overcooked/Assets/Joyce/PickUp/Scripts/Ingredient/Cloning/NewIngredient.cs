using UnityEngine;

public class NewIngredient : MonoBehaviour
{
    [SerializeField] GameObject TheIngredientToClone;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject IngredientBox;

    private GameObject IngredientClone;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Vector3.Distance(player1.transform.position, IngredientBox.transform.position) < 1 || Vector3.Distance(player2.transform.position, IngredientBox.transform.position) < 1)
            {
                GetNewIngredient();
            }
        }
    }

    void GetNewIngredient()
    {
        IngredientClone = Instantiate(TheIngredientToClone);
    }
}
