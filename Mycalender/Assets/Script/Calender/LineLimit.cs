using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LineLimit:MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] int lineLimit = 2;

    public void SetText(string originalText)
    {
        var text = originalText;
        var textLength = originalText.Length;
        //TextGenerationSettingにはTextのRectSizeを渡す
        var setting = this.textComponent.GetGenerationSettings(new Vector2(this.textComponent.rectTransform.rect.width, this.textComponent.rectTransform.rect.height));
        var generator = this.textComponent.cachedTextGeneratorForLayout;
        while (true)
        {
            //Populate関数を使って一度評価を行う
            generator.Populate(text, setting);
            if (generator.lineCount > this.lineLimit)
            {
                //指定の行数より長い場合1文字削って試す
                textLength--;
                text = text.Substring(0, textLength) + "...";
            }
            else
            {
                //指定行数に収まったのでTextに文字列を設定する
                this.textComponent.text = text;
                break;
            }
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Test1")]
    void Test1()
    {
        SetText("私わたくしはその人を常に先生と呼んでいた。");
    }

    [ContextMenu("Test2")]
    void Test2()
    {
        SetText("私わたくしはその人を常に先生と呼んでいた。だからここでもただ先生と書くだけで本名は打ち明けない。");
    }

    [ContextMenu("Test3")]
    void Test3()
    {
        SetText("This section of the documentation contains details of the scripting API that Unity provides. ");
    }
#endif
}
