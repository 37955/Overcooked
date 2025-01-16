using UnityEngine;

public class HoldIngredientCount : MonoBehaviour
{
    [SerializeField] GameObject noImages;
    [SerializeField] GameObject allImages;
    [SerializeField] GameObject[] gotImages = new GameObject[3];
    public int ingredientCount { get; set; }

    private void Update()
    {
        for (int i = 0; i < gotImages.Length; i++)
        {
            if (i < ingredientCount)
            {
                gotImages[i].SetActive(true);
            }
            else
            {
                gotImages[i].SetActive(false );
            }
        }

        if (ingredientCount > 0)
        {
            noImages.SetActive(false);
            allImages.SetActive(true);
        }
        else
        {
            noImages.SetActive(true);
            allImages.SetActive(false);
        }
    }
}

