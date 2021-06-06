using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class generates all the room with customizable inputs

//could potentntialy make a generalization of this class but I dont need it for this task
public class LevelGeneratorRectangle : MonoBehaviour
{
    //i m used to 2d tiles so 'y' in names will represent 'z' vector value
    [SerializeField] private int xSizeRadius = 2;
    [SerializeField] private int ySizeRadius = 2;

    [SerializeField] private int randomStart = 5;
    [SerializeField] private int randomTreshold = 2;
    [SerializeField] private int maxRandomRadius = 50;
    [SerializeField] private int chestFromCenter = 1;
    [SerializeField] private int lampEveryK = 2; 
    [SerializeField] private GameObject tile;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject bloomPlane;
    [SerializeField] private GameObject lamp;

    //z is north
    Quaternion northQ = Quaternion.Euler(0,90,0);
    Quaternion southQ = Quaternion.Euler(0, -90, 0);
    Quaternion westQ = Quaternion.Euler(0, 180, 0);
    Quaternion eastQ = Quaternion.Euler(0, 0, 0);

    Vector3 doorPos;
    Vector3 chestPos;

    [ContextMenu("Generate")]
    public void GenerateRoom() {
        ClampValues();
        GenerateTiles();
        GenerateDoor();
        GenerateWalls();
        GenerateChest();
        GenerateBloomPlane();
    }

    private void ClampValues()
    {
        if (randomStart < 3) randomStart = 3;
        if (randomStart - randomTreshold < 3) randomTreshold = 1;
    }

    [ContextMenu("Generate with random area")]
    public void RandomizeArea() {
        randomStart = PlayerPrefs.GetInt("RoomSize");
        xSizeRadius = UnityEngine.Random.Range(randomStart - randomTreshold, randomStart + randomTreshold);
        ySizeRadius = UnityEngine.Random.Range(randomStart - randomTreshold, randomStart + randomTreshold);
        Mathf.Clamp(xSizeRadius,1, maxRandomRadius);
        Mathf.Clamp(ySizeRadius, 1, maxRandomRadius);
        GenerateRoom();
    }
    
    private void GenerateTiles()
    {
        bool skipOne = true;
        for (int y = -ySizeRadius; y <= ySizeRadius; y++)
        {
            for (int x = -xSizeRadius; x <= xSizeRadius ; x++)
            {
                if (x % lampEveryK == 0 && y % lampEveryK == 0) {

                    if (skipOne)
                    {
                        GameObject lo = Instantiate(lamp, this.transform);
                        lo.transform.position = new Vector3(x, 0, y);
                    }
                    skipOne = !skipOne;
        
                }
                GameObject o = Instantiate(tile,this.transform);
                o.transform.position = new Vector3(x,0,y);
            }
        }
    }

    private void GenerateDoor()
    {
        var doorDir = GenerateRandomDirection4();
        doorPos = new Vector3(xSizeRadius* doorDir.x,0,ySizeRadius* doorDir.z);
        if(doorPos.x==0)
            doorPos = new Vector3( UnityEngine.Random.Range(-xSizeRadius+1, xSizeRadius - 1),0,doorPos.z);
        else
            doorPos = new Vector3(doorPos.x, 0, UnityEngine.Random.Range(-ySizeRadius + 1, ySizeRadius - 1));

        GameObject o = Instantiate(door, this.transform);
        o.transform.position = doorPos;
        o.transform.rotation = DirectionTo4DQuaterion(doorDir);
        //Debug.Log(doorDir);
    }

    private void GenerateWalls()
    {

        for (int x = -xSizeRadius; x <= xSizeRadius; x++)
        {
            Vector3 northWallPos = new Vector3(x, 0, ySizeRadius);
            Vector3 southWallPos = new Vector3(x, 0, -ySizeRadius);
            GameObject northWall;
            GameObject southWall;
            if (northWallPos != doorPos) {
                northWall = Instantiate(wall,this.transform);
                northWall.transform.position = northWallPos;
                northWall.transform.rotation = northQ;
            }
            if (southWallPos != doorPos)
            {
                southWall = Instantiate(wall, this.transform);
                southWall.transform.position = southWallPos;
                southWall.transform.rotation = southQ;
            }
            
        }
        for (int y = -ySizeRadius; y <= ySizeRadius; y++)
        {
            Vector3 westWallPos = new Vector3(xSizeRadius, 0, y);
            Vector3 easthWallPos = new Vector3(-xSizeRadius, 0, y);
            GameObject westWall;
            GameObject eastWall;
            if (westWallPos != doorPos)
            {
                westWall = Instantiate(wall, this.transform);
                westWall.transform.position = westWallPos;
                westWall.transform.rotation = westQ;
            }
            if (easthWallPos != doorPos)
            {
                eastWall = Instantiate(wall, this.transform);
                eastWall.transform.position = easthWallPos;
                eastWall.transform.rotation = eastQ;
            }

        }
    }

