using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Sprite ingredientSprite;

    public Transform[] points;

    private List<GameObject> ingredientList = new List<GameObject>();

    Vector3 scale = new Vector3(.7f, .7f, .7f);

    public void CollectIngredient(GameObject ingredient)
    {
        if (ingredient.GetComponent<SpriteRenderer>().sprite == ingredientSprite)
        {
            ingredient.GetComponent<Ingredient>().Success();
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(ingredient);

            ingredientList.Add(ingredient);

            ingredient.transform.position = points[ingredientList.IndexOf(ingredient)].position;

            ingredient.transform.localScale = scale;

            GameManager.Instance.CheckLevelUp();
        }
        else
        {
            ingredient.GetComponent<Ingredient>().ReSetPos();
        }
    }
}
