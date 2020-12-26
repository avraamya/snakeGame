using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    private Vector2Int gridMoveDirection;
    private Vector2Int lastMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimeMax;
    private LevelGrid levelGrid;

    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimeMax = .65f;
        gridMoveTimer = gridMoveTimeMax;
        gridMoveDirection = new Vector2Int(1, 0);
        lastMoveDirection = new Vector2Int(1, 0);
    }

    private void Update()
    {
        HandleInput();
        HandlerGridMovement();

    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (lastMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (lastMoveDirection.y != 1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lastMoveDirection.x != 1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lastMoveDirection.x != -1)
            {
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 0;
            }
        }


    }
    private void HandlerGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimeMax)
        {
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimeMax;
            //gridPosition += gridMoveDirection;

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90);
            lastMoveDirection = new Vector2Int(gridMoveDirection.x, gridMoveDirection.y);

            levelGrid.SnakeMoved(gridPosition);
        }
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }
}