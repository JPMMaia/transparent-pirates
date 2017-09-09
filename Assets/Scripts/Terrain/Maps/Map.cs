using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Terrain
{
    public class Map : MonoBehaviour
    {
        private char[,] _map;

        public void Start()
        {
            IMapBuilder builder = new DefaultMapBuilder();

            _map = builder.Build();

            InstantiateTiles(_map);
        }

        public void Update()
        {
        }

        private void InstantiateTiles(char[,] map)
        {
            var tilePrefab = TerrainPrefabs.Instance.TilePrefab;

            var builders = new Dictionary<char, ITileBuilder>();
            builders['#'] = new WallTileBuilder();
            builders[' '] = new BlankTileBuilder();

            var parent = this.transform;

            for(var rowIndex = 0; rowIndex < map.GetLength(0); ++rowIndex)
            {
                for (var columnIndex = 0; columnIndex < map.GetLength(1); ++columnIndex)
                {
                    var position = new Vector3(columnIndex, -rowIndex, 0.0f);
                    var rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

                    var tileInstance = Instantiate(tilePrefab, position, rotation, parent);
                    var tileBuilder = builders[map[rowIndex, columnIndex]];
                    tileBuilder.Build(tileInstance);
                }
            }
        }
    }
}
