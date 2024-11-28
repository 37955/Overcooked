using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;


public class TimerCookingAndChopping : MonoBehaviour
{
    [SerializeField] Slider cookingOrChoppingSlider;
    [SerializeField] GameObject BodyOnion;
    [SerializeField] GameObject theSlider;
    [SerializeField] float ValueSlider;

    private GameObject player;
    private GameObject theCookingPlace;
    private bool isCooking = false;
    private int decreaseRate = 10;
    void Start()
    {
        player = GameObject.Find("Player");
        theCookingPlace = GameObject.Find("CookingPlace");
        theSlider.gameObject.SetActive(false);

        updateSlider();
    }
    void Update()
    {
        if (Vector3.Distance(player.transform.position, theCookingPlace.transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                isCooking = !isCooking;
                Debug.Log("Toggled The IsCooking Bool");
                theSlider.gameObject.SetActive(true);
            }
        }
        else
        {
            isCooking = false;
        }

        if (isCooking)
        {
            minusValue();
        }
        if (ValueSlider <= 0)
        {
            Destroy(BodyOnion);
            theSlider.gameObject.SetActive(false);
        }
    }

    void updateSlider()
    {
        cookingOrChoppingSlider.value = ValueSlider;
    }

    void minusValue()
    {
        ValueSlider -= decreaseRate * Time.deltaTime;
        updateSlider();
    }
}
