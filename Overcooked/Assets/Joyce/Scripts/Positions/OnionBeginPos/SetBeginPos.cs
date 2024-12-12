using UnityEngine;

public class SetBeginPos : MonoBehaviour
{
    [SerializeField] Vector3 ingredientPos;
    private void Start()
    {
        transform.position = ingredientPos;
    }
}
