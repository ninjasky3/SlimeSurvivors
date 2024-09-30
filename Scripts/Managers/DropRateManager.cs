using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]   //Serialize the class
    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;
    }

    public List<Drops> drops;

    void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) //Stops the spawning error from appearing when stopping play mode
        {
            return;
        }

        float randomNumber = UnityEngine.Random.Range(0f, 100f); //get rng
        List<Drops> possibleDrops = new List<Drops>();

        //use dropRate to see if the item drops.
        foreach (Drops rate in drops)
        {
            if (randomNumber <= rate.dropRate)
            {
                possibleDrops.Add(rate);
            }
        }
        //Check if there are possible drops
        if (possibleDrops.Count > 0)
        {
            foreach (Drops d in possibleDrops)
            {
                Instantiate(d.itemPrefab, transform.position, Quaternion.identity);
            }
            //use this code if you want to randomize the drops.
            //Drops drops = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count)];
            
        }
    }
}