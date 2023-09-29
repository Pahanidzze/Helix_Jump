using System.Collections.Generic;
using UnityEngine;

public class TrailCollector : MonoBehaviour
{
    private List<GameObject> trails;

    private void Start()
    {
        trails = new List<GameObject>();
    }

    public void AddTrail(GameObject trail)
    {
        trails.Add(trail);
    }

    public void CleanTrails()
    {
        for(int i = 0; i < trails.Count; i++)
        {
            Destroy(trails[i]);
        }
        trails.Clear();
    }
}
