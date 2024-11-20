using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class OnionClone : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject IngredientHolder;
    [SerializeField] GameObject PrebabOnion;

    private int OnionCount = 0;
    private GameObject Onion;
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, IngredientHolder.transform.transform.position) < 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NewOnion();
                OnionCount++;
            }
        }
    }

    private void NewOnion()
    {
        if (OnionCount < 1)
        {
            Onion = Instantiate(PrebabOnion);
        }
    }
}
