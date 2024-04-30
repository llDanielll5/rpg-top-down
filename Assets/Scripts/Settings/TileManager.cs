using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap interactableMap;

    [SerializeField]
    private Tile hiddenInteractableTile;

    [SerializeField]
    private Tile interactedTile;

    [SerializeField]
    private Tile plantedTile;

    void Start()
    {
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null && tile.name == "Interactable_Visible")
                interactableMap.SetTile(position, hiddenInteractableTile);
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null)
        {
            if (tile.name == "Interactable")
                return true;
        }

        return false;
    }

    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);
    }

    public void PlantTile(Vector3Int position, Tile newTile)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null)
        {
            if (tile.name == "Role")
                interactableMap.SetTile(position, newTile);
        }
        return;
    }
}
