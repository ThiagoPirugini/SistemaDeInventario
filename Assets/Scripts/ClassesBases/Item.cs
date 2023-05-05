using UnityEngine;

[System.Serializable]
public class Item
{
    #region Variáveis
    public int Identidade;
    public string Nome;
    public Texture2D Icone;
    public GameObject Objeto;
    public bool Empilhavel;
    public int Quantidade;
    #endregion

    #region Métodos Construtores
    public Item(int ID, string nome, Texture2D icone, GameObject objeto, bool empilhavel)
    {
        Identidade = ID;
        Nome = nome;
        Icone = icone;
        Objeto = objeto;
        Empilhavel = empilhavel;
        Quantidade = 1;
        return;
    }

    public Item(Item item, int quantidade)
    {
        Identidade = item.Identidade;
        Nome = item.Nome;
        Icone = item.Icone;
        Objeto = item.Objeto;
        Empilhavel = item.Empilhavel;
        Quantidade = quantidade;
    }
    #endregion

    #region Métodos/Funções
    public void Adicionar(int quantidade)
    {
        if(Empilhavel)
        {
            Quantidade += quantidade;
        }
        else
        {
            return;
        }
    }

    public bool deveSerRemovido()
    {
        if(Quantidade <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion


}
