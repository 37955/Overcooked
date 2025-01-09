using UnityEngine;

public class StateCheckerIngredient : MonoBehaviour
{
   [SerializeField] private bool[] statesIngredient = new bool[3];

    private void Start()
    {
        statesIngredient[0] = true;
    }
    public bool CanChop
    {
        get { return statesIngredient[0]; }
        set { statesIngredient[0] = value; }
    }

    public bool CanCook
    {
        get { return statesIngredient[1]; }
        set { statesIngredient[1] = value; }
    }

    public bool CanServe
    {
        get { return statesIngredient[2]; }
        set { statesIngredient[2] = value; }
    }
}
