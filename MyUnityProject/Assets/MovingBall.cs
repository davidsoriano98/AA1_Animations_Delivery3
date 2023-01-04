using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    [SerializeField]
    MovingTarget _target;
    IK_tentacles _myOctopus;
    public SliderController _strengthSlider;

    //movement speed in units per second
    [Range(-1.0f, 1.0f)]
    [SerializeField]
    private float _movementSpeed = 5f;

    Vector3 _dir;

    private void Awake()
    {
        _target = GameObject.Find("BlueTarget").GetComponent<MovingTarget>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;

        transform.position = transform.position + new Vector3(-transform.position.x * _movementSpeed * Time.deltaTime, transform.position.y * _movementSpeed * Time.deltaTime, 0);

    }
    void Shoot()
    {
        // Apply force to ball for shoot
    }

    //DIRECTION TO SHOOT
    Vector3 GetPos()
    {
        return new Vector3(_target.GetPosX(), _target.GetPosY(), transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_strengthSlider.canShoot)
        {
            _myOctopus.NotifyShoot();
            _strengthSlider.canShoot = false;
        }
    }
}
