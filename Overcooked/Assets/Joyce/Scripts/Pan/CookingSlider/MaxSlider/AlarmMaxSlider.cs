using UnityEngine;
using UnityEngine.UI;

public class AlarmMaxSlider : MonoBehaviour
{
    [SerializeField] GameObject alarmImage;
    [SerializeField] Slider cookSlider;

    private float theTime;
    private float resetTime = 0.75f;
    private float alarmCount;
    private bool alarmImageEnabled;

    private void Start()
    {
        alarmCount = 0;
        alarmImage.SetActive(false);
    }
    private void Update()
    {


        if (cookSlider.value == 100 && alarmCount <= 6)
        {
            AlarmOn();
        }
        else if (alarmCount == 6)
        {
            alarmImage.SetActive(false);
            alarmImageEnabled = false;
        }

    }

    void AlarmOn()
    {
        theTime += Time.deltaTime;
        if (theTime >= resetTime && alarmCount < 6)
        {
            alarmImageEnabled = !alarmImageEnabled;
            if (alarmImageEnabled)
            {
                alarmCount++;
            }
            theTime = 0f;
        }

        alarmImage.SetActive(alarmImageEnabled);

    }
}