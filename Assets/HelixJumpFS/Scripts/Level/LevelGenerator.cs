using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform axis;
    [SerializeField] private Floor floorPrefab;
    [SerializeField] private LevelProgress levelProgress;

    [Header("Settings")]
    [SerializeField] private int initFloorAmount;
    [SerializeField] private float floorHeight;
    [SerializeField] [Min(0)] private int amountEmptySegments;
    [SerializeField] [Min(0)] private int minAmountTrapSegments;
    [SerializeField] [Min(0)] private int maxAmountTrapSegments;

    private float upperFloorY;
    public float UpperFloorY => upperFloorY;

    private void Start()
    {
        if (maxAmountTrapSegments < minAmountTrapSegments) maxAmountTrapSegments = minAmountTrapSegments;
    }

    public void Generate(int level)
    {
        if (level < 0) return;
        DestroyLevel();
        axis.localScale = new Vector3(axis.localScale.x, RealFloorAmount() * floorHeight + 5, axis.localScale.z);
        
        for (int i = 0; i < RealFloorAmount(); i++)
        {
            Floor floor = Instantiate(floorPrefab, transform);
            floor.transform.Translate(0, floorHeight * i, 0);
            floor.name = "Floor " + i;
            if (i == 0)
            {
                floor.SetAllFinishSegments();
            }
            else if (i == RealFloorAmount() - 1)
            {
                upperFloorY = floor.transform.position.y;
                floor.AddEmptySegments(amountEmptySegments);
            }
            else
            {
                floor.AddEmptySegments(amountEmptySegments);
                floor.AddRandomTrapSegments(Random.Range(minAmountTrapSegments, maxAmountTrapSegments + 1));
                floor.SetRandomRotation();
            }
        }
    }

    private void DestroyLevel()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i) == axis) continue;
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public int RealFloorAmount()
    {
        return initFloorAmount + levelProgress.CurrentLevel - 1;
    }
}
