using UnityEngine;
using MyLibrary;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    private readonly string[] originalKeys = { "ㅂ", "ㅈ", "ㄷ", "ㄱ", "ㅅ", "ㅐ", "ㅔ" };
    private readonly string[] changeKeys = { "ㅃ", "ㅉ", "ㄸ", "ㄲ", "ㅆ", "ㅒ", "ㅖ" };
    private bool shift;

    // Start is called before the first frame update
    void Start()
    {
        shift = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.bGame)
        {
            GameObject[] touchObj = MyTouch.TouchObject();

            for (int i = 0; i < touchObj.Length; i++)
            {
                if (touchObj[i] == gameObject)
                {
                    switch (gameObject.name)
                    {
                        case "Delete":
                            if (Controller.Japan.Count != 0) Controller.Japan.RemoveAt(Controller.Japan.Count - 1);
                            break;
                        case "Shift":
                            shift = !shift;
                            break;
                        case "Space":
                            Controller.Japan.Add(" ");
                            break;
                        case "Complete":
                            Controller.bComplete = true;
                            //GameObject.Find("Result").GetComponent<Text>().text = Hangle.WriteHangle(string.Join("", Controller.Japan.ToArray()));
                            break;
                        default:
                            shift = false;
                            Controller.Japan.Add(gameObject.name);
                            break;
                    }
                    GameObject.Find("Result").GetComponent<Text>().text = Hangle.WriteHangle(string.Join("", Controller.Japan.ToArray()));

                    if (shift && GameObject.Find(originalKeys[0]) != null)
                    {
                        for (int j = 0; j < originalKeys.Length; j++)
                        {
                            GameObject.Find(originalKeys[j]).name = changeKeys[j];
                        }
                    }
                    else if (!shift && GameObject.Find(changeKeys[0]) != null)
                    {
                        for (int j = 0; j < originalKeys.Length; j++)
                        {
                            GameObject.Find(changeKeys[j]).name = originalKeys[j];
                        }
                    }
                }
            }
        }
    }
}
