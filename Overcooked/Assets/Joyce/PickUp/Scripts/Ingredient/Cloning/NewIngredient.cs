using UnityEngine;

public class NewIngredient : MonoBehaviour
{
    [SerializeField] GameObject TheIngredientToClone;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject IngredientBox;

    private GameObject IngredientClone;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Vector3.Distance(Player.transform.position, IngredientBox.transform.position) < 1)
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
