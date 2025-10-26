using System.Runtime.CompilerServices;
using UnityEngine;

public class EncimeraItemComponent : CounterComponent
{
    public Vector3 attachPosition;

    public GameObject ItemOnTop { get; set; } = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + attachPosition, 0.5f);
    }
}
