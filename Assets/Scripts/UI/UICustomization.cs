using UnityEngine;

public class UICustomization : MonoBehaviour
{
    public GameObject CompanionGameObject;

    /// <summary>
    /// Changes the color of the entire body of the companion.
    /// </summary>
    /// <param name="color">Color to apply.</param>
    public void ChangeColor(Color color)
    {
        CompanionGameObject.GetComponent<Renderer>().material.color = color;
    }

    /// <summary>
    /// Applies customization to the gameobject of the companion.
    /// </summary>
    /// <param name="customization">Customization to apply.</param>
    public void ApplyCustomization(DataCustomization customization)
    {
        ChangeColor(customization.Color);
    }
}