using UnityEngine;

public class CakeScript : MonoBehaviour
{
    // Start is called before the first frame update
    private CakeMovement _cakeMovement;

    private void Start()
    {
        _cakeMovement = transform.parent.gameObject.GetComponent<CakeMovement>();
    }


    public void Decrease()
    {
        _cakeMovement.Decrease();
    }

    private void OnTriggerStay2D(Collider2D collision)
    { 
       gameObject.SetActive(false);
       Decrease();
    }
}
