using UnityEngine;

public class SetBeginPos : MonoBehaviour
{
    [SerializeField] Vector3 startingpos;
    private void Start()
    {
        transform.position = startingpos;
    }

}
    