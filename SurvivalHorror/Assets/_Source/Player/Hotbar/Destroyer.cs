using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Vector3 RESET_POSITION = new Vector3(0, 1000, 0);

    [SerializeField] private LayerMask treeLayerMask;
    [SerializeField] private LayerMask stoneLayerMask;
    [SerializeField] private LayerMask enemyLayerMask;

    private int _treeLayer;
    private int _stoneLayer;
    private int _enemyLayer;

    private void Awake()
    {
        _treeLayer = (int)Mathf.Log(treeLayerMask.value, 2);
        _stoneLayer = (int)Mathf.Log(stoneLayerMask.value, 2);
        _enemyLayer = (int)Mathf.Log(enemyLayerMask.value, 2);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == _stoneLayer || other.gameObject.layer == _enemyLayer)
        {
            other.gameObject.SetActive(false);
            transform.position = RESET_POSITION;
        }

        if (other.gameObject.layer == _treeLayer)
        {
            other.transform.parent.gameObject.SetActive(false);
            transform.position = RESET_POSITION;
        }
    }

}
