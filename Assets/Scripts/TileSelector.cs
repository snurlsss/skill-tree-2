using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField] private Color openColor;
    [SerializeField] private Color obstructedColor;
    [SerializeField] private Color previousColor;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color finishedColor;
    [SerializeField] private Color hiddenColor;

    [SerializeField] GameObject tileIndicatorPrefab;
    [SerializeField] GameObject upTile;
    [SerializeField] GameObject leftTile;
    [SerializeField] GameObject rightTile;
    [SerializeField] GameObject downTile;

    public int tilesPerBranch;
    private int remainingTiles;
    private GameObject previousTile; // Should be changed into a List instead

    //public enum Direction { up, left, right, down}
    enum Selectability
    {
        open,
        obstructed,
        previous,
        selected,
        finished,
        hidden
    }
    private Selectability upSelectability;
    private Selectability leftSelectability;
    private Selectability rightSelectability;
    private Selectability downSelectability;

    private string tagUp;
    private string tagLeft;
    private string tagRight;
    private string tagDown;

    [SerializeField] private LayerMask selectionLayerMask;

    void Awake()
    {
        remainingTiles = tilesPerBranch;
        UpdateSelectability();
    }

    void UpdateSelectability()
    {
        Collider2D colliderUp = Physics2D.OverlapPoint(upTile.transform.position, selectionLayerMask);
        if (colliderUp != null)
        {
            tagUp = colliderUp.tag;

            if (tagUp == "Root")
            {
                if (upTile == previousTile)
                {
                    upSelectability = Selectability.previous;
                    upTile.GetComponent<SpriteRenderer>().color = previousColor;
                }
                else
                {
                    upSelectability = Selectability.obstructed;
                    upTile.GetComponent<SpriteRenderer>().color = obstructedColor;
                }
            }
            else if (tagUp == "Obstacle" || tagUp == "Surface")
            {
                upSelectability = Selectability.obstructed;
                upTile.GetComponent<SpriteRenderer>().color = obstructedColor;
            }
            else if (tagUp == "Collectable")
            {
                upSelectability = Selectability.open;
                upTile.GetComponent<SpriteRenderer>().color = openColor;
            }
        }
        else
        {
            tagUp = null;
            upSelectability = Selectability.open;
            upTile.GetComponent<SpriteRenderer>().color = openColor;
        }

        Collider2D colliderLeft = Physics2D.OverlapPoint(leftTile.transform.position, selectionLayerMask);
        if (colliderLeft != null)
        {
            tagLeft = colliderLeft.tag;

            if (tagLeft == "Root")
            {
                if (leftTile == previousTile)
                {
                    leftSelectability = Selectability.previous;
                    leftTile.GetComponent<SpriteRenderer>().color = previousColor;
                }
                else
                {
                    leftSelectability = Selectability.obstructed;
                    leftTile.GetComponent<SpriteRenderer>().color = obstructedColor;
                }
            }
            else if (tagLeft == "Obstacle" || tagLeft == "Surface")
            {
                leftSelectability = Selectability.obstructed;
                leftTile.GetComponent<SpriteRenderer>().color = obstructedColor;
            }
            else if (tagLeft == "Collectable")
            {
                leftSelectability = Selectability.open;
                leftTile.GetComponent<SpriteRenderer>().color = openColor;
            }
        }
        else
        {
            tagLeft = null;
            leftSelectability = Selectability.open;
            leftTile.GetComponent<SpriteRenderer>().color = openColor;
        }

        Collider2D colliderRight = Physics2D.OverlapPoint(rightTile.transform.position, selectionLayerMask);
        if (colliderRight != null)
        {
            tagRight = colliderRight.tag;

            if (tagRight == "Root")
            {
                if (rightTile == previousTile)
                {
                    rightSelectability = Selectability.previous;
                    rightTile.GetComponent<SpriteRenderer>().color = previousColor;
                }
                else
                {
                    rightSelectability = Selectability.obstructed;
                    rightTile.GetComponent<SpriteRenderer>().color = obstructedColor;
                }
            }
            else if (tagRight == "Obstacle" || tagRight == "Surface")
            {
                rightSelectability = Selectability.obstructed;
                rightTile.GetComponent<SpriteRenderer>().color = obstructedColor;
            }
            else if (tagRight == "Collectable")
            {
                rightSelectability = Selectability.open;
                rightTile.GetComponent<SpriteRenderer>().color = openColor;
            }
        }
        else
        {
            tagRight = null;
            rightSelectability = Selectability.open;
            rightTile.GetComponent<SpriteRenderer>().color = openColor;
        }

        Collider2D colliderDown = Physics2D.OverlapPoint(downTile.transform.position, selectionLayerMask);
        if (colliderDown != null)
        {
            tagDown = colliderDown.tag;

            if (tagDown == "Root")
            {
                if (downTile == previousTile)
                {
                    downSelectability = Selectability.previous;
                    downTile.GetComponent<SpriteRenderer>().color = previousColor;
                }
                else
                {
                    downSelectability = Selectability.obstructed;
                    downTile.GetComponent<SpriteRenderer>().color = obstructedColor;
                }
            }
            else if (tagDown == "Obstacle" || tagDown == "Surface")
            {
                downSelectability = Selectability.obstructed;
                downTile.GetComponent<SpriteRenderer>().color = obstructedColor;
            }
            else if (tagDown == "Collectable")
            {
                downSelectability = Selectability.open;
                downTile.GetComponent<SpriteRenderer>().color = openColor;
            }
        }
        else
        {
            tagDown = null;
            downSelectability = Selectability.open;
            downTile.GetComponent<SpriteRenderer>().color = openColor;
        }

        if (remainingTiles <= 0)
        {
            GetComponent<SpriteRenderer>().color = finishedColor;

            if (upSelectability != Selectability.previous)
            {
                upSelectability = Selectability.hidden;
                upTile.GetComponent<SpriteRenderer>().color = hiddenColor;
            }
            if (leftSelectability != Selectability.previous)
            {
                leftSelectability = Selectability.hidden;
                leftTile.GetComponent<SpriteRenderer>().color = hiddenColor;
            }
            if (rightSelectability != Selectability.previous)
            {
                rightSelectability = Selectability.hidden;
                rightTile.GetComponent<SpriteRenderer>().color = hiddenColor;
            }
            if (downSelectability != Selectability.previous)
            {
                downSelectability = Selectability.hidden;
                downTile.GetComponent<SpriteRenderer>().color = hiddenColor;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = hiddenColor;
        }
    }

    public void SelectTile(int direction) // 0 = Up, 1 = Left, 2 = Right, 3 = Down
    {
        GameObject selectedTile;
        Selectability selectability;

        if (direction == 0) // Up
        {
            selectedTile = upTile;
            selectability = upSelectability;
            print("Trigger select up.");
        }
        else if (direction == 1) // Left
        {
            selectedTile = leftTile;
            selectability = leftSelectability;
            print("Trigger select left.");
        }
        else if (direction == 2) // Right
        {
            selectedTile = rightTile;
            selectability = rightSelectability;
            print("Trigger select right.");
        }
        else if (direction == 3) // Down
        {
            selectedTile = downTile;
            selectability = rightSelectability;
            print("Trigger select down.");
        }
        else
        {
            selectedTile = gameObject;
            print("ERROR Invalid direction was given to TileSelector.");
            return;
        }

        if (remainingTiles <= 0 && selectability != Selectability.previous)
        {
            return;
        }

        if (selectability == Selectability.open)
        {
            print("Need placement of tiles");
            
            PlaceRoot();

            transform.position = selectedTile.transform.position;
            UpdateSelectability();
        }
        else if (selectability == Selectability.previous)
        {
            print("Need to add the ability to revert root tile placing.");
            RevertPreviousRoot();
        }
    }

    void PlaceRoot()
    {
        // We still need to make it place root in current position.


        remainingTiles--;
    }

    void RevertPreviousRoot()
    {
        // We still need to add the ability to revert root tile placing.


        remainingTiles++;
    }
}
