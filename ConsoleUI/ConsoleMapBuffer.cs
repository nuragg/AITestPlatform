using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArenaBase;

namespace ConsoleUI
{
    public class ConsoleMapBuffer
    {
        private DisplayTile[][] currentFinalTiles { get; set; } 
        private DisplayTile[][] requestedFinalTiles { get; set; }
        private DisplayTile[][] bufferedTiles {get; set;}

        public DisplayTile[][] GetBufferedTiles(BaseTile[][] requestedTiles)
        {
            PrepareTiles(requestedTiles);
            return bufferedTiles;
        }

        private DisplayTile[][] CopyBaseTilesToDisplayTiles(BaseTile[][] requestedTiles)
        {
            DisplayTile[][] newTiles = new DisplayTile[requestedTiles.Length][];
            for(int i = 0; i <requestedTiles.Length; i++) 
            {
                newTiles[i] = new DisplayTile[requestedTiles[i].Length];
                 for(int j = 0; j <requestedTiles[i].Length; j++) 
                 {
                     newTiles[i][j] = new DisplayTile() { Color = requestedTiles[i][j].Color, Icon = requestedTiles[i][j].Icon};
                 }
            }
            return newTiles;
        }

        private void PrepareTiles(BaseTile[][] requestedTiles)
        {
            requestedFinalTiles = CopyBaseTilesToDisplayTiles(requestedTiles);
            CalculateDifferencies();
        }

        private void CalculateDifferencies()
        {
            if (currentFinalTiles != null)
            {
                DisplayTile[][] Tiles = new DisplayTile[requestedFinalTiles.Length][];
                bool differentLine;
                for (int i = 0; i < currentFinalTiles.Length; i++)
                {
                    Tiles[i] = new DisplayTile[requestedFinalTiles[i].Length];
                    differentLine = false;
                    for (int j = 0; j < currentFinalTiles[i].Length; j++)
                    {
                        if (currentFinalTiles[i][j].Icon != requestedFinalTiles[i][j].Icon)
                            differentLine = true;

                        Tiles[i][j] = requestedFinalTiles[i][j];
                    }

                    if (!differentLine)
                        Tiles[i].ToList().ForEach(x => x.SkipThisTile = true);
                }

                bufferedTiles = Tiles;
            }
            else
            {
                bufferedTiles = requestedFinalTiles;
            }
            currentFinalTiles = requestedFinalTiles;
        }
    }
}
