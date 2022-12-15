using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        _slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            _slider.value -= 100;
        }
        else if (Input.GetKeyDown("x")) 
        {
            _slider.value += 100; 
        }
    }
}
