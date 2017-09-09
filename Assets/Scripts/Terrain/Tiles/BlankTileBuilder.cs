using UnityEngine;

namespace Assets.Scripts.Terrain
{
    public class BlankTileBuilder : ITileBuilder
    {
        public void Build(Tile instance)
        {
            var materials = TerrainPrefabs.Instance.BlankMaterials;

            var meshRenderer = instance.GetComponent<MeshRenderer>();
            meshRenderer.material = materials[Random.Range(0, materials.Length)];
        }
    }
}
