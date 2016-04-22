using UnityEngine;
using System.Collections;

public class ToolsGlobal : MonoBehaviour {

    // Modificadores temporal e de movimento
    public static float modifTemporal = 0.004f;

    //variaveis de movimento
    public static Random rnd = new Random( );
    public static float margemX = 1.2f;
    public static float limiteYSuperior = 5.3f;
    public static float limiteYInferior = -5.3f;
    public static float limiteXEsquerda = -1.0f;
    public static float limiteXDireita = 0.5f;
    public static float ordemZ = -1.0f;
    // variaveis de desvio de movimento
    public static float modifDesvioCurso = 0.2f;
    public static float modifDesvioMax = 0.4f;
    public static float modifDesvioMin = -modifDesvioMax;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
