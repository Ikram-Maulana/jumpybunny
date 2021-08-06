using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Sample block from where to create new blocks
    public List<LevelBlock> legoBlocks= new List<LevelBlock>();
    // Blocks added to the game
    List<LevelBlock> currentBlocks = new List<LevelBlock>();

    public Transform initialPoint;

    private static LevelGenerator _sharedInstance;
    public static LevelGenerator sharedInstance 
    {
        get
        {
            return _sharedInstance;
        }
    }

    private void Awake()
    {
        _sharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewBlock()
    {

    }
}
