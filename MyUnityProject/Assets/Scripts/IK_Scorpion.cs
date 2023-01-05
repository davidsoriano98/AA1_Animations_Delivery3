using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OctopusController;

public class IK_Scorpion : MonoBehaviour
{
    MyScorpionController _myController= new MyScorpionController();

    public IK_tentacles _myOctopus;

    [Header("Body")]
    float animTime;
    public float animDuration = 5;
    bool animPlaying = false;
    public Transform Body;
    public Transform StartPos;
    public Transform EndPos;

    [Header("Tail")]
    public Transform tailTarget;
    public Transform tail;

    [Header("Legs")]
    public Transform[] legs;
    public Transform[] legTargets;
    public Transform[] futureLegBases;

    public bool isShooting = false;
    public GameObject prefab;
    public MovingBall _ball;

    GameObject pointTarget;
    void Start()
    {
        _myController.InitLegs(legs,futureLegBases,legTargets);
        _myController.InitTail(tail);
        pointTarget = Instantiate(prefab, tailTarget.position, Quaternion.identity);
    }

    void Update()
    {
        if(animPlaying)
            animTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A))
        {
            Respawn();
        }

        if (animTime < animDuration)
        {
            Body.position = Vector3.Lerp(StartPos.position, EndPos.position, animTime / animDuration);
        }
        else if (animTime >= animDuration && animPlaying)
        {
            Body.position = EndPos.position;
            animPlaying = false;
        }

        if(isShooting)
        {
            _myController.UpdateIKTail();
        }

        _myController.UpdateIKLegs();
    }
    
    public void NotifyTailTarget()
    {
        _myController.NotifyTailTarget(pointTarget.transform);
        //_myController.NotifyTailTarget();
    }

    //Trigger Function to start the walk animation
    public void NotifyStartWalk()
    {
        _myController.NotifyStartWalk();
    }

    public void ShootTail()
    {
        NotifyTailTarget();
        isShooting = true;
    }

    public void SetPointTarget()
    {
        pointTarget.transform.position += (Random.insideUnitSphere * 0.35f);
    }

    public void ResetPointTarget()
    {
        pointTarget.transform.position = tailTarget.position;
    }

    public void Respawn()
    {
        isShooting = false;
        _myController.NotifyTailTarget(null);
        NotifyStartWalk();
        animTime = 0;
        animPlaying = true;
    }
}
