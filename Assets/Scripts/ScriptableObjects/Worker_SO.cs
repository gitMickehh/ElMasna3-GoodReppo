using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gender
{
    MALE,
    FEMALE
}

[CreateAssetMenu(fileName = "WorkerStats", menuName = "ElMasna3/Factory/Worker")]
public class Worker_SO : ScriptableObject
{
    
    [Header("Names")]
    public ListOfStrings_SO MaleFirstNames;
    public ListOfStrings_SO FemaleFirstNames;
    public ListOfStrings_SO LastNames;

    [Header("Traits")]
    public List_SO EmotionalTraits;
    public List_SO MedicalState;
    //Favorite day will be an ENUM randomly generated in Worker Component

    [Header("Colors")]
    public List_SO ShirtColorsLinks;

    [Header("Cooldown")]
    public float CooldownTime;
    public float MovementSpeed;

    [Header("Prefabs")]
    public List<GameObject> FacialHairPrefabs;
    public List<GameObject> HairPrefabs;
    public List<GameObject> GlassesPrefabs;

    public string RandomizeName(Gender g)
    {
        int no1 = 0;
        int no2 = Random.Range(0, LastNames.strings.Count);

        string fullName;

        switch (g)
        {
            case Gender.MALE:
                no1 = Random.Range(0, MaleFirstNames.strings.Count);
                fullName = MaleFirstNames.strings[no1] + " " + LastNames.strings[no2];
                break;
            case Gender.FEMALE:
                no1 = Random.Range(0, FemaleFirstNames.strings.Count);
                fullName = FemaleFirstNames.strings[no1] + " " + LastNames.strings[no2];
                break;
            default:
                fullName = "Hamada Hamda";
                break;
        }

        return fullName;

    }

    public EmotionalTrait RandomizeEmotionalTraits()
    {
       int no1 = Random.Range(0, EmotionalTraits.ListElements.Count);

        return (EmotionalTrait)(EmotionalTraits.ListElements)[no1];
    }

    public MedicalTrait RandomizeMedicalTraits()
    {
        int no1 = Random.Range(0, MedicalState.ListElements.Count);

        return (MedicalTrait)(MedicalState.ListElements)[no1];
    }

    public Day GetRandomFavDay()
    {
        int no1 = Random.Range(0, 7);

        return (Day)no1;
    }

    public Gender RandomizeGender()
    {
        int no1 = Random.Range(0, 2);

        return (Gender)no1;
    }
   
    public Color RandomizeColor()
    {
        int r = Random.Range(0,ShirtColorsLinks.ListElements.Count);

        MiniGameLinker_SO s = (MiniGameLinker_SO)ShirtColorsLinks.ListElements[r];
        return s.ShirtColor;
    }

    public MiniGameLinker_SO RandomizeColorLinker()
    {
        int r = Random.Range(0, ShirtColorsLinks.ListElements.Count);

        MiniGameLinker_SO s = (MiniGameLinker_SO)ShirtColorsLinks.ListElements[r];
        return s;
    }

    /*
    public void RandomizeWorkerStats()
    {

    }

    public void RandomizeWorkerLook()
    {

    }
    */

}
