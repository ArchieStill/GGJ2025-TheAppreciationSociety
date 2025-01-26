using UnityEngine;

public class refillScript : MonoBehaviour
{
    public GameObject teaPrefab;
    public GameObject milkPrefab;
    public GameObject syrupPrefab; // WE HAVE FUCKING SYRUP!!

    public Material teaMat;
    public Material milkMat;
    public Material syrupMat;
    
    public MeshRenderer liquidRenderer;
    private Material liquidMat;
    
    public GameObject bottomOfCup;
    
    public bool isTea   = false;
    public bool isMilk  = false;
    public bool isSyrup = false; // new toggle
    
    public float refillIncrement = 0.01f;
    public float startFillOffset = -0.2f;

    private float teaVolume   = 0f;
    private float milkVolume  = 0f;
    private float syrupVolume = 0f; // track syrup volume

    private Color teaColor;
    private Color milkColor;
    private Color syrupColor; // color from syrup

    private void Start()
    {
        liquidMat = liquidRenderer.material;
        liquidMat.SetFloat("_GlobalFill", bottomOfCup.transform.position.y + startFillOffset);

        teaColor    = teaMat.color;
        milkColor   = milkMat.color;
        syrupColor  = syrupMat.color;
    }

    private void Update()
    {
        float currentFill = liquidMat.GetFloat("_GlobalFill");

        if (isTea)
        {
            currentFill += (refillIncrement * Time.deltaTime);
            teaVolume   += (refillIncrement * Time.deltaTime);
        }
        if (isMilk)
        {
            currentFill += (refillIncrement * Time.deltaTime);
            milkVolume  += (refillIncrement * Time.deltaTime);
        }
        if (isSyrup)
        {
            currentFill  += (refillIncrement * Time.deltaTime);
            syrupVolume  += (refillIncrement * Time.deltaTime);
        }

        // Update the fill level in the material
        liquidMat.SetFloat("_GlobalFill", currentFill);

        // Calculate the total liquid volume and derive each ratio
        float totalVolume = teaVolume + milkVolume + syrupVolume;
        if (totalVolume > 0f)
        {
            float teaRatio   = teaVolume   / totalVolume;
            float milkRatio  = milkVolume  / totalVolume;
            float syrupRatio = syrupVolume / totalVolume;

            // Mix the 3 colors according to their ratios
            Color finalColor = (teaColor   * teaRatio) + 
                               (milkColor  * milkRatio) + 
                               (syrupColor * syrupRatio);

            liquidMat.SetColor("_Color", finalColor);
        }
    }
}
