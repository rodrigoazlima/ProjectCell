using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using Random = UnityEngine.Random;


public class ControladorGBranco : MonoBehaviour
{

    // Controlador
    public CharacterController cc;

    // Atibutos
    public int speed;
    public int life;
    public int attack;

    //controle de desvio
    private float desvioCursoAntigo = 0f;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        updateMoviment();
    }


    void updateMoviment()
    {
        var pos = cc.transform.position;
        // Checar os limites do eixo Y para resetar
        if ( pos.y > ToolsGlobal.limiteYSuperior
            || pos.y < ToolsGlobal.limiteYInferior ) {

            float rndX = Random.Range( ToolsGlobal.limiteXEsquerda, ToolsGlobal.limiteXDireita );
            cc.transform.position = new Vector3( rndX,
                ToolsGlobal.limiteYSuperior,
                ToolsGlobal.ordemZ );

        } else {// Se nao verifica bordas do eixo X

            //velocidade
            float speedTotal = ToolsGlobal.modifTemporal * - speed ;
            //desvio
            float desvio = Random.Range(-ToolsGlobal.modifDesvioCurso, ToolsGlobal.modifDesvioCurso );

            // Desvio máximo/minimo
            if ( desvio + desvioCursoAntigo > ToolsGlobal.modifDesvioMax ) {
                desvio = ToolsGlobal.modifDesvioMax;
            } else if ( desvio + desvioCursoAntigo < ToolsGlobal.modifDesvioMin ) {
                desvio = ToolsGlobal.modifDesvioMin;
            } else {
                desvio += desvioCursoAntigo;
            }

            float x = speedTotal * desvio;
            float y = speedTotal - x;
            // Limite do eixo X
            if ( ToolsGlobal.limiteXDireita < pos.x + x
                || ToolsGlobal.limiteXEsquerda > pos.x + y + cc.transform.localScale.x ) {
                desvio = -desvio;
            }

            desvioCursoAntigo = desvio;

            x = speedTotal * desvio;
            y = speedTotal - x;

            print( "DesvioX: " + x + "\n" +
                   "DesvioY: " + y + "\n" +
                   "Pos:"+ cc.transform.position );
            cc.Move(new Vector3(x, y, 0));
        }
    }
}
