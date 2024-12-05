using UnityEngine;

public class stateOfIngredient : MonoBehaviour
{
    public bool canChop;
    public bool canCook;
    public bool canServe;

    void Start()
    {
        canChop = true;
        canCook = false;
        canServe = false;
    }
}
