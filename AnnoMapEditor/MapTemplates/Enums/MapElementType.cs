﻿using AnnoMapEditor.Utilities;
using System.Linq;
using AnnoMapEditor.MapTemplates.Models;

namespace AnnoMapEditor.MapTemplates.Enums
{
    public class MapElementType
    {
        private static readonly Logger<MapElementType> _logger = new();

        public static readonly MapElementType FixedIsland  = new(null);
        public static readonly MapElementType PoolIsland   = new(1);
        public static readonly MapElementType StartingSpot = new(2);

        public static readonly MapElementType[] All = new[] { FixedIsland, PoolIsland, StartingSpot };


        public int? ElementValue { get; init; }

        
        private MapElementType(int? elementValue)
        {
            ElementValue = elementValue;
        }


        public static MapElementType FromElementValue(int? elementValue)
        {
            MapElementType? mapElementType = All.FirstOrDefault(d => d.ElementValue == elementValue);

            if (mapElementType is null)
            {
                _logger.LogWarning($"{elementValue} is not a valid element value for {nameof(MapElementType)}. Defaulting to {nameof(FixedIsland)}.");
                mapElementType = FixedIsland;
            }

            return mapElementType;
        }

        public static MapElementType FromElement(MapElement mapElement)
        {
            return mapElement switch
            {
                FixedIslandElement => FixedIsland,
                RandomIslandElement => PoolIsland,
                StartingSpotElement => StartingSpot,
                _ => FixedIsland
            };
        }
    }
}
