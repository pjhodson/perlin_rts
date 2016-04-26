using UnityEngine;
using System.Collections;

public class PERLIN_TERRAIN : MonoBehaviour {

    [SerializeField]
    public long nRows;
    [SerializeField]
    public long nCols;
    [SerializeField]
    public float threshold;
    [SerializeField]
    public GameObject terrainCube;
    [SerializeField]
    public float mapScale;
    [SerializeField]
    public float mapHeight;

    [SerializeField]
    private float[,] map;

    private Vector2 mapOffset;

	// Use this for initialization
	void Start () {

        mapOffset = new Vector2(Random.Range(1.0f, 100.0f), Random.Range(1.0f, 100.0f));
	    map = new float[nRows,nCols];

        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nCols; j++)
            {
                float xCoord = (mapOffset.x + i) / (nRows * mapScale);
                float yCoord = (mapOffset.y + j) / (nCols * mapScale);
                map[i, j] = Mathf.PerlinNoise(xCoord,yCoord);
                Debug.Log(map[i, j]);
            }
        }

        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nCols; j++)
            {
                if (map[i, j] > threshold)
                {
                    Debug.Log(map[i, j] + " " + threshold);
                    Instantiate(terrainCube, new Vector3(i+1,1, j+1), Quaternion.identity);

                    int level = (int)(Mathf.Floor(map[i, j] * 10)/mapHeight);

                    for (int k = 1; k <= level; k++)
                    {
                        Instantiate(terrainCube, new Vector3(i + 1, k + 1, j + 1), Quaternion.identity);
                    }

                }
            }
        }
	}

    // Update is called once per frame
    void Update()
    {
	    
	}
}
