using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    private bool sign = true;
    public bool canShoot = false;
    public float strenghtForce = 0;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    void Start()
    {
        _slider.value = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if(sign)
            {
                AddToSlider(+1f);
            }
            else
            {
                AddToSlider(-1f);
            }
            if(_slider.value == 0)
            {
                sign = true;
            }
            if(_slider.value == 100)
            {
                sign = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Z))
        {
            //shoot
            canShoot = true;
            strenghtForce = _slider.value;
        }

    }

    void AddToSlider(float val)
    {
        _slider.value += val;
    }
}
