using UnityEngine;
using UnityEngine.UI;
//Commenting convention: Fields and variables
public class RadialProgress : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _speed = 70f;
    [SerializeField] private float _reverseSpeed = 50f;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Canvas _timerCanvas;
    [SerializeField] private Canvas _orderCanvas;

    private float _currentValue;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (_canvas.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (_currentValue < 100)
                {
                    _currentValue += _speed * Time.unscaledDeltaTime;
                }
            }
            else
            {
                if (_currentValue > 0)
                {
                    _currentValue -= _reverseSpeed * Time.unscaledDeltaTime;
                }
            }
            _image.fillAmount = _currentValue / 100;

            if (_currentValue >= 100)
            {
                HideCanvas();
            }

            if (_currentValue < 100)
            {
                HideTimerAndOrder();
            }

            if (_currentValue >= 100)
            {
                ShowTimerAndOrder();
            }
        }
    }

    private void ShowTimerAndOrder()
    {
        _orderCanvas.gameObject.SetActive(true);
        _timerCanvas.gameObject.SetActive(true);
    }

    private void HideTimerAndOrder()
    {
        _orderCanvas.gameObject.SetActive(false);
        _timerCanvas.gameObject.SetActive(false);
    }

    private void HideCanvas()
    {
        _canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
