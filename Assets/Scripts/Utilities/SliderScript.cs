using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private CharacterController _characterController;

    private void Start()
    {
        _slider.onValueChanged.AddListener((v) =>
        {
            _characterController.SetFlyingForce(_characterController.GetFlyingForce() * v);
        });
    }
}
