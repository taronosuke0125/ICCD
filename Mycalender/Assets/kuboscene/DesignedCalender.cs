using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DesignedCalendar : MonoBehaviour
{
    public GameObject canvas;  // �G�f�B�^����w��
    public GameObject prefab;  // �G�f�B�^����w��
    public Text displayText;   // �\������e�L�X�g�I�u�W�F�N�g
    public Text monthYearText; // �ǉ�: �N����\������e�L�X�g�I�u�W�F�N�g

    private DateTime SelectDate;
    private DateTime D_Date;
    private int startday;

   // �ǉ�: �ۑ����邽�߂̕ϐ�(makecalender.cs�ł���ChangeDate)
    public static DateTime selectedDate;

    void Start()
    {
        for (int i = 0; i < 42; i++)
        {
            GameObject button = Instantiate(prefab, canvas.transform);
            button.GetComponent<Button>();
        }

        // �ǉ�: �N����\������e�L�X�g�I�u�W�F�N�g�̏����ݒ�
        // ����: �I�u�W�F�N�g���A�^�b�`����Ă��邱�Ƃ��m�F����
        if (monthYearText == null)
        {
            Debug.LogError("monthYearText is not assigned.");
        }
        else
        {
            UpdateMonthYearText();
        }

        SelectDate = DateTime.Now;
        CalendarController();

        // �ǉ�: �����Ɉړ�����{�^���̃N���b�N�C�x���g
        Button nextMonthButton = GameObject.Find("NextMonthButton").GetComponent<Button>();
        nextMonthButton.onClick.AddListener(MoveToNextMonth);

        // �ǉ�: �O���Ɉړ�����{�^���̃N���b�N�C�x���g
        Button prevMonthButton = GameObject.Find("PrevMonthButton").GetComponent<Button>();
        prevMonthButton.onClick.AddListener(MoveToPrevMonth);
    }

    private void CalendarController()
    {
        int days = 1;
        int overday = 1;

        D_Date = new DateTime(SelectDate.Year, SelectDate.Month, 1);  //SelectDate�̌��̍ŏ��̓��t
        int year = SelectDate.Year; //�N
        int month = SelectDate.Month; //��
        int day = SelectDate.Day; //��
        //�ŏ��̓��t�̗j�����擾
        DayOfWeek firstDate = D_Date.DayOfWeek;
        //�����܂ł��邩
        int monthEnd = DateTime.DaysInMonth(year, month);
        //�O���������܂ł��邩
        SelectDate = SelectDate.AddMonths(-1);
        month = SelectDate.Month;
        SelectDate = SelectDate.AddMonths(1);
        int lastmonth = DateTime.DaysInMonth(year, month);
        switch (firstDate)
        {
            case DayOfWeek.Sunday:
                startday = 0;
                break;
            case DayOfWeek.Monday:
                startday = 1;
                break;
            case DayOfWeek.Tuesday:
                startday = 2;
                break;
            case DayOfWeek.Wednesday:
                startday = 3;
                break;
            case DayOfWeek.Thursday:
                startday = 4;
                break;
            case DayOfWeek.Friday:
                startday = 5;
                break;
            case DayOfWeek.Saturday:
                startday = 6;
                break;
        }
        int lastmonthdays = lastmonth - startday + 1;

        for (int i = 0; i < 42; i++)
        {
            if (i >= startday)
            {
                if (days <= monthEnd)
                {
                    // ����������
                    Transform DAY = canvas.transform.GetChild(i);
                    DateTime tmp = D_Date;//�ꎞ�ϐ�
                    DayOfWeek num = tmp.DayOfWeek;
                    //�y�j���E���j����
                    switch (num)
                    {
                        case DayOfWeek.Sunday:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.red;
                            break;
                        case DayOfWeek.Saturday:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.blue;
                            break;
                        default:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.black;
                            break;
                    }
                    DAY.GetChild(0).GetComponent<Text>().text = D_Date.Day.ToString();
                    //�ȉ�3�s�ǉ�
                    GameObject button = canvas.transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    button.GetComponent<Button>().onClick.AddListener(() => { set_Date(tmp); });
                    D_Date = D_Date.AddDays(1);
                    days++;
                }
                else
                {
                    Transform DAY = canvas.transform.GetChild(i);
                    DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                    DAY.GetChild(0).GetComponent<Text>().text = overday.ToString();
                    GameObject button = canvas.transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    overday++;
                }
            }
            else
            {
                Transform DAY = canvas.transform.GetChild(i);
                DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                DAY.GetChild(0).GetComponent<Text>().text = lastmonthdays.ToString();
                GameObject button = canvas.transform.GetChild(i).gameObject;
                button.GetComponent<Button>().onClick.RemoveAllListeners();
                lastmonthdays++;
            }
        }

        // �N����\������e�L�X�g�I�u�W�F�N�g���X�V
        UpdateMonthYearText();
    }

    // �N����\������e�L�X�g���X�V���郁�\�b�h
    void UpdateMonthYearText()
    {
        if (monthYearText != null)
        {
            monthYearText.text = SelectDate.ToString("yyyy/MM");
        }
        else
        {
            Debug.LogError("monthYearText is not assigned.");
        }
    }

    // ���t��ۑ����邽�߂̃��\�b�h
    void set_Date(DateTime date)
    {
        Debug.Log(date);
        selectedDate = date;
        // �e�L�X�g�I�u�W�F�N�g�ɓ��t��\��
        displayText.text = selectedDate.ToString();
        SceneManager.LoadScene("SetPlan");
       
    }

    // �����Ɉړ����郁�\�b�h
    void MoveToNextMonth()
    {
        SelectDate = SelectDate.AddMonths(1);
        CalendarController();
    }

    // �O���Ɉړ����郁�\�b�h
    void MoveToPrevMonth()
    {
        SelectDate = SelectDate.AddMonths(-1);
        CalendarController();
    }
}
