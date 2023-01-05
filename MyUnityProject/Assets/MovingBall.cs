using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MovingBall : MonoBehaviour
{
    [SerializeField]
    MovingTarget _target;
    IK_tentacles _myOctopus;
    IK_Scorpion _myScorpion;

    public ForceSlider _strengthSlider;
    public EffectSlider _effectSlider;

    [Range(-1.0f, 1.0f)]
    [SerializeField]
    private float _movementSpeed = 5f;

    private Rigidbody _rb;

    public float radius;

    Vector3 _dir;

    private void Awake()
    {
        radius = GetComponent<SphereCollider>().radius;
        _rb = GetComponent<Rigidbody>();
        _myOctopus = FindObjectOfType<IK_tentacles>();
        _target = GameObject.Find("BlueTarget").GetComponent<MovingTarget>();
        _myScorpion = FindObjectOfType<IK_Scorpion>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(GetDirection()), Color.white);
        transform.rotation = Quaternion.identity;
        if (Input.GetKeyDown(KeyCode.L))
        {
            Respawn();
        }

        if(_strengthSlider.canShoot && _effectSlider.GetEffectValue() < 50f)
        {
            _myScorpion.ShootTail();
        }
        //transform.position = transform.position + new Vector3(-transform.position.x * _movementSpeed * Time.deltaTime, transform.position.y * _movementSpeed * Time.deltaTime, 0);

    }
    void ShootAction()
    {
        _rb.AddForce(GetDirection(), ForceMode.Impulse);
        _myOctopus.NotifyShoot();
        _strengthSlider.canShoot = false;
    }

    //DIRECTION TO SHOOT
    Vector3 GetDirection()
    {
        return _target.GetPosition() - transform.position;
    }

    private void CalculateMagnus()
    {

        //var direction = Vector3.Cross(rb.angularVelocity, rb.velocity);
        //var magnitude = 4 / 3f * Mathf.PI * airDensity * Mathf.Pow(radius, 3);
        //rb.AddForce(magnitude * direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_strengthSlider.canShoot)
        {
            ShootAction();
        }
    }

    public void Respawn()
    {
        _rb.angularVelocity = Vector3.zero;
        _rb.velocity = Vector3.zero;
        transform.position = new Vector3(-125, 22, -39);
        _myScorpion.Respawn();
        _myScorpion.ResetPointTarget();
    }
}
