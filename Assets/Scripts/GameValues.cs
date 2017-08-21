using UnityEngine;

public class GameValues : MonoBehaviour
{
    private static float loadTime = 3;
    public static float LoadTime{get{return loadTime;}}

    private static float longLoadTime = loadTime * 15;
    public static float LongLoadTime{get{return loadTime;}}

    private static float money;
    public static float Money{get{return money;}}

    public static void setLoadTime(float time)
    {
        loadTime = time;
        longLoadTime = time * 15;
    }

    public static void setMoney(float amount){money = amount;}
}
