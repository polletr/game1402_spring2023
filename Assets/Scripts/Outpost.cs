using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outpost : MonoBehaviour
{

    [SerializeField] private float flagTop;
    [SerializeField] private float flagBottom;

    private SkinnedMeshRenderer flag; //this is the flag we are going to use

    internal int team = -1; //internal is public to the project and private to the outside world

    //When a unit enters and stays within the collider area, we ant them to star collecting points

    private float timer; //variable to keep track of time of the player within the outpost.

    [SerializeField] private float scoreInterval = 5.0f; //interval before player gets points

    [SerializeField] private float valueIncrease = 0.005f; //how long for them to increase a value

    internal float currentValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        flag = GetComponentInChildren<SkinnedMeshRenderer>(); //this is the flag we are going to move and update
    }

    // Update is called once per frame
    void Update()
    {
        if (team != -1)
        {
            flag.transform.parent.localPosition = new Vector3 (0, Mathf.Lerp(flagBottom, flagTop, currentValue), 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //on trigger stay means that someone has triggered the collider and is still there

        Unit unit = other.GetComponent<Unit>(); //Check if what collided is actually an unit
        if (unit != null) // we only care for units
        {
            if (unit.Team == team)
            {
                //Same team enters the spaces which increases the value.
                currentValue = currentValue + valueIncrease;
                if (currentValue >= 1.0f)
                {
                    currentValue = 1;
                }
            }
            else
            {
                // New team enters the space. they immmediately decrease the currentValue
                currentValue -= valueIncrease;
                if (currentValue <= 0.0f)
                {
                    team = unit.Team;
                    currentValue = 0;
                }
            }
        }
    }
}
