using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    #region Text
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI chainTxt;
    #endregion

    #region Float
    public float score;
    public float ennemy1Killed;
    public float ennemy2Killed;
    public float ennemy3Killed;
    #endregion

    #region Bool
    public bool combo;
    #endregion
    
    #region [Integer]

    public int chain;
    public int ennemy1 = 30;
    public int ennemy2 = 50;
    public int ennemy3 = 100;
    #endregion
    
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("PLus d'une instance de ScoreManager dans la scene");
            return;
        }
      
        instance = this;
    }
    
    void Start() //Initialisation des variables
    {
        ennemy1Killed = 0;
        ennemy2Killed = 0;
        ennemy3Killed = 0;
        
        chain = 1;
        combo = false;
        score = 0;
        
        UpdateValue();
    } 

    void Update() //MaJ du score
    {
        UpdateValue(); 
    }
    
    public void ComboOff()  //Lorsque le joueur se fait toucher, son gameObject appel la fonction pour désactiver le combo
    {
        chain = 1;
        combo = false;
    }

    void UpdateValue()  //Maj de la UI du score et du multiplicateur
    {
        scoreTxt.text = score.ToString();
        chainTxt.text = chain.ToString();
    }

    public void Counter1()
    {
        ennemy1Killed ++;
        chain ++;
        combo = true;

        if (combo == true)
        {
            score += ennemy1 * chain;
        }

    } //Compteur du score pour le Jeteur de Maïs
    public void Counter2()
    {
        ennemy2Killed ++;
        chain ++;
        combo = true;

        if (combo == true)
        {
            score += ennemy2 * chain;
        }
    } //Compteur du score pour l'homme à la fourche
    public void Counter3()
    {
        ennemy3Killed ++;
        chain ++;
        combo = true;

        if (combo == true)
        {
            score += ennemy3 * chain;
        }

    }//Compteur du score pour le Patator 
}