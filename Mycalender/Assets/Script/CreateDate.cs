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
        Debug.Log(D_Date);
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
            //�{�^���ɂ��̓��t��ۑ�
            button.transform.parent.GetComponent<ButtonDate>().day = D_Date;
            DateTime d = D_Date;
            button.GetComponent<Button>().onClick.AddListener(() => { ToDetailScene(d); });
            D_Date = D_Date.AddDays(1);
        }
        SetPlanName();
    }
    //���X�g�ɕێ�����Ă���\����Y��������t�ɕ\������.
    public void SetPlanName()
    {
        int i;
        Debug.Log("datacount:" + PlanList.datacount);
        //7���Ԃ̗\�菉����(�v���n�u�폜)
        for(i=0; i<7; i++)
        {
            GameObject parent = this.transform.GetChild(i).GetChild(0).GetChild(2).gameObject;
            foreach (Transform child in parent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        for (i=0; i<PlanList.datacount; i++)
        {
            //Debug.Log(i);
            //Debug.Log("Sel:"+SelectDate);
            //Debug.Log("S:" + PlanList.DataList[i].Start);
            //Debug.Log("F:" + PlanList.DataList[i].Finish);
            if (PlanList.DataList[i].Finish <= SelectDate.Date || SelectDate.AddDays(7).Date <= PlanList.DataList[i].Start)
            {//�\�肪�\������Ă���7���Ԃ̊ԂɂȂ���
                Debug.Log("Case1");
                continue;
            }else if (PlanList.DataList[i].Start <= SelectDate.Date)
            {//�\��J�n�����擪�̓��t��00:00�����O
                if(PlanList.DataList[i].Finish <= SelectDate.AddDays(7).Date)
                {//�\��I�������Ō���̓��t+1��00:00�ȑO
                    Debug.Log("Case2");
                    int j = 0;
                    do
                    {
                        GameObject planview = this.transform.GetChild(j).GetChild(0).GetChild(2).gameObject;
                        //�\��̃{�^���쐬
                        GameObject planpanelobj = Instantiate(planpanel, planview.transform);
                        Debug.Log(planpanelobj.name);
                        //�\��̖��O,���Ԃ��L��
                        planpanelobj.transform.GetChild(0).GetComponent<Text>().text = PlanList.DataList[i].Name;

                        if (SelectDate.Date.AddDays(j) == PlanList.DataList[i].Finish.Date)
                        {
                            planpanelobj.transform.GetChild(1).GetComponent<Text>().text = "�`" + PlanList.DataList[i].Finish.ToString("HH:mm");
                            Debug.Log("written");
                        }

                        j++;
                    } while ( SelectDate.Date.AddDays(j) < PlanList.DataList[i].Finish);
                }
                else
                {//�\��I�������Ō������
                    Debug.Log("Case4");
                    int j ;
                    for(j=0 ; j < 7 ; j++)
                    {
                        GameObject planview = this.transform.GetChild(j).GetChild(0).GetChild(2).gameObject;
                        GameObject planpanelobj = Instantiate(planpanel, planview.transform);
                        planpanelobj.transform.GetChild(0).GetComponent<Text>().text = PlanList.DataList[i].Name;
                    }
                }
            }
            else
            {//�\��J�n�����擪�̓��t��00:00�ȍ~
                if (PlanList.DataList[i].Finish <= SelectDate.AddDays(7).Date)
                {//�\��I�������Ō���̓��t�ȑO
                    Debug.Log("Case5");
                    int j = 0;
                    //�\��J�n�����擪�̓��t���牽�Ԗڂ�
                    while(SelectDate.Date.AddDays(j) != PlanList.DataList[i].Start.Date)
                    {
                        j++;
                    }

                    do
                    {
                        GameObject planview = this.transform.GetChild(j).GetChild(0).GetChild(2).gameObject;
                        GameObject planpanelobj = Instantiate(planpanel, planview.transform);
                        planpanelobj.transform.GetChild(0).GetComponent<Text>().text = PlanList.DataList[i].Name;
                        if (SelectDate.Date.AddDays(j) == PlanList.DataList[i].Start.Date)
                        {
                            planpanelobj.transform.GetChild(1).GetComponent<Text>().text =PlanList.DataList[i].Start.ToString("HH:mm")+"�`";
                        }
                        if(SelectDate.Date.AddDays(j) == PlanList.DataList[i].Finish.Date)
                        {
                            planpanelobj.transform.GetChild(1).GetComponent<Text>().text += PlanList.DataList[i].Finish.ToString("HH:mm");
                        }
                        j++;
                    } while (SelectDate.Date.AddDays(j) < PlanList.DataList[i].Finish);
                }
                else
                {//�\��I�������Ō������
                    Debug.Log("Case3");
                    int j = 0;
                    //�\��J�n�����擪�̓��t���牽�Ԗڂ�
                    while (SelectDate.Date.AddDays(j) != PlanList.DataList[i].Start.Date)
                    {
                        j++;
                    }

                    do
                    {
                        GameObject planview = this.transform.GetChild(j).GetChild(0).GetChild(2).gameObject;
                        GameObject planpanelobj = Instantiate(planpanel, planview.transform);
                        planpanelobj.transform.GetChild(0).GetComponent<Text>().text = PlanList.DataList[i].Name;
                        if (SelectDate.Date.AddDays(j) == PlanList.DataList[i].Start.Date)
                        {
                            planpanelobj.transform.GetChild(1).GetComponent<Text>().text = PlanList.DataList[i].Start.ToString("HH:mm") + "�`";
                        }
                        j++;
                    } while (j<7);
                }
            }
        }
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
    public GameObject planpanel;
    public GameObject canvas;
    public GameObject prefab;
    public GameObject Title;
    RectTransform DatesPos;
    Vector2 DatesPosoff;
    // Start is called before the first frame update
    //�\��f�[�^���Ăяo���ꂽ��Ɏ��s�����K�v������
    void Start()
    {
        
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
    //�\��ڍ׃V�[���֑J��
    public void ToDetailScene(DateTime date)
    {
        ToDate = date;
        SceneManager.LoadScene("detail");
    }
}
