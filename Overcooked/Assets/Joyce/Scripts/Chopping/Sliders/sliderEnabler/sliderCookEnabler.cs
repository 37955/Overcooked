using UnityEngine;
using UnityEngine.Rendering;

public class sliderCookEnabler : MonoBehaviour
{
    [SerializeField] stateOfIngredient stateScript;
    [SerializeField] GameObject theCookSliderGameObject;

    private GameObject player;
    private GameObject[] cookCounters;
    private Collider playerCollider;
    private Collider counterCollider;
    private Collider thisObjectCollider;
    private bool isTouchingCounter;
    private bool isTouchingPlayer;

    void Start()
    {
        player = GameObject.Find("player");
        cookCounters = GameObject.FindGameObjectsWithTag("cookCounter");

        playerCollider = player.GetComponent<Collider>();
        thisObjectCollider = gameObject.GetComponent<Collider>();

        theCookSliderGameObject.SetActive(false);
        foreach (GameObject counters in cookCounters)
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
            if (stateScript.canCook && Input.GetKeyDown(KeyCode.LeftControl))
            {
                theCookSliderGameObject.SetActive(true);
            }
        }
    }
}
