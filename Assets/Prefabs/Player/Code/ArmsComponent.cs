using UnityEngine;

public class ArmsComponent : MonoBehaviour
{
    GameObject currentInteractor = null;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (!currentInteractor)
        {
            SetCurrentInteractor(other.gameObject);
        }
        else
        {
            SetCurrentInteractor(ClosestInteractor(currentInteractor, other.gameObject));
        }
    }

    private void SetCurrentInteractor(GameObject interactor) 
    {
        if (currentInteractor)
            currentInteractor.GetComponent<MeshRenderer>().enabled = true;
        currentInteractor = interactor;
        currentInteractor.GetComponent<MeshRenderer>().enabled = false;
    }

    private GameObject ClosestInteractor(GameObject a, GameObject b) 
    {
        // (a-b).magnitude == Vector3.Distance(a,b) so (a-b).sqrMagnitude == Vector3.Distance(a,b) ^ 2 sin sqrt -> bien
        float distToA = (a.transform.position - transform.position).sqrMagnitude;
        float distToB = (b.transform.position - transform.position).sqrMagnitude;
        return (distToA > distToB)? b : a;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }

}
