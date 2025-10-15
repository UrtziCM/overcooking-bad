using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    int minPress;

    void Start()
    {
        minPress = 100;
    }

    private void FixedUpdate()
    {
        --minPress;
    }
}
