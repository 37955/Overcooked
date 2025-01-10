using UnityEngine;

public class Enums : MonoBehaviour
{
    //Code Conventions: CamelCase
    private enum Ingredients
    {
        onion,
        lettuce,
        tomato
    }

    private enum Players
    {
        player1,
        player2
    }

    private enum Counters 
    {
        normalCounter,
        choppingCounter,
        cookingCounter
    }
}
