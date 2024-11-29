using UnityEngine;
using UnityEngine.Rendering;

public class PickUpIngredients : MonoBehaviour
{
    private GameObject[] Counters;

    private GameObject IngredientPlace;
    private GameObject Player;
    private bool IsHolding = true;

    Rigidbody rb;
    void Start()
    {
        Counters = GameObject.FindGameObjectsWithTag("PlaceForIngredientsToClickOn"); 
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        IngredientPlace = GameObject.Find("IngredientPlace");
        Player = GameObject.Find("player");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Vector3.Distance(Player.transform.position,transform.position) < 1.5f)
            {
                IsHolding = !IsHolding;
            }
        }

        if (IsHolding)
        {
            transform.position = IngredientPlace.transform.position;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            GameObject NearestCounter = FindNearestCounter();

            if (NearestCounter != null)
            {
                float DistanceToCounter = Vector3.Distance(Player.transform.position, NearestCounter.transform.position);
                if (DistanceToCounter <= 2f)
                {
                    transform.position = NearestCounter.transform.position;
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                }
            }
        }
    }

    GameObject FindNearestCounter()
    {
        GameObject TheNearest = null;
        float MinDistance = Mathf.Infinity;

        foreach (GameObject Counter in Counters)
        {
            float Distance = Vector3.Distance(transform.position, Counter.transform.position);
            if (Distance < MinDistance)
            {
                MinDistance = Distance;
                TheNearest = Counter;
            }
        }
        return TheNearest;
    }
}