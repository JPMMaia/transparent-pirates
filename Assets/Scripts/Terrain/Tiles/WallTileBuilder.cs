using UnityEngine;

namespace Assets.Scripts.Terrain
{
    public class WallTileBuilder : ITileBuilder
    {
        public void Build(Tile instance)
        {
            var materials = TerrainPrefabs.Instance.WallMaterials;

            var meshRenderer = instance.GetComponent<MeshRenderer>();
            meshRenderer.material = materials[Random.Range(0, materials.Length)];

            var boxCollider = instance.GetComponent<BoxCollider2D>();
            boxCollider.enabled = true;
        }
    }
}