    private void GenerateChest()
    {
        var chestDir = GenerateRandomDirection4();

        Vector3 chestPos = FindNonObstructingPos(chestDir,new[] { doorPos }, chestFromCenter);
        GameObject o = Instantiate(chest, this.transform);
        o.transform.position = chestPos;
        o.transform.rotation = DirectionTo4DQuaterion(chestDir);

    }

    private void GenerateBloomPlane()
    {
        GameObject northPlane = Instantiate(bloomPlane, this.transform);
        northPlane.transform.position = new Vector3(0,0, ySizeRadius+2.5f);
        northPlane.transform.localScale = new Vector3(1, 1, (0.1f * ((xSizeRadius + 2) *2 +1)));
        northPlane.transform.rotation = northQ * Quaternion.Euler(0,0,-90);

        GameObject southPlane = Instantiate(bloomPlane, this.transform);
        southPlane.transform.position = new Vector3(0, 0, -ySizeRadius - 2.5f);
        southPlane.transform.localScale = new Vector3(1, 1, (0.1f * ((xSizeRadius + 2) * 2 + 1)));
        southPlane.transform.rotation = southQ * Quaternion.Euler(0, 180, 90);

        GameObject eastPlane = Instantiate(bloomPlane, this.transform);
        eastPlane.transform.position = new Vector3(xSizeRadius + 2.5f, 0,0);
        eastPlane.transform.localScale = new Vector3(1, 1, (0.1f * ((ySizeRadius + 2) * 2 + 1)));
        eastPlane.transform.rotation = eastQ * Quaternion.Euler(0, 180, -90);

        GameObject westPlane = Instantiate(bloomPlane, this.transform);
        westPlane.transform.position = new Vector3(-xSizeRadius - 2.5f, 0, 0);
        westPlane.transform.localScale = new Vector3(1, 1, (0.1f * ((ySizeRadius + 2) * 2 + 1)));
        westPlane.transform.rotation = westQ * Quaternion.Euler(0, 0, 90);


    }

    private Vector3 FindNonObstructingPos(Vector3 direction,Vector3[] toAvoid,int fromCenter) {
        
        Vector3 final = Vector3.zero;
        do{
            Vector3 checking = direction;
            int randomX;
            float randomY;
            if (direction.x != 0) {
                randomX = (int)UnityEngine.Random.Range(direction.x* fromCenter, direction.x*xSizeRadius+1);
                randomY = (int)UnityEngine.Random.Range(-ySizeRadius+1,+ySizeRadius);
            }
            else 
            {
                randomX = (int)UnityEngine.Random.Range(-xSizeRadius + 1, +xSizeRadius);
                randomY = (int)UnityEngine.Random.Range(direction.z* fromCenter, direction.z * ySizeRadius+1);
            }
            checking = new Vector3(randomX,0,randomY);
            bool isOccupied = false;
            foreach (Vector3 v in toAvoid) {
                if (checking == v)
                    isOccupied = true;
            }
            if (!isOccupied)
                final = checking;
            
        } while (final == Vector3.zero);//<- its a placeholder value but also i dont want chest to spawn on (0,0) 

        return final;
    }


    private Quaternion DirectionTo4DQuaterion(Vector3 dir) {
        return Quaternion.LookRotation(-dir) * Quaternion.FromToRotation(Vector3.right, Vector3.forward);
    }

    private Vector3 GenerateRandomDirection4() {
        bool randomizeX = UnityEngine.Random.Range(-1, 2) > 0 ? true : false;
        if (randomizeX) {
            return new Vector3((UnityEngine.Random.Range(-1, 2) > 0 ? -1 : 1), 0, 0);
        }
        else
            return new Vector3(0, 0, (UnityEngine.Random.Range(-1, 2) > 0 ? -1 : 1));
    }
}
