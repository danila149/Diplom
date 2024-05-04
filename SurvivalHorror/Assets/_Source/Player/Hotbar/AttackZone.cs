using Photon.Pun;
using System.Collections;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] private GameObject hit;

    private int _objectLayer;
    private int _damage;
    private Hotbar _hotbar;
    private GameObject _destroyer;

    private void Awake()
    {
        _destroyer = GameObject.FindGameObjectWithTag("Destroyer");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _objectLayer)
        {
            StartCoroutine(ShowHit());
            
            if (other.GetComponent<ADamagable>().dropType != ResourceType.None)
            {
                Items.Resource collectedItem = PhotonNetwork.Instantiate(other.GetComponent<ADamagable>().dropType.ToString(), transform.position, Quaternion.identity).GetComponent<Items.Resource>();
                collectedItem.Amount = _damage;
                _hotbar.GetResource(collectedItem);
            }
            if (other.GetComponent<ADamagable>().GetDamage(_damage))
            {
                GetComponent<PhotonView>().RPC("Disable", RpcTarget.AllBuffered, other.transform.position);
            }
        }
    }

    private void Update()
    {
        if(!gameObject.activeInHierarchy)
            hit.gameObject.SetActive(false);
    }

    [PunRPC]
    private void Disable(Vector3 pos)
    {
        _destroyer.SetActive(true);
        _destroyer.transform.position = pos;
    }

    private IEnumerator ShowHit()
    {
        hit.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hit.SetActive(false);
    }

    public void SetLayerMask(LayerMask layerMask)=>
        _objectLayer = (int)Mathf.Log(layerMask.value, 2);

    public void SetDamage(int damage) =>
        _damage = damage;

    public void SetHotbar(Hotbar hotbar) =>
        _hotbar = hotbar;
}
