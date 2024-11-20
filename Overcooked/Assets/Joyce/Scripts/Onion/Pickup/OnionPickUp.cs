using UnityEngine;

public class OnionPickUp : MonoBehaviour
{
    [SerializeField] Transform IngredientsPlace;
    [SerializeField] Transform Player;

    private bool IsHolding = false;
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < 1 && Input.GetKeyDown(KeyCode.Space))
        {
            IsHolding = true;
        }

        if (IsHolding == true)
        {
            PlayerHoldsItem();
        }
    }

    private void PlayerHoldsItem()
    {
        transform.position = IngredientsPlace.transform.position;
    }
}
