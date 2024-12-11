using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float speed = 70;
    [SerializeField] private float reverseSpeed = 50;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas timerCanvas;
    [SerializeField] private Canvas orderCanvas;

    float currentValue;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (canvas.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (currentValue < 100)
                {
                    currentValue += speed * Time.unscaledDeltaTime;
                }
            }
            else
            {
                if (currentValue > 0)
                {
                    currentValue -= reverseSpeed * Time.unscaledDeltaTime;
                }
            }
            image.fillAmount = currentValue / 100;

            if (currentValue >= 100)
            {
                HideCanvas();
            }

            if (currentValue < 100)
            {
                HideTimerandOrder();
                
            }

            if(currentValue >= 100)
            {
                ShowTimerandOrder();
            }
        }
    }

    private void ShowTimerandOrder()
    {
        orderCanvas.gameObject.SetActive(true);
        timerCanvas.gameObject.SetActive(true);
    }
    private void HideTimerandOrder()
    {
        orderCanvas.gameObject.SetActive(false);
        timerCanvas.gameObject.SetActive(false);
    }
    private void HideCanvas()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
