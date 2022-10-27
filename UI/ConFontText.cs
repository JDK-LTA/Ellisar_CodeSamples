using System.Linq;
using TMPro;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ConFontText : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // ReverseText();
            
            TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
            
            // List<char> textArray = text.text.ToCharArray().ToList();
            //
            // string auxNum = "";
            // int initDig = -1;
            // for (var i = textArray.Count - 1; i >= 0; i--)
            // {
            //     var ch = textArray[i];
            //     if (char.IsDigit(ch))
            //     {
            //         if (auxNum.Length == 0)
            //             initDig = i;
            //         auxNum = auxNum.Insert();
            //     }
            //
            //     else if ((char.IsWhiteSpace(ch) || ch == '\n') && auxNum.Length > 0)
            //     {
            //
            //         auxNum = NumberToBaseFour(int.Parse(auxNum));
            //         
            //         int index = 0;
            //
            //         initDig = -1;
            //         auxNum = "";
            //     }
            // }
            //
            // text.text = new string(textArray.ToArray());
            
            
        }

        private void ReverseText()
        {
            TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();

            string[] sepStrings = text.text.Split('\n');

            for (var i = 0; i < sepStrings.Length; i++)
            {
                // List<int> numbers = new List<int>();
                // string aux = "";
                // for (int j = 0; j < sepStrings[i].Length; j++)
                // {
                //     if (Char.IsDigit(sepStrings[i][j]))
                //     {
                //         aux += sepStrings[i][j].ToString();
                //     }
                //     else if (aux.Length > 0 && Char.IsWhiteSpace(sepStrings[i][j]))
                //     {
                //         numbers.Add(int.Parse(aux));
                //         aux = "";
                //     }
                // }
                //
                // if (numbers.Count > 0)
                // {
                //     for (int j = 0; j < numbers.Count; j++)
                //     {
                //         
                //     }
                // }

                    sepStrings[i] = new string(sepStrings[i].Reverse().ToArray());
            }

            string endText = "";

            if (sepStrings.Length > 1)
            {
                for (int i = 0; i < sepStrings.Length - 1; i++)
                {
                    endText += sepStrings[i];
                    endText += "\n";
                }
            }

            endText += sepStrings[sepStrings.Length - 1];
            text.text = endText;
        }

        private string NumberToBaseFour(int num)
        {
            string end = "";

            var numOfFours = num / 4;
            var extra = numOfFours > 0 ? num % 4 : 0;
            var coded = numOfFours > 0 ? 3 + numOfFours : num;

            var text = extra > 0 ? coded.ToString() + extra.ToString() : coded.ToString();
            end = text;
            
            return end;
        }
    }
}
