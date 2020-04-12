﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{ 
    Defender defender;
 

    private void OnMouseDown()
    {       
        SpawnDefender(SnapToGrid(GetSquaredClicked()));        
    }

    public void SetSelectedDefender (Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private Vector2 SnapToGrid(Vector2 position)
    {
        return new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
    }

    private Vector2 GetSquaredClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos; 
    }

    private void SpawnDefender(Vector2 position)
    {
        Defender newDefender = Instantiate(defender, position, Quaternion.identity) as Defender;
    }
}
