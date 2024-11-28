using NUnit.Framework.Internal;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;


public class TimerCookingAndChopping : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] Slider cookingOrChoppingSlider;
    [SerializeField] GameObject BodyOnion;
    [SerializeField] GameObject theSlider;
    [SerializeField] float ValueSlider;
=======
    [SerializeField] Slider cookingSlider;
    [SerializeField] float maxSliderValue;
    [SerializeField] float decreaseCount;
>>>>>>> Stashed changes

    private GameObject theSlider;
    private GameObject player;
    private GameObject choppingStation;
    private GameObject bodyOnion;
    private GameObject choppedOnion;
    private float sliderValue;
    private bool isCooking;
    private bool canChop = true;

    public bool canCook = false;

    void Start()
    {
        player = GameObject.Find("Player");
        choppingStation = GameObject.Find("ChopPlace");
        bodyOnion = GameObject.Find("OnionBody");
        choppedOnion = GameObject.Find("ChoppedBody");
        sliderValue = maxSliderValue;
        theSlider = cookingSlider.gameObject;
        choppedOnion.SetActive(false);
        theSlider.SetActive(false);

        updateSlider();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, choppingStation.transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && canChop)
            {
                isCooking = !isCooking;
            }
            if (isCooking)
            {
                decreaseCountSlider();
                theSlider.SetActive(true);
            }
        }
        else
        {
            isCooking = false;
        }



        if (sliderValue <= 0)
        {
<<<<<<< Updated upstream
            minusValue();
        }
        if (ValueSlider <= 0)
        {
            Destroy(BodyOnion);
            theSlider.gameObject.SetActive(false);
=======
            bodyOnion.SetActive(false);
            theSlider.SetActive(false);
            choppedOnion.SetActive(true);
            canChop = false;
            canCook = true;
>>>>>>> Stashed changes
        }
    }
    void updateSlider()
    {
        cookingSlider.value = sliderValue;
    }
    void decreaseCountSlider()
    {
        sliderValue -= decreaseCount * Time.deltaTime;
        updateSlider();
    }


}
