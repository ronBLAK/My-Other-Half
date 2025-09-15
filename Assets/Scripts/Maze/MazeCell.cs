using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject leftWall, rightWall, frontWall, backWall, unvisitedBlock;

    public bool IsVisited { get; private set; }

    // Add grid coordinates
    public int GridX { get; private set; }
    public int GridZ { get; private set; }

    // Initialize cell with coordinates
    public void Initialize(int x, int z)
    {
        GridX = x;
        GridZ = z;
    }

    public void Visit()
    {
        IsVisited = true;
        unvisitedBlock.SetActive(false);
    }

    public void ClearLeftWall() { leftWall.SetActive(false); }
    public void ClearRightWall() { rightWall.SetActive(false); }
    public void ClearFrontWall() { frontWall.SetActive(false); }
    public void ClearBackWall() { backWall.SetActive(false); }
}
