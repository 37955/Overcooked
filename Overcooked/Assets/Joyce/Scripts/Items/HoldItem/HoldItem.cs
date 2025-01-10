using Unity.VisualScripting;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    [SerializeField] Transform holdPlace;
    [SerializeField] float pickupRange;

    private GameObject CurrentItem;
    private bool isholding = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            togglePickupOrDrop();
        }

        if (isholding)
        {
            updateItemPos();
        }
    }
    private void togglePickupOrDrop()
    {
        if (!isholding)
        {
            tryPickupItem();
        }
        else
        {
            dropItem();
        }
    }
    private void tryPickupItem()
    {
        Collider ItemCollider = findNearestItem();
        if (ItemCollider != null)
        {
            pickupItem(ItemCollider.gameObject);
        }
    }
    private Collider findNearestItem()
    {
        Collider[] theItemColls = Physics.OverlapSphere(transform.position, pickupRange);
        foreach (Collider colliders in theItemColls)
        {
            if (colliders.gameObject.layer == LayerMask.NameToLayer("Item"))
            {
                return colliders;
            }
        }
        return null;
    }
    private void pickupItem(GameObject ingredient)
    {
        CurrentItem = ingredient;
        isholding = true;
        updateItemPos();
    }
    private void updateItemPos()
    {
        if (CurrentItem != null)
        {
            CurrentItem.transform.position = holdPlace.position;
        }
    }
    private void dropItem()
    {
        CurrentItem = null;
        isholding = false;
    }

}