using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public bool useTestTheme = false;
    public int testThemeIndex = 0;
    public List<ThemeMaterial> themeMaterials = new List<ThemeMaterial>();
    public Camera mainCam;

    void Start ()
    {
        int themeIndex = Random.Range(0, themeMaterials[0].wallTopCol.Length);
        ApplyTheme(themeIndex);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Start();
        }
    }

    public void ApplyTheme (int themeIndex)
    {
        if (useTestTheme)
            themeIndex = testThemeIndex;
        foreach (ThemeMaterial themeMaterial in themeMaterials)
        {
            themeMaterial.wallTopMat.color = themeMaterial.wallTopCol[themeIndex];
            themeMaterial.wallBottomMat.color = themeMaterial.wallBottomCol[themeIndex];
            themeMaterial.floorMat.color = themeMaterial.floorCol[themeIndex];
        }
    }

    public void ChangeThemeColor()
    {
        Start();
    }
}

[System.Serializable]
public class ThemeMaterial
{
    public Material wallTopMat, wallBottomMat, floorMat;
    public Color[] wallTopCol, wallBottomCol, floorCol;
}