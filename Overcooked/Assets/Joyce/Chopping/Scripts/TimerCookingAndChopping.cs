using System.Linq.Expressions;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;


public class TimerCookingAndChopping : MonoBehaviour
{
    [SerializeField] Slider cookingSlider;
    [SerializeField] float maxSliderValue;

    private GameObject choppingPlace;
    private GameObject player;
    private GameObject bodyOnion;
    private GameObject bodyChopped;
    private GameObject theSlider;
    private float decreaseCount = 20f;
    private float sliderValue;
    private bool isCooking = false;
    private bool canChop = true;
    public bool canCook;

    void Start()
    {
        choppingPlace = GameObject.Find("chopPlace");
        player = GameObject.Find("player");
        bodyOnion = GameObject.Find("onionBody");
        bodyChopped = GameObject.Find("choppedOnion");
        theSlider = cookingSlider.gameObject;
        theSlider.SetActive(false);
        bodyChopped.SetActive(false);   
        bodyOnion.SetActive(true);

        sliderValue = maxSliderValue;
        updateSlider();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, choppingPlace.transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && canChop)
            {
                isCooking = !isCooking;
            }

            if (isCooking)
            {
                theSlider.SetActive(true);
                decreaseCountSlider();

                if (sliderValue <= 0)
                {
                    bodyOnion.SetActive(false);
                    theSlider.SetActive(false);
                    bodyChopped.SetActive(true);
                    canCook = true;
                }
            }
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

