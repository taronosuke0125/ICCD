using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class CreateDate : MonoBehaviour
{
    //���t�擾�p
    public static DateTime SelectDate;
    private DateTime D_Date;
    private int startday;
    public static DateTime ToDate;
    //�w�肵�������玵���Ԃ�\������֐�
    private void CalenderController(DateTime headdate)
    {   D_Date = headdate;
        for (int i = 0; i < 7; i++)
        {
            if (i == 0)
            {
                Title.GetComponent<SetTitle>().TitleController(headdate);
            }
            //����������
            Transform DAY = GameObject.Find("Dates").transform.GetChild(i);
            DateTime tmp = D_Date;//�ꎟ�ϐ�
            DayOfWeek num = tmp.DayOfWeek;
            //�y�j���E���j����
            switch (num)
            {
                case DayOfWeek.Sunday:
                    DAY.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.red;
                    break;
                case DayOfWeek.Saturday:
                    DAY.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.blue;
                    break;
                default:
                    DAY.GetChild(0).GetChild(0).GetComponent<Text>().color = Color.black;
                    break;

            }
            DAY.GetChild(0).GetChild(0).GetComponent<Text>().text = D_Date.ToString("MM/dd");
            DAY.GetChild(0).GetChild(1).GetComponent<Text>().text = D_Date.ToString("(ddd)");
            GameObject button = GameObject.Find("Dates").transform.GetChild(i).GetChild(0).gameObject;
            DateTime d = D_Date;
            button.GetComponent<Button>().onClick.AddListener(() => { ToDetailScene(d); });
                    D_Date = D_Date.AddDays(1);
        }
        Debug.Log("set Date");
    }
    //WeekChange.cs�ŌĂяo����J�����_�[�𗈏T�ɐi�߂�
    public void ToNextWeekCalender()
    {
        SelectDate = SelectDate.AddDays(7);
        CalenderController(SelectDate);    
    }
    
    //WeekChange.cs�ŌĂяo����J�����_�[���T�ɐi�߂�
    public void ToLastWeekCalender()
    {
        SelectDate = SelectDate.AddDays(-7);
        CalenderController(SelectDate);
    }

    public GameObject canvas;
    public GameObject prefab;
    public GameObject Title;
    RectTransform DatesPos;
    Vector2 DatesPosoff;
    // Start is called before the first frame update
    void Start()
    {
        //�ŏ���savedata��ǂݍ��݃��X�g���쐬����

        //�{�^��7����
        for (int i = 0; i < 7; i++)
        {
            GameObject button = Instantiate(prefab, canvas.transform);
            button.GetComponent<Button>();
        }
        //�X�N���[����ʂ̏����l���L�^
        DatesPos = this.GetComponent<RectTransform>();
        DatesPosoff = DatesPos.anchoredPosition;
        //�ŏ��͍�������ɓ��t���쐬
        SelectDate = DateTime.Now;
        Debug.Log(SelectDate);
        CalenderController(SelectDate);
    }

    void Update()
    {   //��ɃX�N���[����������t��O�ɐi�߂�
        if (DatesPos.anchoredPosition.y> 250)
        {
            this.GetComponent<RectTransform>().anchoredPosition=DatesPosoff;
            SelectDate=SelectDate.AddDays(1);
            CalenderController(SelectDate);
        }
        //���ɃX�N���[����������t��߂�
        if (DatesPos.anchoredPosition.y < -250)
        {
            this.GetComponent<RectTransform>().anchoredPosition = DatesPosoff;
            SelectDate = SelectDate.AddDays(-1);
            CalenderController(SelectDate);
        }
    }
    public void ToDetailScene(DateTime date)
    {
        ToDate = date;
        SceneManager.LoadScene("PlanDetail");
    }
}