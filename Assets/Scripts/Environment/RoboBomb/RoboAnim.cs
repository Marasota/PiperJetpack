using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAnim : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        switch (transform.parent.name)
        {
            default:
            case "Default":
            {
                    _animator.SetTrigger("Idle");
                    break;
            }
     
            
        }
    }


}
