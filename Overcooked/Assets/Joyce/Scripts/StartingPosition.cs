using UnityEngine;

public class StartingPosition : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void Start()
    {
        transform.position = player.transform.position;
    }
}
