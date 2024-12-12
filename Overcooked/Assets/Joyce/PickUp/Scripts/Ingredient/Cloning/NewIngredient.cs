using UnityEngine;

public class NewIngredient : MonoBehaviour
{
    [SerializeField] GameObject TheIngredientToClone;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject IngredientBox;

    private GameObject IngredientClone;
    bool canGetIngredient;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canGetIngredient = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            canGetIngredient = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canGetIngredient)
        {
            GetNewIngredient();
        }
    }
    void GetNewIngredient()
    {
        IngredientClone = Instantiate(TheIngredientToClone);
    }
}
