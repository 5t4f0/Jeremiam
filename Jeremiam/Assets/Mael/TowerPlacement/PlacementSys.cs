using UnityEngine;
using System;
using System.Collections.Generic;


public class PlacementSys : MonoBehaviour
{
    [SerializeField]
    GameObject mouseIndicator, cellIndicator;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private Grid grid;

    [SerializeField]
    private ObjectDatabaseSO database;
    private int selectedObjectIndex = -1;

    [SerializeField]
    private LayerMask roadLayer;

    [SerializeField]
    private GameObject gridVisualization;

    private GridData towerData;

    private Renderer previewRenderer;

    private List<GameObject> placedGameObject = new();


    private void Start()
    {
        StopPlacement();
        towerData = new GridData();
        previewRenderer = cellIndicator.GetComponentInChildren<Renderer>();
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();
        selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        if (selectedObjectIndex < 0)
        {
            Debug.LogError($"No ID found {ID}");
            return;
        }
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    public void StopPlacement()
    {
        selectedObjectIndex = -1;
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement;
    }

    private void PlaceStructure()
    {
        if (inputManager.IsPointerOverUI())
        {
            return;
        }
        Vector3 mousePos = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePos);

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        if (placementValidity == false)
        {
            return;
        }

        GameObject newGameObject = Instantiate(database.objectsData[selectedObjectIndex].Prefab);
        newGameObject.GetComponent<TowerScript>().id = selectedObjectIndex;
        newGameObject.transform.position = grid.CellToWorld(gridPosition);
        placedGameObject.Add(newGameObject);
        GridData selectedData = towerData;
        selectedData.AddObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size, database.objectsData[selectedObjectIndex].ID, placedGameObject.Count - 1);
    }

    private void Update()
    {
        if (selectedObjectIndex < 0)
        { return; }
        Vector3 mousePos = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePos);

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        previewRenderer.material.color = placementValidity ? Color.white : Color.red;

        mouseIndicator.transform.position = mousePos;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {
        GridData selectedData = towerData;

        if (HasRoadAbove(gridPosition, database.objectsData[selectedObjectIndex].Size))
        {
            return false;
        }

        return selectedData.CanPlaceObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size);
    }

    private bool HasRoadAbove(Vector3Int gridPosition, Vector2Int objectSize)
    {
        for (int x = 0; x < objectSize.x; x++)
        {
            for (int y = 0; y < objectSize.y; y++)
            {
                Vector3Int cellPos = gridPosition + new Vector3Int(x, 0, y);

                Vector3 cellWorldPos = grid.GetCellCenterWorld(cellPos);

                Vector3 rayOrigin = cellWorldPos + Vector3.up * 10f;
                float rayDistance = 20f;

                if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, rayDistance, roadLayer))
                {
                    return true;
                }
            }
        }

        return false;
    }
}