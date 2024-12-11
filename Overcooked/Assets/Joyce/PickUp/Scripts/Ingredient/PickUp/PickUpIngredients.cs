using UnityEngine;
using UnityEngine.Rendering;

public class PickUpIngredients : MonoBehaviour
{
    private GameObject[] Counters;
    private PlayerSwitch targetScript;
    private GameObject IngredientPlace1;
    private GameObject IngredientPlace2;
    private GameObject player1;
    private GameObject player2;
    private bool IsHolding = true;

    Rigidbody rb;
    void Start()
    {
        targetScript = GameObject.Find("PlayerSwitch").GetComponent<PlayerSwitch>();
        Counters = GameObject.FindGameObjectsWithTag("PlaceForIngredientsToClickOn"); 
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        IngredientPlace1 = GameObject.Find("IngredientPlace1");
        IngredientPlace2 = GameObject.Find("IngredientPlace2");
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Vector3.Distance(player1.transform.position,transform.position) < 1.5f)
            {
                IsHolding = !IsHolding;
            }
        }

        if (IsHolding)
        {
            if(targetScript.activePlayer == player1) 
            {
                transform.position = IngredientPlace1.transform.position;
            }else if (targetScript.activePlayer == player2)
            {
                transform.position = IngredientPlace2.transform.position;
            }
            
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            GameObject NearestCounter = FindNearestCounter();

            if (NearestCounter != null)
            {
                float DistanceToCounter = Vector3.Distance(player1.transform.position, NearestCounter.transform.position);
                if (DistanceToCounter <= 2f)
                {
                    transform.position = NearestCounter.transform.position;
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            if (NearestCounter != null)
            {
                float DistanceToCounter = Vector3.Distance(player2.transform.position, NearestCounter.transform.position);
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