using System.Collections.Generic;
using UnityEngine;

public class LevelColorSetup : MonoBehaviour
{
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material trapMaterial;
    [SerializeField] Material finishMaterial;
    [SerializeField] Material ballMaterial;
    [SerializeField] Material axisMaterial;
    [Header("Palette")]
    [SerializeField] List<Color> defaultColors;
    [SerializeField] List<Color> trapColors;
    [SerializeField] List<Color> finishColors;
    [SerializeField] List<Color> ballColors;
    [SerializeField] List<Color> axisColors;

    private void Awake()
    {
        ChangeColorOfMaterial(defaultMaterial, defaultColors);
        ChangeColorOfMaterial(trapMaterial, trapColors);
        ChangeColorOfMaterial(finishMaterial, finishColors);
        ChangeColorOfMaterial(ballMaterial, ballColors);
        ChangeColorOfMaterial(axisMaterial, axisColors);
    }

    private void ChangeColorOfMaterial(Material material, List<Color> colors)
    {
        if (material == null || colors.Count == 0) return;
        material.color = colors[Random.Range(0, colors.Count)];
    }
}
