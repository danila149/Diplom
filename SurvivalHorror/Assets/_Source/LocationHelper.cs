using UnityEngine;

public class LocationHelper : MonoBehaviour
{
    [SerializeField] private LayerMask mushroomlayterMask;

    private int _muhsroomLayer;

    void Start()
    {
        _muhsroomLayer = (int)Mathf.Log(mushroomlayterMask.value, 2);
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.layer == _muhsroomLayer)
                transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
