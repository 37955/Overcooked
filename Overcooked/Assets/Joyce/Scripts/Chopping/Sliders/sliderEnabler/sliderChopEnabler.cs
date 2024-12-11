using UnityEngine;
using UnityEngine.Rendering;

public class sliderChopEnabler : MonoBehaviour
{
    [SerializeField] stateOfIngredient stateScript;
    [SerializeField] SliderChop sliderChopScript;
    [SerializeField] GameObject theCookSliderGameObject;

    private GameObject player1;
    private GameObject player2;
    private GameObject[] chopCounters;
    private Collider playerCollider1;
    private Collider playerCollider2;
    private Collider counterCollider;
    private Collider thisObjectCollider;
    private bool isTouchingCounter;
    private bool isTouchingPlayer;

    void Start()
    {
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        chopCounters = GameObject.FindGameObjectsWithTag("chopCounter");

        playerCollider1 = player1.GetComponent<Collider>();
        playerCollider2 = player2.GetComponent<Collider>();
        thisObjectCollider = gameObject.GetComponent<Collider>();

        theCookSliderGameObject.SetActive(false);
        foreach (GameObject counters in chopCounters)
        {
            counterCollider = counters.GetComponent<Collider>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == playerCollider1)
        {
            isTouchingPlayer = true;
        }

        if (collision.collider == playerCollider2) 
        {
            isTouchingCounter = true;
        }

        if (collision.collider == counterCollider)
        {
            isTouchingCounter = true;
        }
    }

    void Update()
    {

        if (isTouchingCounter && isTouchingPlayer)
        {
            if (stateScript.canChop && Input.GetKeyDown(KeyCode.LeftControl))
            {
                theCookSliderGameObject.SetActive(true);
                sliderChopScript.isChopping = true;
            }
        }
    }
}
