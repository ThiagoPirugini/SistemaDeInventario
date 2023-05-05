using UnityEngine;

public class Slot 
{
    #region Variáveis
    public Item item;
    public Rect Retangulo;
    public int Identidade;
    #endregion

    #region Métodos
    public bool contemVetor(Vector2 vetor)
    {
        int x = (int)(Retangulo.x);
        int y = (int)(Retangulo.y);
        int xMax = (int)(Retangulo.x + Retangulo.width);
        int yMax = (int)(Retangulo.y + Retangulo.height);

        if(vetor.x > x && vetor.x < xMax)
        {
            if(vetor.y > y && vetor.y < yMax)
            {
                return true;
            }else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion
}
