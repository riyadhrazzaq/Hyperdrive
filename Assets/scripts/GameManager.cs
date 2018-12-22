using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// FOR " DAY 4 " WHERE WE WILL SHOW HOW THE INFINITE GENERATION IS DONE
// ALSO CHECK OUT THE NEXT BLOCK SCRIPT WHICH SHOULD BE ATTACHED ON THE TRIGGER OF EACH POOLED BLOCKS

/// <summary>
/// Add this Class to the Player, and Read the comments to setup this class perfectly
/// Add the Next Block class to the Trigger through which the Next Blocks will be positioned
/// </summary>
public class GameManager : MonoBehaviour {
    //SingleTon To Get Reference Always
    public static GameManager mGameManager;

    //Used to Select the axis of the block flow from the editor
    [SerializeField] private enum BlockFlow { Xaxis = 0, Yaxis = 1, Zaxis = 3 }; //The Flow of the Blocks
    [SerializeField] private BlockFlow mBlockFlow;
    private Vector3 BlockFlowPosition; //holds the position according to the BlockOffset, determined at the Start of the game

    //Holds the Reference of the Blocks
    [SerializeField] private GameObject[] Blocks; //Holds all the Block Prefabs //Add all the block References
    [SerializeField] private GameObject CurrentBlock; //Holds the Current Block on Which the player is running; //Don't have to add anything here
    [SerializeField] private float BlockOffset; //The Position after which the next Block will be placed //Add the Difference after which next block will be placed

    //GameComponents
    public UnityEngine.UI.Text ScoreBoard; //ScoreBoard
    public int Score; //the variable that holds the scores

    void Awake()
    {
        mGameManager = this; //This is a Singleton which will help to get the reference //But there should be only one Script of GameManager throught out the whole scene
    } //End Awake()

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //Screen will never Sleep
        Score = 0; //Default Score

        CurrentBlock = Blocks[0]; //if your player is on the Block[0] GameObject then it's alright //Otherwise Change it as per required 
        SetBlockOffsetAxis(); //Sets the axis through which the Blocks will be positioned
    } //End Start()
    
    public void Instantiate()
    {
        //BLOCK POSITIONED
        int rand = ((Random.Range(51, 152) * 3	) % Blocks.Length); //Chooses a Random Number for a Random Block Selection

        if (Blocks[rand] == CurrentBlock) //If the Random block is current block on which the player is running, Function is called again
        {
            Instantiate(); //Recursion
            return;
        } //End if
        
        Blocks[rand].transform.position = CurrentBlock.transform.position + BlockFlowPosition; //Selects the Random Block from the Array and Repositions it after the old block
        CurrentBlock = Blocks[rand]; //The Random Block is then Choosen to be the Current Block
    } //End Instantiate Function

    private void SetBlockOffsetAxis() //Depending on the mBlockFlow the Axis is set to the BlockFlowPosition permanently till the game ends
    {
        if (mBlockFlow == BlockFlow.Xaxis)
            BlockFlowPosition = new Vector3(BlockOffset, 0, 0); //Block will be set in X axis
        else if (mBlockFlow == BlockFlow.Yaxis)
            BlockFlowPosition = new Vector3(0, BlockOffset, 0); //Block will be set in Y axis
        else if (mBlockFlow == BlockFlow.Zaxis)
            BlockFlowPosition = new Vector3(0, 0, BlockOffset); //Block will be set in Z axis
    } //End SetBlockOffsetAxis Funtion
}
