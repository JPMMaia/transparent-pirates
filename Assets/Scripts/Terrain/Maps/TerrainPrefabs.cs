using UnityEngine;

namespace Assets.Scripts.Terrain
{
    public class TerrainPrefabs : MonoBehaviour
    {
        private static TerrainPrefabs _instance;
        public static TerrainPrefabs Instance
        {
            get
            {
                if(!_instance)
                    _instance = FindObjectOfType<TerrainPrefabs>();

                return _instance;
            }
        }

        public Tile TilePrefab;

        public Material[] WallMaterials;
        public Material[] BlankMaterials;
    }
}
