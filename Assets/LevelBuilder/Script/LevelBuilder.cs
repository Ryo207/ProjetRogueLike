#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelGeneration
{
    [ExecuteInEditMode]
    public class LevelBuilder : MonoBehaviour
    {
        [Header("Your scene's tilemap:")]
        [SerializeField] Tilemap tilemap = null;
        [Header("Your imported level texture:")]
        [SerializeField] Texture2D levelMap = null;
        [Header("Your tiles and associated colors:")]
        [SerializeField] LevelTile[] levelTiles;
        [Space]
        [Header("Tick this box to generate the level.")]
        [SerializeField] bool apply = false;

        private void Update()
        {
            if(apply)
            {
                apply = false;
                GenerateLevel();
            }
        }

        void GenerateLevel()
        {
            for(int x = 0; x < levelMap.width; x++)
            {
                for (int y = 0; y < levelMap.height; y++)
                {
                    GenerateTile(x, y);
                }
            }

            print("Level succesfully generated!");
        }

        void GenerateTile(int _x, int _y)
        {
            Color _pixelColor = levelMap.GetPixel(_x, _y);

            if (_pixelColor.a == 0 || _pixelColor == Color.white)
            {
                return;
            }

            foreach(LevelTile levelTile in levelTiles)
            {
                if(levelTile.importColor.Equals(_pixelColor))
                {
                    tilemap.SetTile(new Vector3Int(_x, _y, 0), levelTile.tileSprite);
                }
            }
        }
    }

    [System.Serializable]
    public struct LevelTile
    {
        public TileBase tileSprite;
        public Color importColor;
    }
}
#endif