using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance; //Static values are class variables,belongs to the class not an object

    [SerializeField] private Color[] teams;
    internal Outpost[] outposts;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                _instance.OnCreateIstance();
            }
            return _instance;
        }

        set 
        { 
            //The game manager handles itself so no need to set anything
        }

    }

    private void OnCreateIstance()
    {
        //this is where we do some initialization for the game manager
        outposts = GetComponentsInChildren<Outpost>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
