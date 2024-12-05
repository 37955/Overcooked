using UnityEngine;
using UnityEngine.Rendering;

public class sliderChopEnabler : MonoBehaviour
{
    [SerializeField] stateOfIngredient stateScript;
    [SerializeField] SliderChop sliderChopScript;
    [SerializeField] GameObject theCookSliderGameObject;

    private GameObject player;
    private GameObject[] chopCounters;
    private Collider playerCollider;
    private Collider counterCollider;
    private Collider thisObjectCollider;
    private bool isTouchingCounter;
    private bool isTouchingPlayer;

    void Start()
    {
        player = GameObject.Find("player");
        chopCounters = GameObject.FindGameObjectsWithTag("chopCounter");

        playerCollider = player.GetComponent<Collider>();
        thisObjectCollider = gameObject.GetComponent<Collider>();

        theCookSliderGameObject.SetActive(false);
        foreach (GameObject counters in chopCounters)
        {
            counterCollider = counters.GetComponent<Collider>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == playerCollider)
        {
            isTouchingPlayer = true;
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
