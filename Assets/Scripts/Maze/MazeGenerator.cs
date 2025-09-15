using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell mazeCellPrefab; // reference tp the maze cell constructer

    [SerializeField]
    private int mazeWidth, mazeDepth; // holds the width and depth of the maze
    
    private int seed; // holds the random seed for the maze generation

    private MazeCell[,] mazeGrid; // holds the maze grid

    [SerializeField] private GameObject mazeCellHolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // loads the saved seed if a seed exists
        // if not, loads a maze with a new seed
        if (PlayerPrefs.HasKey("Seed"))
        {
            seed = PlayerPrefs.GetInt("Seed");
            Random.InitState(seed);
        }
        else
        {
            int seed = Random.Range(1, 1000000);
            Random.InitState(seed);
            // save seed value with PlayerPrefs
            PlayerPrefs.SetInt("Seed", seed);
            PlayerPrefs.Save();
        }

        mazeGrid = new MazeCell[mazeWidth, mazeDepth]; // creates a new maze grid

        // loops the width and depth of maze grid and places instances of the maze cell prefab
        for (int x = 0; x < mazeWidth; x++)
        {
            for (int z = 0; z < mazeDepth; z++)
            {
                mazeGrid[x, z] = Instantiate(mazeCellPrefab, new Vector3(x * 3.54f, 0, z * 3.54f), Quaternion.identity);
                mazeGrid[x, z].transform.SetParent(mazeCellHolder.transform);
                mazeGrid[x, z].Initialize(x, z); // store grid coords
            }
        }

        GenerateMaze(null, mazeGrid[0, 0]); // generates the maze according to the maze width and depth
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    // method to generate maze
    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        MazeCell nextCell;

        do {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }

        } while(nextCell != null);
    }

    // returns all unvisited cells adjacant to the current cell
    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    // updates the visited state of the each of the unvisited celle
    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.GridX;
        int z = (int)currentCell.GridZ;

        if(x + 1 < mazeWidth)
        {
            var cellToRight = mazeGrid[x + 1, z];
            
            if(cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if(x - 1 >= 0)
        {
            var cellToLeft = mazeGrid[x - 1, z];

            if(cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if(z + 1 < mazeDepth)
        {
            var cellToFront = mazeGrid[x, z + 1];

            if(cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        if(z - 1 >= 0)
        {
            var cellToBack = mazeGrid[x, z - 1];

            if(cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

    // executes the clearing of the walls
    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if(previousCell == null)
        {
            return;
        }

        if(previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            
            return;
        }

        if(previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();

            return;
        }

        if(previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();

            return;
        }

        if(previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();

            return;
        }
    }
}
