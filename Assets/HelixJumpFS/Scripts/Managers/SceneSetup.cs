using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private LevelProgress levelProgress;

    private void Start()
    {
        levelGenerator.Generate(levelProgress.CurrentLevel);
        ballTransform.position = new Vector3(ballTransform.position.x, levelGenerator.UpperFloorY, ballTransform.position.z);
    }
}
