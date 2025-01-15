using UnityEngine;

public class PutInPan : MonoBehaviour
{
    [SerializeField] StateCheckerIngredient stateCheckerScript;
    private bool canPutAway;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pan"))
        {
            Debug.Log("collision met de pan");
            canPutAway = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && canPutAway && stateCheckerScript.CanCook)
        {
            Debug.Log("Should destroy");
            Destroy(gameObject);
        }
    }

}
