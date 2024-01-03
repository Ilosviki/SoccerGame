using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private GameObject fi0, fi1, fi2;
    private GameObject s0, s1, s2, s3, s4, s5, s6, s7, s8, s9;
    private GameObject t0, t1, t2;
    private GameObject f0, f1 , f2, f3, f4, f5, f6, f7, f8, f9;

    public static Score instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        fi0 = GameObject.Find("0_:__");
        fi1 = GameObject.Find("1_:__");
        fi2 = GameObject.Find("2_:__");
        s0 = GameObject.Find("_0:__");
        s1 = GameObject.Find("_1:__");
        s2 = GameObject.Find("_2:__");
        s3 = GameObject.Find("_3:__");
        s4 = GameObject.Find("_4:__");
        s5 = GameObject.Find("_5:__");
        s6 = GameObject.Find("_6:__");
        s7 = GameObject.Find("_7:__");
        s8 = GameObject.Find("_8:__");
        s9 = GameObject.Find("_9:__");
        t0 = GameObject.Find("__:0_");
        t1 = GameObject.Find("__:1_");
        t2 = GameObject.Find("__:2_");
        f0 = GameObject.Find("__:_0");
        f1 = GameObject.Find("__:_1");
        f2 = GameObject.Find("__:_2");
        f3 = GameObject.Find("__:_3");
        f4 = GameObject.Find("__:_4");
        f5 = GameObject.Find("__:_5");
        f6 = GameObject.Find("__:_6");
        f7 = GameObject.Find("__:_7");
        f8 = GameObject.Find("__:_8");
        f9 = GameObject.Find("__:_9");

        ScoreChanging(0, 0);
    }

    public void ScoreChanging(int yours, int agents)
    {
        switch ((int)yours / 10)
        {
            case 1:
                fi0.SetActive(false);
                fi1.SetActive(true);
                break;
            case 2:
                fi1.SetActive(false);
                fi2.SetActive(true);
                break;
            default:
                fi2.SetActive(false);
                fi1.SetActive(false);
                fi0.SetActive(true);
                break;
        }

        switch (yours % 10) {
            case 1:
                s0.SetActive(false);
                s1.SetActive(true);
                break;
            case 2:
                s1.SetActive(false);
                s2.SetActive(true);
                break;
            case 3:
                s2.SetActive(false);
                s3.SetActive(true);
                break;
            case 4:
                s3.SetActive(false);
                s4.SetActive(true);
                break;
            case 5:
                s4.SetActive(false);
                s5.SetActive(true);
                break;
            case 6:
                s5.SetActive(false);
                s6.SetActive(true);
                break;
            case 7:
                s6.SetActive(false);
                s7.SetActive(true);
                break;
            case 8:
                s7.SetActive(false);
                s8.SetActive(true);
                break;
            case 9:
                s8.SetActive(false);
                s9.SetActive(true);
                break;
            default:
                s9.SetActive(false);
                s8.SetActive(false);
                s7.SetActive(false);
                s6.SetActive(false);
                s5.SetActive(false);
                s4.SetActive(false);
                s3.SetActive(false);
                s2.SetActive(false);
                s1.SetActive(false);
                s0.SetActive(true);
                break;
        }

        switch (agents / 10)
        {
            case 1:
                t0.SetActive(false);
                t1.SetActive(true);
                break;
            case 2:
                t1.SetActive(false);
                t2.SetActive(true);
                break;
            default:
                t2.SetActive(false);
                t1.SetActive(false);
                t0.SetActive(true);
                break;
        }
        switch (agents % 10)
        {
            case 1:
                f0.SetActive(false);
                f1.SetActive(true);
                break;
            case 2:
                f1.SetActive(false);
                f2.SetActive(true);
                break;
            case 3:
                f2.SetActive(false);
                f3.SetActive(true);
                break;
            case 4:
                f3.SetActive(false);
                f4.SetActive(true);
                break;
            case 5:
                f4.SetActive(false);
                f5.SetActive(true);
                break;
            case 6:
                f5.SetActive(false);
                f6.SetActive(true);
                break;
            case 7:
                f6.SetActive(false);
                f7.SetActive(true);
                break;
            case 8:
                f7.SetActive(false);
                f8.SetActive(true);
                break;
            case 9:
                f8.SetActive(false);
                f9.SetActive(true);
                break;
            default:
                f9.SetActive(false);
                f8.SetActive(false);
                f7.SetActive(false);
                f6.SetActive(false);
                f5.SetActive(false);
                f4.SetActive(false);
                f3.SetActive(false);
                f2.SetActive(false);
                f1.SetActive(false);
                f0.SetActive(true);
                break;
        }
    }
}
