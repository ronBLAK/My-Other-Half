using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject leftWall, rightWall, frontWall, backWall, unvisitedBlock; // holds all the walls and unvisited blocks of each maze cell created

    public bool IsVisited {get; private set;}

    // method to track if a cell has been visited
    public void Visit()
    {
        IsVisited = true;

        unvisitedBlock.SetActive(false);
    }

    // clears the left wall
    public void ClearLeftWall()
    {
        leftWall.SetActive(false);
    }
    
    // clears the right wall
    public void ClearRightWall()
    {
        rightWall.SetActive(false);
    }

    // clears the front wall
    public void ClearFrontWall()
    {
        frontWall.SetActive(false);
    }

    // clears the back wall
    public void ClearBackWall()
    {
        backWall.SetActive(false);
    }
}
