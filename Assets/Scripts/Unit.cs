using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected Animator animator; //A protected variable is one that can be viewed by an objedct and its children
    //Some things all units will have: health, how much damage they deal, their current team, a viewing angles, a rigidbody, etc.

    [SerializeField] int fullHealth = 100;
    [SerializeField] int team;
    [SerializeField] int health;
    [SerializeField] int damage = 10;

    protected Rigidbody rb;

    private const float RAYCAST_LENGTH = 0.3f;


    // this is going to be the base class for both our PlayerController and our eventual AIController. This is going to be shared properties between our PlayerController and our AI.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Team
    {
        get
        {
            return team;
        }
    }

    protected bool IsGrounded() //we want to figure out if our character is on the ground or not
    {
        Vector3 origin = transform.position;//this is where our character begins
        origin.y += RAYCAST_LENGTH * 0.5f;
        LayerMask mask = LayerMask.GetMask("Terrain");
        return Physics.Raycast(origin, Vector3.down, RAYCAST_LENGTH, mask);
    }


}
