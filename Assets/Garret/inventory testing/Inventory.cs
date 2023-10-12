using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private Item[,] grid;

    public Inventory(int rows, int columns)
    {
        grid = new Item[rows, columns];
    }

    public bool addItem(Item item, int row, int column) 
    {
        if (grid[row, column] == null)
        {
            grid[row, column] = item;
            return true;
        }
        else 
        {
            return false;
        }
    }

    //below may not be needed
    public void RemoveItem(int row, int column) {
        if (grid[row, column] != null) {
            grid[row, column] = null;
        }
    }

    public Item getItem(int row, int column) {
        return grid[row, column];
    }
}
