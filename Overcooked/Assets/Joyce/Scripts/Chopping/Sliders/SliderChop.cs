using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderChop : MonoBehaviour
{
    [SerializeField] stateOfIngredient stateScript;
    [SerializeField] Slider theSlider;
    [SerializeField] float decreaseValue;

    private GameObject theSliderGameObject;
    private GameObject player;
    private GameObject[] chopCounters;
    private Collider playerColl;
    private Collider counterColl;

    private float maxValue = 100;
    private bool touchingPlayer;
    private bool touchingCounter;
    
    public float theChopSliderValue;
    public bool isChopping;

    private void Start()
    {
        player = GameObject.Find("player");
        chopCounters = GameObject.FindGameObjectsWithTag("chopCounter");

        playerColl = player.GetComponent<Collider>();

        theSliderGameObject = theSlider.gameObject;
        theChopSliderValue = maxValue;
        isChopping = true;

        updateSlider();

        foreach (GameObject counter in chopCounters)
        {
            counterColl = counter.GetComponent<Collider>();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == playerColl)
        {
            Debug.Log("Raakt de player");
            touchingPlayer = true;
        }

        if (collision.collider == counterColl)
        {
            Debug.Log("Raakt de counters");
            touchingCounter = true;
        }
    }
    private void OnCollisionExit(Collision collisions)
    {
        if (collisions.collider == playerColl)
        {
            touchingPlayer = false;
        }
        if (collisions.collider == counterColl)
        {
            touchingCounter = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && touchingPlayer && touchingCounter && stateScript.canChop)
        {
            isChopping = true;
        }
        else if (!touchingCounter || !touchingPlayer)
        {
            isChopping = false;
        }

        if (isChopping == true)
        {
            decreaseSliderValue();
        }

        if (theChopSliderValue <= 0)
        {
            stateScript.canChop = false;
            stateScript.canCook = true;
            Destroy(gameObject);
        }
    }

    void updateSlider()
    {
        theSlider.value = theChopSliderValue;
    }

    void decreaseSliderValue()
    {
        if (theChopSliderValue > 0)
        {
            theChopSliderValue -= decreaseValue * Time.deltaTime;
            updateSlider();
        }
    }
}
