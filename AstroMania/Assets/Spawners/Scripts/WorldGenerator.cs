using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public static WorldGenerator Instance { get; private set; }

    private Player player;
    private Vector2 PlayerPos => player.transform.position;

    [SerializeField] private Sector sectorPrefab;
    private float SectorWidth => sectorPrefab.Width;
    private Sector currentSector;
    private List<Sector> generatedSectors = new();

    // New sectors will be generated when the player moves this distance
    // horizontally/vertically away from the origin of the current sector
    private float DistanceThreshold => 0.4f * SectorWidth;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        player = Player.Instance;
        Sector.EnteredSector += OnEnterSector;
        player.PlayerDied += OnPlayerDeath;
        currentSector = GenerateSector(transform.position);
    }

    private void OnEnterSector(object sender, Sector sector)
    {
        currentSector = sector;
    }

    private void Update()
    {
        var moveDir = (PlayerPos - currentSector.Origin);

        var exceededHorizontalThreshold = Mathf.Abs(PlayerPos.x - currentSector.Origin.x) > DistanceThreshold;
        var exceededVerticalThreshold = Mathf.Abs(PlayerPos.y - currentSector.Origin.y) > DistanceThreshold;

        var exceededRightThreshold = exceededHorizontalThreshold && moveDir.x > 0;
        var exceededLeftThreshold = exceededHorizontalThreshold && moveDir.x < 0;
        var exceededTopThreshold = exceededVerticalThreshold && moveDir.y > 0;
        var exceededBottomThreshold = exceededVerticalThreshold && moveDir.y < 0;

        // Right
        if (exceededRightThreshold)
        {
            GenerateSector(new Vector2(currentSector.Origin.x + SectorWidth, currentSector.Origin.y));
        }

        // Left
        if (exceededLeftThreshold)
        {
            GenerateSector(new Vector2(currentSector.Origin.x - SectorWidth, currentSector.Origin.y));
        }

        // Top
        if (exceededTopThreshold)
        {
            GenerateSector(new Vector2(currentSector.Origin.x, currentSector.Origin.y + SectorWidth));
        }

        // Bottom
        if (exceededBottomThreshold)
        {
            GenerateSector(new Vector2(currentSector.Origin.x, currentSector.Origin.y - SectorWidth));
        }

        // Top right
        if (exceededRightThreshold && exceededTopThreshold)
        {
            GenerateSector(new Vector2(currentSector.Origin.x + SectorWidth, currentSector.Origin.y + SectorWidth));
        }

        // Bottom right
        if (exceededRightThreshold && exceededBottomThreshold)
        {
            GenerateSector(new Vector2(currentSector.Origin.x + SectorWidth, currentSector.Origin.y - SectorWidth));
        }

        // Top left
        if (exceededLeftThreshold && exceededTopThreshold)
        {
            GenerateSector(new Vector2(currentSector.Origin.x - SectorWidth, currentSector.Origin.y + SectorWidth));
        }

        // Bottom left
        if (exceededLeftThreshold && exceededBottomThreshold)
        {
            GenerateSector(new Vector2(currentSector.Origin.x - SectorWidth, currentSector.Origin.y - SectorWidth));
        }
    }

    private Sector GenerateSector(Vector2 sectorOrigin)
    {
        if (!generatedSectors.Any(sector => sector.Origin == sectorOrigin))
        {
            var sector = Instantiate(sectorPrefab, sectorOrigin, Quaternion.identity);
            generatedSectors.Add(sector);
            return sector;
        }
        return null;
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }
}