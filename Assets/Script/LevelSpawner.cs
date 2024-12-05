using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject roadTile;

    //public int roadLength = 30;
    public int roadWidth = 5;

    // camera game object
    public GameObject cameraGO;

    public Sprite plainRoad;

    // image of the road edge
    public Sprite leftRoad;
    public Sprite rightRoad;

    // make a start road
    public Sprite leftStartRoad;
    public Sprite rightStartRoad;
    public Sprite startRoad;

    // grass on the road side
    public Sprite grassTile;

    // default y value
    public float maxYLevel = -1f;
    public GameObject _carObj; // car object
    public int previousYLevel = -1; // int, because we want y level be every even number

    // 一系列可碰撞的 game object
    //public List<GameObject> roadCollidables = new List<GameObject>();
    //public List<GameObject> sideRoadCollidables = new List<GameObject>();
    public List<CollidableObject> roadCollidables = new List<CollidableObject>();
    public List<CollidableObject> sideRoadCollidables = new List<CollidableObject>();

    int weightTotalMainRoad = 0;
    int weightTotalSideRoad = 0;

    [Range(0,100)]
    public int roadCollidableSpawningChance = 5;
    [Range(0, 100)]
    public int sideRoadCollidableSpawningChance = 90;

    // Start is called before the first frame update
    void Start()
    {
        // set the camera at the middle of the road
        // divide by 2f, the number might be float number
        cameraGO.transform.position = new Vector3((roadWidth-1) / 2f, 2, -10f);

        //// start road
        //for(int x=0;x<roadWidth;x++)
        //{
        //    GameObject _insTile = GameObject.Instantiate(roadTile, this.transform);
        //    _insTile.transform.position = new Vector3(x, -1, 0);
        //    _insTile.transform.name = "RoadTile(" + x + ",-1)";

        //    _insTile.GetComponent<SpriteRenderer>().sprite = startRoad;
        //    if (x == 0)// if it's the left most of the road
        //    {
        //        _insTile.GetComponent<SpriteRenderer>().sprite = leftStartRoad;
        //    }

        //    if (x == roadWidth - 1)// if it's the right most of the road
        //    {
        //        _insTile.GetComponent<SpriteRenderer>().sprite = rightStartRoad;
        //    }
        //}

        //// this part spawns the road
        //for(int y=0;y<roadLength;y++)
        //{
        //for(int x=0;x<roadWidth;x++)
        //{
        //    // _insTile is local variable, Instantiate is a function to copy/clone object, the 2nd parameter is the location to store, this hierarchy layer
        //    GameObject _insTile = GameObject.Instantiate(roadTile,this.transform);

        //    // vector3 is the 3d direction
        //    _insTile.transform.position = new Vector3(x, y, 0);

        //    // set the name of the road tile
        //    _insTile.transform.name = "RoadTile(" + x + "," + y + ")";

        //    // add edge of the road
        //    if(x == 0)// if it's the left most of the road
        //    {
        //        _insTile.GetComponent<SpriteRenderer>().sprite = leftRoad;
        //    }

        //    if (x == roadWidth-1)// if it's the right most of the road
        //    {
        //        _insTile.GetComponent<SpriteRenderer>().sprite = rightRoad;
        //    }
        //}
        //}

        //// this part spawns the grass
        //for (int y = -1; y < roadLength; y++)
        //{
        //    for (int x = -2; x < roadWidth+2; x++)
        //    {
        //        GameObject _insTile = GameObject.Instantiate(roadTile, this.transform);
        //        _insTile.transform.position = new Vector3(x, y, 2);
        //        _insTile.transform.name = "GrassTile(" + x + "," + y + ")";
        //        _insTile.GetComponent<SpriteRenderer>().sprite = grassTile;
        //    }
        //}

        foreach(CollidableObject obj in roadCollidables)
        {
            weightTotalMainRoad += obj.chance;
        }

        foreach (CollidableObject obj in sideRoadCollidables)
        {
            weightTotalSideRoad += obj.chance;
        }
    }

    // instead of generated fixed length road, we create a function which can be called in a for loop
    // parameter y is the value/position at y asix
    void SpawnRow(float y)
    {
        // this part spawns the road at the given y value
        for (int x = -2; x < roadWidth+2; x++)
        {
            // _insTile is local variable, Instantiate is a function to copy/clone object, the 2nd parameter is the location to store, this hierarchy layer
            //GameObject _insTile = GameObject.Instantiate(roadTile, this.transform);
            GameObject _insTile = GameObject.Instantiate(getGOToSpawn(x), this.transform);

            // vector3 is the 3d direction
            _insTile.transform.position = new Vector3(x, y, 0);

            // set the name of the road tile
            _insTile.transform.name = "RoadTile(" + x + "," + y + ")";

            // add component DestroyMe script to the road tile we create, 
            _insTile.AddComponent<DestroyMe>().carObj = _carObj;

            // rock
            int _rng = Random.Range(0, 100);
            if (_rng <= roadCollidableSpawningChance && (x >= 0 && x <= (roadWidth - 1)))
            {
                //int _listRNG = Random.Range(0, roadCollidables.Count);
                //GameObject _colObj = GameObject.Instantiate(roadCollidables[_listRNG].obj, this.transform);
                GameObject _colObj = GameObject.Instantiate(RandomWeighted(weightTotalMainRoad,roadCollidables), this.transform);
                _colObj.transform.position = new Vector3(x, y, -2);
                _colObj.transform.name = "CollidableTile(" + x + "," + y + ")";
                _colObj.AddComponent<DestroyMe>().carObj = _carObj;
            }
            else if (_rng >= sideRoadCollidableSpawningChance && (x == -2 || x == -1 || x == roadWidth + 1 || x == roadWidth))
            {
                //int _listRNG = Random.Range(0, sideRoadCollidables.Count);
                //GameObject _colObj = GameObject.Instantiate(sideRoadCollidables[_listRNG].obj, this.transform);
                GameObject _colObj = GameObject.Instantiate(RandomWeighted(weightTotalSideRoad, sideRoadCollidables), this.transform);
                _colObj.transform.position = new Vector3(x, y, -2);
                _colObj.transform.name = "sideRoadCollidableTile(" + x + "," + y + ")";
                _colObj.AddComponent<DestroyMe>().carObj = _carObj;
            }

            //// add edge of the road
            //if (x == 0)// if it's the left most of the road
            //{
            //    _insTile.GetComponent<SpriteRenderer>().sprite = leftRoad;
            //}

            //if (x == roadWidth - 1)// if it's the right most of the road
            //{
            //    _insTile.GetComponent<SpriteRenderer>().sprite = rightRoad;
            //}
        }

        //// this part spawns the grass at the given y value
        //for (int x = -2; x < roadWidth + 2; x++)
        //{
        //    GameObject _insTile = GameObject.Instantiate(roadTile, this.transform);
        //    _insTile.transform.position = new Vector3(x, y, 2);
        //    _insTile.transform.name = "GrassTile(" + x + "," + y + ")";
        //    _insTile.GetComponent<SpriteRenderer>().sprite = grassTile;
        //    _insTile.AddComponent<DestroyMe>().carObj = _carObj;
        //}
    }

    // random generate object by their weight
    GameObject RandomWeighted(int _total, List<CollidableObject> _list)
    {
        int result = 0;
        int total = 0;
        int randVal = Random.Range(0, _total);

        for (result = 0; result < _list.Count; result++)
        {
            total += _list[result].chance;
            if (total > randVal) break;
        }
        return _list[result].obj;
    }

    // spawn game object to _x position, depend on the x position
    GameObject getGOToSpawn(int _x)
    {
        GameObject _go = roadTile;
        _go.GetComponent<SpriteRenderer>().sprite = plainRoad;

        if(_x == -2 || _x == -1 || _x == roadWidth+1 || _x == roadWidth ) // grass
        {
            _go.GetComponent<SpriteRenderer>().sprite = grassTile;
            return _go;
        }
        else if(_x == roadWidth - 1)
        {
            _go.GetComponent<SpriteRenderer>().sprite = rightRoad;
            return _go;
        }
        else if(_x == 0)
        {
            _go.GetComponent<SpriteRenderer>().sprite = leftRoad;
            return _go;
        }
        else
        {
            return _go;// regular game object
        }

    }

    // Update is called once per frame
    void Update()
    {
        // if the car higher than the top road we have spawned
        while(_carObj.transform.position.y > (maxYLevel - 6)) // -6 is because the road should be cover the whole screen, not just above the car
        {
            previousYLevel = previousYLevel + 1;
            // spawn the road with lenght( difference between previous and current)
            SpawnRow(previousYLevel);
            maxYLevel = previousYLevel;
        }
    }
}

// the new class can be read by unity
[System.Serializable]

public class CollidableObject
{
    public GameObject obj;
    [Range(0,100)]
    public int chance;

}
