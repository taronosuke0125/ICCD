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
        //TextGenerationSetting�ɂ�Text��RectSize��n��
        var setting = this.textComponent.GetGenerationSettings(new Vector2(this.textComponent.rectTransform.rect.width, this.textComponent.rectTransform.rect.height));
        var generator = this.textComponent.cachedTextGeneratorForLayout;
        while (true)
        {
            //Populate�֐����g���Ĉ�x�]�����s��
            generator.Populate(text, setting);
            if (generator.lineCount > this.lineLimit)
            {
                //�w��̍s����蒷���ꍇ1��������Ď���
                textLength--;
                text = text.Substring(0, textLength) + "...";
            }
            else
            {
                //�w��s���Ɏ��܂����̂�Text�ɕ������ݒ肷��
                this.textComponent.text = text;
                break;
            }
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Test1")]
    void Test1()
    {
        SetText("���킽�����͂��̐l����ɐ搶�ƌĂ�ł����B");
    }

    [ContextMenu("Test2")]
    void Test2()
    {
        SetText("���킽�����͂��̐l����ɐ搶�ƌĂ�ł����B�����炱���ł������搶�Ə��������Ŗ{���͑ł������Ȃ��B");
    }

    [ContextMenu("Test3")]
    void Test3()
    {
        SetText("This section of the documentation contains details of the scripting API that Unity provides. ");
    }
#endif
}
