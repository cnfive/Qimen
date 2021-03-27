using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Web;

using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.IFormatter;
using System.Runtime.Serialization;

//using System.Runtime.Serialization.Formatters.Soap;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsFormsApp3
{
    [Serializable]
    struct Gong   //宫
    {
        public string shen;
        public string xin;
        public string men;
        public string xin_tiangan;
        public string men_tiangan;
        public string xin2;          //天禽位
        public string xin2_tiangan;  //天禽天干
    };
    [Serializable]
    struct Gua  //卦
    {
        public Gong Kan;
        public Gong Kun;
        public Gong Zhen;
        public Gong Xun;
        public Gong Qian;
        public Gong Dui;
        public Gong Gen;
        public Gong Li;
        public Gong Zhong;
        public DateTime date;
        public string Ganzhi;   //干支
        public string Xunkong;  //旬空
        public string Zhishi;  //值使
        public List<string> Jianghao; //开奖号
        public string Yinyang;//阳遁，阴遁局数
        public string Zhifu;  //直符



    } 

    public partial class Form1 : Form
    {
        int thread_tag = 1;
        Thread readmodel;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
           

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  FileInfo myfile = new FileInfo(@"C:\Users\Administrator\Desktop\caipiao.txt");
            string path = @"C:\Users\Administrator\Desktop\caipiao3.txt";
            // string  txt = File.ReadAllText(@"C:\Users\Administrator\Desktop\caipiao.txt");
            //  textBox1.Text= txt;
            // File.re
            // MessageBox.Show(txt);

            StreamReader sr = new StreamReader(path, Encoding.Default);

            String line = null;
            string txt = null;
            string txt2 = null;
            string[] arraysn = null;

            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "坎");
            dic.Add(2, "坤");
            dic.Add(3, "震");
            dic.Add(4, "巽");
            dic.Add(5, "艮,坤");
            dic.Add(6, "乾");
            dic.Add(7, "兑");
            dic.Add(8, "艮");
            dic.Add(9, "离");
            dic.Add(10, "艮,坤");
            dic.Add(11, "坎");
            dic.Add(12, "离");
            dic.Add(13, "震,巽");
            dic.Add(14, "兑,乾");
            dic.Add(15, "艮,坤");
            dic.Add(16, "坎");
            dic.Add(17, "离");
            dic.Add(18, "震,巽");
            //  dic.Add("17", "坎");
            dic.Add(19, "兑,乾");
            dic.Add(20, "艮,坤");
            dic.Add(21, "坎");
            dic.Add(22, "离");
            dic.Add(23, "震,巽");
            dic.Add(24, "兑,乾");
            dic.Add(25, "艮,坤");
            dic.Add(26, "坎");
            dic.Add(27, "离");
            dic.Add(28, "震, 巽");
            dic.Add(29, "兑,乾");
            dic.Add(30, "艮,坤");
            dic.Add(31, "坎");
            dic.Add(32, "离");
            dic.Add(33, "震,巽");



            while ((line = sr.ReadLine()) != null)
            {
                // if (line.Length > 10)
                txt += line + "\r\n";


                arraysn = line.Split("	");
                int tag_1 = 0;
                int tag_2 = 0;
                int tag_3 = 0;

                //    if (int.Parse(k) < 10)

                // 尾号特征：
                //数字对应的宫位

                //  坎  离  乾  艮  巽  

                //单位数
                //   int tag_1 = 0;


                string MessageTxt = "时间：" + arraysn[15] + "双色球前6号:" + " " + arraysn[1] + " " + arraysn[2] + " " + arraysn[3] + " " + arraysn[4] + " " + arraysn[5] + " " + arraysn[6] + "尾号：" + arraysn[7] + "\r\n" + "命中数：" + arraysn[10];
                int one = int.Parse(arraysn[1]);
                //  int  two=
                MessageTxt += "\r\n" + "红球宫位：" + dic[int.Parse(arraysn[1])] + "   " + dic[int.Parse(arraysn[2])] + "   " + dic[int.Parse(arraysn[3])] + "   " + dic[int.Parse(arraysn[4])] + "   " + dic[int.Parse(arraysn[5])] + "   " + dic[int.Parse(arraysn[6])] + "   ";

                MessageTxt += "\r\n" + "蓝球宫位：" + dic[int.Parse(arraysn[7])] + "   ";
                MessageBox.Show(MessageTxt);
            }
            //MessageBox.Show(txt);
            textBox_gua.Text = txt2;
            MessageBox.Show("运行结束！");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        } 
        private Gua  readPlan(string  year_d,string month_d,string day_d, string[] Jianghao){
            Gong xun, li, kun, zhen,dui,gen,kan,qian,zhong;
            
            //巽
            xun.men = "";
            xun.xin = "";
            xun.xin_tiangan = "";
            xun.men_tiangan = "";
            xun.shen = "";
            xun.xin2 = "";
            xun.xin2_tiangan = "";
            //离
            li.men = "";
            li.xin = "";
            li.xin_tiangan = "";
            li.men_tiangan = "";
            li.shen = "";

            li.xin2 = "";
            li.xin2_tiangan = "";


            //坤
            kun.men = "";
            kun.xin = "";
            kun.xin_tiangan = "";
            kun.men_tiangan = "";
            kun.shen = "";


            kun.xin2 = "";
            kun.xin2_tiangan = "";



            //震
            zhen.men = "";
            zhen.xin = "";
            zhen.xin_tiangan = "";
            zhen.men_tiangan = "";
            zhen.shen = "";

            zhen.xin2 = "";
            zhen.xin2_tiangan = "";

            //兑
            dui.men = "";
            dui.xin = "";
            dui.xin_tiangan = "";
            dui.men_tiangan = "";
            dui.shen = "";

            dui.xin2 = "";
            dui.xin2_tiangan = "";

            //艮
            gen.men = "";
            gen.xin = "";
            gen.xin_tiangan = "";
            gen.men_tiangan = "";
            gen.shen = "";

            gen.xin2 = "";
            gen.xin2_tiangan = "";

            //坎
            kan.men = "";
            kan.xin = "";
            kan.xin_tiangan = "";
            kan.men_tiangan = "";
            kan.shen = "";

            kan.xin2 = "";
            kan.xin2_tiangan = "";

            //乾
            qian.men = "";
            qian.xin = "";
            qian.xin_tiangan = "";
            qian.men_tiangan = "";
            qian.shen = "";

            qian.xin2 = "";
            qian.xin2_tiangan = "";

            //中宫
            zhong.men = "";
            zhong.shen = "";
            zhong.men_tiangan = "";
            zhong.xin = "";
            zhong.xin_tiangan = "";   //中宫天盘干
            zhong.xin2 = "";
            zhong.xin2_tiangan = "";



            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string url = "http://localhost/paipan/pp_qmdj.asp";

            string url2 = "https://www.china95.net/paipan/qimen/qimen.asp";
            string url3 = "http://localhost/h.htm";
            HttpClient client = new HttpClient(url2);

            string year = year_d;
            string month = month_d;
            string day = day_d;
            string hour = "21";
            string min = "15";
            client.PostingData.Add("y", year);
            client.PostingData.Add("m", month);
            client.PostingData.Add("d", day); 
            client.PostingData.Add("h", hour);
            client.PostingData.Add("min", min); 
            client.PostingData.Add("mod", "1"); 
            client.PostingData.Add("PPfangshi", "1");
            client.PostingData.Add("PPfanghua", "1"); 

            string html = client.GetString();

            
          //  textBox1.Text = html;
            Encoding ecode2 = Encoding.GetEncoding("iso-8859-1");
            Encoding ecode = Encoding.GetEncoding("gb2312");

            Byte[] html2 = ecode.GetBytes(html);

            html =ecode.GetString(html2);

           // MessageBox.Show(html);

            html = html.Replace("<font color=red>", "");
            html = html.Replace("<font color=blue>", "");
            html = html.Replace("<font color=green>", "");
            html = html.Replace("</font>", "");


            string[] strArray = html.Split(new string[] { "方式", "└──────┴──────┴──────┘" }, StringSplitOptions.RemoveEmptyEntries);
            string[] strArray2 = html.Split(new string[] { "┌──────┬──────┬──────┐", "└──────┴──────┴──────┘" }, StringSplitOptions.RemoveEmptyEntries);
            string[] strArray_3 = html.Split(new string[] { "干支：", "旬空：" }, StringSplitOptions.RemoveEmptyEntries);
            string[] strArray_4 = html.Split(new string[] { "旬空：", "立冬：" }, StringSplitOptions.RemoveEmptyEntries);
            string[] strArray_5 = html.Split(new string[] { "值使：", "宫" }, StringSplitOptions.RemoveEmptyEntries);
            //  textBox1.Text = strArray2[1];
            //    MessageBox.Show(strArray_3[1]);
            //     MessageBox.Show(strArray_4[1]);
            //     MessageBox.Show(strArray_5[2]);
            string yinyangdun = html.Substring(html.IndexOf("┌──────┬──────┬──────┐") - 24, 4);
            string xunkong = html.Substring(html.IndexOf("旬空：")+3+4, 11);
            string zhifu = html.Substring(html.IndexOf("值使")-6, 2);

           // MessageBox.Show(zhifu);


            string[] strArray_br = strArray2[1].Split("<br>");
          //  textBox1.Text = strArray_br[1];
           
            string sprite = "";
            string[,] sprite_arrary = new string[3, 3];
            //  int bagua_num = 0;

            int char_index = 2, length = 2;  //移除字符串的位置 i,长度length
          //  str = str.remove(i, length);
            for (int i=1;i<4;i++)
            {
                string[] strArray3=strArray_br[i].Split("│");
              //  sprite += strArray3[1] + " " + strArray3[2] + " " + strArray3[3];
                if( i == 1)
                { 
                xun.shen = strArray3[1].Trim();
                li.shen = strArray3[2].Trim();

                kun.shen= strArray3[3].Trim();
                }

                if (i==2)
                {
                   string men_s = strArray3[1].Trim();

                   if (men_s.Length==4)
                    {
                       xun.men= men_s.Remove(char_index,length);
                       xun.men_tiangan = men_s.Substring(char_index + 1, 1);

                    }
                   else
                    {

                        xun.men = men_s.Substring(2, 2);

                        xun.men_tiangan = men_s.Substring(5, 1);

                        xun.xin2_tiangan= men_s.Substring(0, 1);

                    }
                    men_s = strArray3[2].Trim();

                    if (men_s.Length == 4)
                    {
                        li.men = men_s.Remove(char_index, length); 
                        li.men_tiangan = men_s.Substring(char_index + 1, 1);
                    }
                    else
                    {
                        li.men = men_s.Substring(2, 2);
                        li.men_tiangan = men_s.Substring(5, 1);
                        li.xin2_tiangan = men_s.Substring(0, 1);
                    }
                    men_s = strArray3[3].Trim();
                    if(men_s.Length == 4)
                    { 
                    kun.men= men_s.Remove(char_index, length);

                    kun.men_tiangan = men_s.Substring(char_index + 1, 1);
                    }
                    else
                    {
                        kun.men = men_s.Substring(2, 2);

                        kun.men_tiangan = men_s.Substring(5, 1);

                        kun.xin2_tiangan = men_s.Substring(0, 1);
                    }

                }
                if(i==3)
                {

                 //   xun.xin = strArray3[1];
                 //   li.xin = strArray3[2];
                //    kun.xin = strArray3[3];


                    string men_s = strArray3[1].Trim();

                    if (men_s.Length == 4)
                    {
                        xun.xin = men_s.Remove(char_index, length);
                        xun.xin_tiangan = men_s.Substring(char_index + 1, 1);

                    }
                    else
                    {

                        xun.xin = men_s.Substring(2, 2);

                        xun.xin_tiangan = men_s.Substring(5, 1);

                        xun.xin2 = "天禽";

                    }
                    men_s = strArray3[2].Trim();

                    if (men_s.Length == 4)
                    {
                        li.xin = men_s.Remove(char_index, length);
                        li.xin_tiangan= men_s.Substring(char_index + 1, 1);
                    }
                    else
                    {
                        li.xin = men_s.Substring(2, 2);
                        li.xin_tiangan = men_s.Substring(5, 1);
                        li.xin2 = "天禽";

                    }
                    men_s = strArray3[3].Trim();
                    if (men_s.Length == 4)
                    {
                        kun.xin = men_s.Remove(char_index, length);

                        kun.xin_tiangan= men_s.Substring(char_index + 1, 1);
                    }
                    else
                    {
                        kun.xin= men_s.Substring(2, 2);

                        kun.xin_tiangan = men_s.Substring(5, 1);
                        kun.xin2 = "天禽";
                    }


                }
                //sprite_arrary[0,0] = strArray3[1];
            }

            for (int i = 5; i < 8; i++)
            {
                string[] strArray3 = strArray_br[i].Split("│");
                sprite += strArray3[1] + " " + strArray3[2] + " " + strArray3[3];
              //  sprite_arrary[0, 0] = strArray3[1];


                if(i==5)
                {

                    
                        zhen.shen = strArray3[1].Trim();
                      //  li.shen = strArray3[2].Trim();

                        dui.shen = strArray3[3].Trim();
                    
                

                }
                if (i == 6)
                {
                    string men_s = strArray3[1].Trim();

                    if (men_s.Length == 4)
                    {
                        zhen.men = men_s.Remove(char_index, length);
                        zhen.men_tiangan = men_s.Substring(char_index + 1, 1);

                    }
                    else
                    {

                        zhen.men = men_s.Substring(2, 2);

                        zhen.men_tiangan = men_s.Substring(5, 1);
                        zhen.xin2_tiangan= men_s.Substring(0, 1);

                    }
                  //  men_s = strArray3[2].Trim();

                 //   if (men_s.Length == 4)
                //    {
                //        li.men = men_s.Remove(char_index, length);
                //        li.men_tiangan = men_s.Substring(char_index + 1, 1);
               //     }
                //    else
               //     {
                //        li.men = men_s.Substring(2, 2);
                //        li.men_tiangan = men_s.Substring(5, 1);

                 //   }
                    men_s = strArray3[3].Trim();
                    if (men_s.Length == 4)
                    {
                        dui.men = men_s.Remove(char_index, length);

                        dui.men_tiangan = men_s.Substring(char_index + 1, 1);
                    }
                    else
                    {
                        dui.men = men_s.Substring(2, 2);

                        dui.men_tiangan = men_s.Substring(5, 1);
                        dui.xin2_tiangan= men_s.Substring(0, 1);
                    }

                }


                if (i == 7)
                {
                    string men_s = strArray3[1].Trim();

                    if (men_s.Length == 4)
                    {
                        zhen.xin = men_s.Remove(char_index, length);
                        zhen.xin_tiangan = men_s.Substring(char_index + 1, 1);

                    }
                    else
                    {

                        zhen.xin = men_s.Substring(2, 2);

                        zhen.xin_tiangan = men_s.Substring(5, 1);
                        zhen.xin2 = "天禽";

                    }
                    men_s = strArray3[2].Trim();

                    zhong.xin_tiangan = men_s;  //中宫天盘干

                    men_s = strArray3[3].Trim();
                    if (men_s.Length == 4)
                    {
                        dui.xin= men_s.Remove(char_index, length);

                        dui.xin_tiangan = men_s.Substring(char_index + 1, 1);
                    }
                    else
                    {
                        dui.xin= men_s.Substring(2, 2);

                        dui.xin_tiangan = men_s.Substring(5, 1);
                        dui.xin2 = "天禽";
                    }

                }
            }
            for (int i = 9; i < 12; i++)
            {
                string[] strArray3 = strArray_br[i].Split("│");
                //  sprite += strArray3[1] + " " + strArray3[2] + " " + strArray3[3];
                if (i == 9)
                {
                    gen.shen = strArray3[1].Trim();
                    kan.shen = strArray3[2].Trim();

                    qian.shen = strArray3[3].Trim();
                }

                if (i == 10)
                {
                    string men_s = strArray3[1].Trim();

                    if (men_s.Length == 4)
                    {
                        gen.men = men_s.Remove(char_index, length);
                        gen.men_tiangan = men_s.Substring(char_index + 1, 1);

                    }
                    else
                    {

                        gen.men = men_s.Substring(2, 2);

                        gen.men_tiangan = men_s.Substring(5, 1);
                        gen.xin2_tiangan= men_s.Substring(0, 1);

                    }
                    men_s = strArray3[2].Trim();

                    if (men_s.Length == 4)
                    {
                        kan.men = men_s.Remove(char_index, length);
                        kan.men_tiangan = men_s.Substring(char_index + 1, 1);
                    }
                    else
                    {
                        kan.men = men_s.Substring(2, 2);
                        kan.men_tiangan = men_s.Substring(5, 1);
                        kan.xin2_tiangan= men_s.Substring(0, 1);

                    }
                    men_s = strArray3[3].Trim();
                    if (men_s.Length == 4)
                    {
                        qian.men = men_s.Remove(char_index, length);

                        qian.men_tiangan = men_s.Substring(char_index + 1, 1);
                    }
                    else
                    {
                        qian.men = men_s.Substring(2, 2);

                        qian.men_tiangan = men_s.Substring(5, 1);
                        qian.xin2_tiangan= men_s.Substring(0, 1);
                    }

                }
                if (i == 11)
                {

                    //   xun.xin = strArray3[1];
                    //   li.xin = strArray3[2];
                    //    kun.xin = strArray3[3];


                    string men_s = strArray3[1].Trim();

                    if (men_s.Length == 4)
                    {
                        gen.xin = men_s.Remove(char_index, length);
                        gen.xin_tiangan = men_s.Substring(char_index + 1, 1);

                    }
                    else
                    {

                        gen.xin = men_s.Substring(2, 2);

                        gen.xin_tiangan = men_s.Substring(5, 1);
                        gen.xin2 = "天禽";

                    }
                    men_s = strArray3[2].Trim();

                    if (men_s.Length == 4)
                    {
                        kan.xin = men_s.Remove(char_index, length);
                        kan.xin_tiangan = men_s.Substring(char_index + 1, 1);
                    }
                    else
                    {
                        kan.xin = men_s.Substring(2, 2);
                        kan.xin_tiangan = men_s.Substring(5, 1);
                        kan.xin2 = "天禽";

                    }
                    men_s = strArray3[3].Trim();
                    if (men_s.Length == 4)
                    {
                        qian.xin = men_s.Remove(char_index, length);

                        qian.xin_tiangan = men_s.Substring(char_index + 1, 1);
                    }
                    else
                    {
                        qian.xin = men_s.Substring(2, 2);

                        qian.xin_tiangan = men_s.Substring(5, 1);
                        qian.xin2 = "天禽";
                    }


                }
            }


            Gua gua = new Gua();
            gua.Kan = kan;
            gua.Li = li;
            gua.Qian = qian;
            gua.Kun = kun;
            gua.Xun = xun;
            gua.Zhen = zhen;
            gua.Dui = dui;
            gua.Gen = gen;
            gua.Zhong = zhong;
            gua.date = new DateTime(int.Parse(year_d), int.Parse(month_d), int.Parse(day_d), 21, 15, 0);
            gua.Ganzhi = strArray_3[1].Replace("<br>","").Replace("<b>","").Replace("</b>", "");
            gua.Xunkong = xunkong;
            gua.Zhishi = strArray_5[2].Substring(3,2);
            List<string> KaiJiangHao=new List<string>();
            KaiJiangHao.Add(int.Parse(Jianghao[1]).ToString());
            KaiJiangHao.Add(int.Parse(Jianghao[2]).ToString());
            KaiJiangHao.Add(int.Parse(Jianghao[3]).ToString());
            KaiJiangHao.Add(int.Parse(Jianghao[4]).ToString());
            KaiJiangHao.Add(int.Parse(Jianghao[5]).ToString());
            KaiJiangHao.Add(int.Parse(Jianghao[6]).ToString());
            KaiJiangHao.Add(int.Parse(Jianghao[7]).ToString());

            gua.Jianghao =KaiJiangHao;
            gua.Yinyang = yinyangdun;
            gua.Zhifu = zhifu;
           // MessageBox.Show(gua.Jianghao[0]);
           // MessageBox.Show(gua.Jianghao[2]);
            //  MessageBox.Show(gua.Zhishi);
            // MessageBox.Show(gua.Ganzhi);
            //  MessageBox.Show(gua.Xunkong);

            // textBox1.Text =zhong.xin_tiangan+"  "+kan.xin+"  "+kan.shen+"   "+kun.xin2_tiangan+"   "+kun.xin2;
            //  textBox1.Text = sprite;  += "\r\n" 
            // MessageBox.Show(gua.Xun.shen.ToString());
            textBox_gua.Text = gua.Xun.shen.ToString() + "     " + gua.Li.shen.ToString() + "     " + gua.Kun.shen.ToString();
            textBox_gua.Text += "\r\n" + gua.Xun.men + "  " + gua.Xun.men_tiangan + "  " + gua.Li.men + "  " + gua.Li.men_tiangan + "     " + gua.Kun.men + "   " + gua.Kun.men_tiangan;
            textBox_gua.Text += "\r\n" + gua.Xun.xin + "   " + gua.Xun.xin_tiangan + "   " + gua.Li.xin + "   " + gua.Li.xin_tiangan + "   " + gua.Kun.xin + "   " + gua.Kun.xin_tiangan;

            textBox_ganzhi.Text = strArray_3[1].Replace("<br>", "").Replace("<b>", "").Replace("</b>", "");
            textBox_xunkong.Text=xunkong;
            textBox_yinyang.Text = yinyangdun;


            return gua;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("主要计算直符所在宫位占开奖号的比例和组合情况");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Thread create = new Thread(create_model);
            create.Start();
        }
        private void create_model()
        {
            List<Gua> ListGua = new List<Gua>();

            string path = @"C:\Users\Administrator\Desktop\caipiao_3.txt";
            // string  txt = File.ReadAllText(@"C:\Users\Administrator\Desktop\caipiao.txt");
            //  textBox1.Text= txt;
            // File.re
            // MessageBox.Show(txt);

            StreamReader sr = new StreamReader(path, Encoding.Default);

            String line = null;
            string txt = null;
            string txt2 = null;
            string[] arraysn = null;

            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "坎,乾");
            dic.Add(2, "坤,兑");
            dic.Add(3, "震,巽,离");
            dic.Add(4, "巽,震,兑,乾");
            dic.Add(5, "巽,艮,坤,中");
            dic.Add(6, "乾,坎");
            dic.Add(7, "兑,离");
            dic.Add(8, "艮,坤,震,巽");
            dic.Add(9, "离,兑,乾");
            dic.Add(10, "艮,坤");
            dic.Add(11, "坎");
            dic.Add(12, "离");
            dic.Add(13, "震,巽");
            dic.Add(14, "兑,乾");
            dic.Add(15, "艮,坤");
            dic.Add(16, "坎");
            dic.Add(17, "离");
            dic.Add(18, "震,巽");
            //  dic.Add("17", "坎");
            dic.Add(19, "兑,乾");
            dic.Add(20, "艮,坤");
            dic.Add(21, "坎");
            dic.Add(22, "离");
            dic.Add(23, "震,巽");
            dic.Add(24, "兑,乾");
            dic.Add(25, "艮,坤");
            dic.Add(26, "坎");
            dic.Add(27, "离");
            dic.Add(28, "震, 巽");
            dic.Add(29, "兑,乾");
            dic.Add(30, "艮,坤");
            dic.Add(31, "坎");
            dic.Add(32, "离");
            dic.Add(33, "震,巽");



            while ((line = sr.ReadLine()) != null)
            {
                Random rand = new Random();
                var num = rand.Next(4000, 6000);
               
                // if (line.Length > 10)
                txt += line + "\r\n";


                arraysn = line.Split("	");
               // int tag_1 = 0;
              //  int tag_2 = 0;
              //  int tag_3 = 0;

                //    if (int.Parse(k) < 10)

                // 尾号特征：
                //数字对应的宫位

                //  坎  离  乾  艮  巽  

                //单位数
                //   int tag_1 = 0;


                string MessageTxt = "时间：" + arraysn[15] + "双色球前6号:" + " " + arraysn[1] + " " + arraysn[2] + " " + arraysn[3] + " " + arraysn[4] + " " + arraysn[5] + " " + arraysn[6] + "尾号：" + arraysn[7] + "\r\n" + "命中数：" + arraysn[10];
                int one = int.Parse(arraysn[1]);
                //  int  two=
                MessageTxt += "\r\n" + "红球宫位：" + dic[int.Parse(arraysn[1])] + "   " + dic[int.Parse(arraysn[2])] + "   " + dic[int.Parse(arraysn[3])] + "   " + dic[int.Parse(arraysn[4])] + "   " + dic[int.Parse(arraysn[5])] + "   " + dic[int.Parse(arraysn[6])] + "   ";

                MessageTxt += "\r\n" + "蓝球宫位：" + dic[int.Parse(arraysn[7])] + "   ";

                textBox_shijian.Text = arraysn[15];//显示起局时间点
                textBox_kaijianghao.Text = arraysn[1] + " " + arraysn[2] + " " + arraysn[3] + " " + arraysn[4] + " " + arraysn[5] + " " + arraysn[6] + "  " + arraysn[7];





                //开奖日期

                string date = arraysn[15];
                string[] sArray=date.Split("-");
           //     MessageTxt += "\r\n" + sArray[0] + "   " + sArray[1] + "   " + sArray[2];  //年，月，日

                Gua QimenGua=readPlan(sArray[0].Trim(), sArray[1].Trim(),sArray[2].Trim(), arraysn);

                ListGua.Add(QimenGua);
                Thread.Sleep(num);
                //  WriteListToTextFile(ListGua,@"c:\test.txt");
                //     MessageBox.Show(MessageTxt);
                // MessageBox.Show(ListGua[0].Jianghao[0]);
            }
            //MessageBox.Show(txt);
         //   textBox1.Text = txt2;
            MessageBox.Show("运行结束！");
            foreach(Gua Qimengua in ListGua)
            {
               // MessageBox.Show("1");


            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"c:\Qimen_zhirun_3.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
           // MyObj myObj = new MyObj();
            //To Do: 在这里对myObj的属性进行设置
            formatter.Serialize(stream, ListGua);
            stream.Close();


        }
        //将List转换为TXT文件



        //读取文本文件转换为List 
        public List<string> ReadTextFileToList(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            List<string> list = new List<string>();
            StreamReader sr = new StreamReader(fs);
            //使用StreamReader类来读取文件 
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            // 从数据流中读取每一行，直到文件的最后一行
            string tmp = sr.ReadLine();
            while (tmp != null)
            {
                list.Add(tmp);
                tmp = sr.ReadLine();
            }
            //关闭此StreamReader对象 
            sr.Close();
            fs.Close();
            return list;
        }
    
    private void Form1_Load(object sender, EventArgs e)
        {
           readmodel = new Thread(read_model);
        }

        private void button_read_Click(object sender, EventArgs e)
        {   
            //thread_tag = 0;
            if( thread_tag==1)
             { 
               
                readmodel.Start();
                thread_tag = 2;
            }
         //   readmodel.Start();
            if(thread_tag == 2)
            {
              //  readmodel.Suspend();
                thread_tag = 3;
            }
            if(thread_tag == 3)
            {
              //  readmodel.Resume();
                thread_tag = 2;
            }
        }
        //遍历宫的函数
        private void  gong_check(Gua Qimengua,Dictionary<int, string> dic2, Dictionary<int, string> feature,string yinyang, string ganzhi,string  zhifu)
        {
            //string feature;
           string  gz=ganzhi.Substring(4,1);
            gz = gz + zhifu;
           foreach(KeyValuePair<int, string> dic in dic2)
            {
                // dic.key
                string Gongs = dic.Value;
                string[] g=Gongs.Split(",");
                foreach (string s in g)
                {
                   // MessageBox.Show(s);
                  //  Qimengua.s
                    switch(s)
                    {
                       case "Xun":
                            feature[dic.Key]+=gz+yinyang+"Xun"+Qimengua.Xun.shen+Qimengua.Xun.men+Qimengua.Xun.xin+Qimengua.Xun.men_tiangan+Qimengua.Xun.xin_tiangan+Qimengua.Xun.xin2+Qimengua.Xun.xin2_tiangan+";";
                            break;
                       case "Zhen":
                            feature[dic.Key]+= gz + yinyang +"Zhen" + Qimengua.Zhen.shen + Qimengua.Zhen.men+ Qimengua.Zhen.xin+ Qimengua.Zhen.men_tiangan + Qimengua.Zhen.xin_tiangan + Qimengua.Zhen.xin2+Qimengua.Zhen.xin2_tiangan+";";
                            break;
                       case "Gen": 
                            feature[dic.Key] += gz +yinyang + "Gen" + Qimengua.Gen.shen + Qimengua.Gen.men + Qimengua.Gen.xin  + Qimengua.Gen.men_tiangan + Qimengua.Gen.xin_tiangan + Qimengua.Gen.xin2 + Qimengua.Gen.xin2_tiangan+ ";";
                            break;
                       case "Kan": 
                            feature[dic.Key] += gz + yinyang + "Kan" +Qimengua.Kan.shen  + Qimengua.Kan.men + Qimengua.Kan.xin  + Qimengua.Kan.men_tiangan + Qimengua.Kan.xin_tiangan + Qimengua.Kan.xin2 + Qimengua.Kan.xin2_tiangan+ ";";
                            break;
                       case "Qian": 
                            feature[dic.Key] += gz + yinyang + "Qian" + Qimengua.Qian.shen  + Qimengua.Qian.men + Qimengua.Qian.xin  + Qimengua.Qian.men_tiangan  + Qimengua.Qian.xin_tiangan + Qimengua.Qian.xin2 + Qimengua.Qian.xin2_tiangan+ ";";
                            break;
                       case "Dui": 
                            feature[dic.Key] += gz + yinyang + "Dui" + Qimengua.Dui.shen + Qimengua.Dui.men + Qimengua.Dui.xin+ Qimengua.Dui.men_tiangan+ Qimengua.Dui.xin_tiangan + Qimengua.Dui.xin2 + Qimengua.Dui.xin2_tiangan+ ";";
                            break;
                        case "Kun":
                            feature[dic.Key] += gz + yinyang + "Kun" + Qimengua.Kun.shen  + Qimengua.Kun.men + Qimengua.Kun.xin+ Qimengua.Kun.men_tiangan + Qimengua.Kun.xin_tiangan + Qimengua.Kun.xin2 + Qimengua.Kun.xin2_tiangan+ ";";
                            break;
                        case "Li": 
                            feature[dic.Key] += gz + yinyang + "Li" + Qimengua.Li.shen + Qimengua.Li.men  + Qimengua.Li.xin + Qimengua.Li.men_tiangan + Qimengua.Li.xin_tiangan + Qimengua.Li.xin2 + Qimengua.Li.xin2_tiangan+ ";";
                            break;

                        default:
                            break; 
                    }
                }
            }



        }
        private void gong_check2(Gua Qimengua, Dictionary<int, string> preidct_dic, Dictionary<int, string> feature, string yinyang, string ganzhi,string zhifu)
        {
            string gz = ganzhi.Substring(4, 1);
            gz = gz + zhifu;
            //string feature;
            Dictionary<string, string> feature_p = new Dictionary<string, string>();
           // foreach (KeyValuePair<int, string> dic in dic2)
            {
                // dic.key
                string Gongs = "Xun,Zhen,Gen,Kan,Qian,Dui,Kun,Li";
                string[] g = Gongs.Split(",");
                foreach (string s in g)
                {
                    // MessageBox.Show(s);
                    //  Qimengua.s
                    switch (s)
                    {
                        case "Xun":
                            feature_p["Xun"] = gz+yinyang + "Xun" + Qimengua.Xun.shen + Qimengua.Xun.men + Qimengua.Xun.xin + Qimengua.Xun.men_tiangan + Qimengua.Xun.xin_tiangan + Qimengua.Xun.xin2 + Qimengua.Xun.xin2_tiangan ;
                            break;
                        case "Zhen":
                            feature_p["Zhen"] = gz + yinyang + "Zhen" + Qimengua.Zhen.shen + Qimengua.Zhen.men + Qimengua.Zhen.xin + Qimengua.Zhen.men_tiangan + Qimengua.Zhen.xin_tiangan + Qimengua.Zhen.xin2 + Qimengua.Zhen.xin2_tiangan ;
                            break;
                        case "Gen":
                            feature_p["Gen"] = gz + yinyang + "Gen" + Qimengua.Gen.shen + Qimengua.Gen.men + Qimengua.Gen.xin + Qimengua.Gen.men_tiangan + Qimengua.Gen.xin_tiangan + Qimengua.Gen.xin2 + Qimengua.Gen.xin2_tiangan ;
                            break;
                        case "Kan":
                            feature_p["Kan"] = gz + yinyang + "Kan" + Qimengua.Kan.shen + Qimengua.Kan.men + Qimengua.Kan.xin + Qimengua.Kan.men_tiangan + Qimengua.Kan.xin_tiangan + Qimengua.Kan.xin2 + Qimengua.Kan.xin2_tiangan ;
                            break;
                        case "Qian":
                            feature_p["Qian"] = gz + yinyang + "Qian" + Qimengua.Qian.shen + Qimengua.Qian.men + Qimengua.Qian.xin + Qimengua.Qian.men_tiangan + Qimengua.Qian.xin_tiangan + Qimengua.Qian.xin2 + Qimengua.Qian.xin2_tiangan;
                            break;
                        case "Dui":
                            feature_p["Dui"] = gz + yinyang + "Dui" + Qimengua.Dui.shen + Qimengua.Dui.men + Qimengua.Dui.xin + Qimengua.Dui.men_tiangan + Qimengua.Dui.xin_tiangan + Qimengua.Dui.xin2 + Qimengua.Dui.xin2_tiangan ;
                            break;
                        case "Kun":
                            feature_p["Kun"] = gz + yinyang + "Kun" + Qimengua.Kun.shen + Qimengua.Kun.men + Qimengua.Kun.xin + Qimengua.Kun.men_tiangan + Qimengua.Kun.xin_tiangan + Qimengua.Kun.xin2 + Qimengua.Kun.xin2_tiangan;
                            break;
                        case "Li":
                            feature_p["Li"] = gz + yinyang + "Li" + Qimengua.Li.shen + Qimengua.Li.men + Qimengua.Li.xin + Qimengua.Li.men_tiangan + Qimengua.Li.xin_tiangan + Qimengua.Li.xin2 + Qimengua.Li.xin2_tiangan ;
                            break;

                        default:
                            break;
                    }
                }
                foreach(KeyValuePair<int, string> f in preidct_dic)
                {
                    string[] f_a=f.Value.Split(";");
                    foreach(string af in f_a)
                        foreach (KeyValuePair<string, string> p in feature_p)
                           if (af.IndexOf(p.Value) > -1)
                                 MessageBox.Show("预测号："+f.Key.ToString()+" 匹配值："+af+ "  查询值："+p.Value);

                }
            }



        }
        private void read_model_build()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "Kan,Qian");
            dic.Add(2, "Kun,Dui");
            dic.Add(3, "Zhen,Xun,Li");
            dic.Add(4, "Xun,Zhen,Dui,Qian");
            dic.Add(5, "Xun,Gen,Kun,Zhong");
            dic.Add(6, "Xun,Kan");
            dic.Add(7, "Dui,Li");
            dic.Add(8, "Gen,Kun,Zhen,Xun");
            dic.Add(9, "Li,Dui,Qian");
            dic.Add(10, "Gen,Kun");
            dic.Add(11, "Kan");
            dic.Add(12, "Li");
            dic.Add(13, "Zhen,Xun");
            dic.Add(14, "Dui,Qian");
            dic.Add(15, "Gen,Kun");
            dic.Add(16, "Kan");
            dic.Add(17, "Li");
            dic.Add(18, "Zhen,Xun");
            //  dic.Add("17", "坎");
            dic.Add(19, "Dui,Qian");
            dic.Add(20, "Gen,Kun");
            dic.Add(21, "Kan");
            dic.Add(22, "Li");
            dic.Add(23, "Zhen,Xun");
            dic.Add(24, "Dui,Qian");
            dic.Add(25, "Gen,Kun");
            dic.Add(26, "Kan");
            dic.Add(27, "Li");
            dic.Add(28, "Zhen, Xun");
            dic.Add(29, "Dui,Qian");
            dic.Add(30, "Gen,Kun");
            dic.Add(31, "Kan");
            dic.Add(32, "Li");
            dic.Add(33, "Zhen,Xun");

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"c:\Qimen_zhirun_1.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            // MyObj myObj = new MyObj();
            //To Do: 在这里对myObj的属性进行设置
            //    formatter.Serialize(stream, ListGua);
            //    stream.Close();

            List<Gua> ListGua = new List<Gua>();

            ListGua = (List<Gua>)formatter.Deserialize(stream);
            stream.Close();

            Stream stream2 = new FileStream(@"c:\Qimen_zhirun_3.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            // MyObj myObj = new MyObj();
            //To Do: 在这里对myObj的属性进行设置
            //    formatter.Serialize(stream, ListGua);
            //    stream.Close();

            List<Gua> ListGua2 = new List<Gua>();

            ListGua2 = (List<Gua>)formatter.Deserialize(stream2);
            stream2.Close();


            Dictionary<int, string> feature = new Dictionary<int, string>();

            for (int i = 1; i < 34; i++)
            {
                feature[i] = "";
            }
            foreach (Gua Qimengua in ListGua)
            {   Dictionary<int, string> dic2 = new Dictionary<int, string>();
                //   MessageBox.Show(Qimengua.Ganzhi);
                textBox_ganzhi.Text = Qimengua.Ganzhi;
                // textBox_kaijianghao = Qimengua.Jianghao;
                textBox_shijian.Text = Qimengua.date.ToString();
                textBox_xunkong.Text = Qimengua.Xunkong;
                string kaijianghao = "";
                string MessageTxt = "宫位:\r\n";
                foreach (string n in Qimengua.Jianghao)
                {
                    kaijianghao += n + "  ";
                    MessageTxt +="[["+n+"]("+dic[int.Parse(n)]+ ")] ,\r\n";
                    if(dic2.ContainsKey(int.Parse(n)) )
                   {  dic2[int.Parse(n)] += dic[int.Parse(n)];
                   }
                    else
                    {  dic2.Add(int.Parse(n), dic[int.Parse(n)]);
                      

                    }
                }
                string y= Qimengua.Yinyang;
                if (y.IndexOf("阳") > -1)
                    y = "阳";
                else
                    y = "阴";

                gong_check(Qimengua,dic2, feature,y,Qimengua.Ganzhi,Qimengua.Zhifu);

                textBox_tuili.Text = MessageTxt;

                textBox_kaijianghao.Text = kaijianghao;
                textBox_yinyang.Text = Qimengua.Yinyang;
                textBox_zhishi.Text = Qimengua.Zhishi;
                textBox_zhifu.Text = Qimengua.Zhifu;

                string tu = "┌ ─  ─ ─  ─ ─  ─┬ ─  ─ ─  ─ ─  ─┬ ─  ─ ─  ─ ─  ─ ┐";
                tu += "\r\n" + "│       " + Qimengua.Xun.shen.ToString() + "          │     " + Qimengua.Li.shen.ToString() + "          │    " + Qimengua.Kun.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Xun.xin2_tiangan + "    " + Qimengua.Xun.men + "     " + Qimengua.Xun.men_tiangan + " │    " + Qimengua.Li.xin2_tiangan + "  " + Qimengua.Li.men + "   " + Qimengua.Li.men_tiangan + "       │  " + Qimengua.Kun.xin2_tiangan + "   " + Qimengua.Kun.men + "   " + Qimengua.Kun.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Xun.xin2 + "   " + Qimengua.Xun.xin + "     " + Qimengua.Xun.xin_tiangan + " │  " + Qimengua.Li.xin2 + "   " + Qimengua.Li.xin + "    " + Qimengua.Li.xin_tiangan + "  │  " + "  " + Qimengua.Kun.xin2 + "  " + Qimengua.Kun.xin + "   " + Qimengua.Kun.xin_tiangan + "  |";
                tu += "\r\n" + "├ ─ ─ ─  ─  ─ ─ ┼ ─  ─ ─  ─ ─ ─ ┼ ─ ─ ─   ─ ─  ─ ┤";
                tu += "\r\n" + "│       " + Qimengua.Zhen.shen.ToString() + "          │                       │    " + Qimengua.Dui.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Zhen.xin2_tiangan + "    " + Qimengua.Zhen.men + "     " + Qimengua.Zhen.men_tiangan + " │                       │  " + Qimengua.Dui.xin2_tiangan + "   " + Qimengua.Dui.men + "   " + Qimengua.Dui.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Zhen.xin2 + "   " + Qimengua.Zhen.xin + "     " + Qimengua.Zhen.xin_tiangan + " │          " + Qimengua.Zhong.xin_tiangan + "          │  " + "  " + Qimengua.Dui.xin2 + "  " + Qimengua.Dui.xin + "   " + Qimengua.Dui.xin_tiangan + "  |";


                tu += "\r\n" + "├ ─ ─ ─  ─  ─ ─ ┼ ─  ─ ─  ─ ─ ─ ┼ ─ ─ ─   ─ ─  ─ ┤";
                tu += "\r\n" + "│       " + Qimengua.Gen.shen.ToString() + "          │     " + Qimengua.Kan.shen.ToString() + "          │    " + Qimengua.Qian.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Gen.xin2_tiangan + "    " + Qimengua.Gen.men + "     " + Qimengua.Gen.men_tiangan + " │    " + Qimengua.Kan.xin2_tiangan + "  " + Qimengua.Kan.men + "   " + Qimengua.Kan.men_tiangan + "       │  " + Qimengua.Qian.xin2_tiangan + "   " + Qimengua.Qian.men + "   " + Qimengua.Qian.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Gen.xin2 + "   " + Qimengua.Gen.xin + "     " + Qimengua.Gen.xin_tiangan + " │  " + Qimengua.Kan.xin2 + "   " + Qimengua.Kan.xin + "    " + Qimengua.Kan.xin_tiangan + "  │  " + "  " + Qimengua.Qian.xin2 + "  " + Qimengua.Qian.xin + "   " + Qimengua.Qian.xin_tiangan + "  |";


                tu += "\r\n" + "└ ─  ─ ─  ─ ─ ─ ┴─  ─ ─  ─  ─ ─ ┴ ─  ─ ─  ─ ─  ─ ┘";
                textBox_gua.Text = tu;
                //  Thread.Sleep(2000);
               // textBox_tuili.Text = feature.ToString();
            }
            foreach (Gua Qimengua in ListGua2)
            {
                Dictionary<int, string> dic2 = new Dictionary<int, string>();
                //   MessageBox.Show(Qimengua.Ganzhi);
                textBox_ganzhi.Text = Qimengua.Ganzhi;
                // textBox_kaijianghao = Qimengua.Jianghao;
                textBox_shijian.Text = Qimengua.date.ToString();
                textBox_xunkong.Text = Qimengua.Xunkong;
                string kaijianghao = "";
                string MessageTxt = "宫位:\r\n";
                foreach (string n in Qimengua.Jianghao)
                {
                    kaijianghao += n + "  ";
                    MessageTxt += "[[" + n + "](" + dic[int.Parse(n)] + ")] ,\r\n";
                    if (dic2.ContainsKey(int.Parse(n)))
                    {
                        dic2[int.Parse(n)] += dic[int.Parse(n)];
                    }
                    else
                    {
                        dic2.Add(int.Parse(n), dic[int.Parse(n)]);


                    }
                }
                string y = Qimengua.Yinyang;
                if (y.IndexOf("阳") > -1)
                    y = "阳";
                else
                    y = "阴";
                gong_check(Qimengua, dic2, feature,y, Qimengua.Ganzhi, Qimengua.Zhifu);

                textBox_tuili.Text = MessageTxt;

                textBox_kaijianghao.Text = kaijianghao;
                textBox_yinyang.Text = Qimengua.Yinyang;
                textBox_zhishi.Text = Qimengua.Zhishi;
                textBox_zhifu.Text = Qimengua.Zhifu;

                string tu = "┌ ─  ─ ─  ─ ─  ─┬ ─  ─ ─  ─ ─  ─┬ ─  ─ ─  ─ ─  ─ ┐";
                tu += "\r\n" + "│       " + Qimengua.Xun.shen.ToString() + "          │     " + Qimengua.Li.shen.ToString() + "          │    " + Qimengua.Kun.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Xun.xin2_tiangan + "    " + Qimengua.Xun.men + "     " + Qimengua.Xun.men_tiangan + " │    " + Qimengua.Li.xin2_tiangan + "  " + Qimengua.Li.men + "   " + Qimengua.Li.men_tiangan + "       │  " + Qimengua.Kun.xin2_tiangan + "   " + Qimengua.Kun.men + "   " + Qimengua.Kun.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Xun.xin2 + "   " + Qimengua.Xun.xin + "     " + Qimengua.Xun.xin_tiangan + " │  " + Qimengua.Li.xin2 + "   " + Qimengua.Li.xin + "    " + Qimengua.Li.xin_tiangan + "  │  " + "  " + Qimengua.Kun.xin2 + "  " + Qimengua.Kun.xin + "   " + Qimengua.Kun.xin_tiangan + "  |";
                tu += "\r\n" + "├ ─ ─ ─  ─  ─ ─ ┼ ─  ─ ─  ─ ─ ─ ┼ ─ ─ ─   ─ ─  ─ ┤";
                tu += "\r\n" + "│       " + Qimengua.Zhen.shen.ToString() + "          │                       │    " + Qimengua.Dui.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Zhen.xin2_tiangan + "    " + Qimengua.Zhen.men + "     " + Qimengua.Zhen.men_tiangan + " │                       │  " + Qimengua.Dui.xin2_tiangan + "   " + Qimengua.Dui.men + "   " + Qimengua.Dui.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Zhen.xin2 + "   " + Qimengua.Zhen.xin + "     " + Qimengua.Zhen.xin_tiangan + " │          " + Qimengua.Zhong.xin_tiangan + "          │  " + "  " + Qimengua.Dui.xin2 + "  " + Qimengua.Dui.xin + "   " + Qimengua.Dui.xin_tiangan + "  |";


                tu += "\r\n" + "├ ─ ─ ─  ─  ─ ─ ┼ ─  ─ ─  ─ ─ ─ ┼ ─ ─ ─   ─ ─  ─ ┤";
                tu += "\r\n" + "│       " + Qimengua.Gen.shen.ToString() + "          │     " + Qimengua.Kan.shen.ToString() + "          │    " + Qimengua.Qian.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Gen.xin2_tiangan + "    " + Qimengua.Gen.men + "     " + Qimengua.Gen.men_tiangan + " │    " + Qimengua.Kan.xin2_tiangan + "  " + Qimengua.Kan.men + "   " + Qimengua.Kan.men_tiangan + "       │  " + Qimengua.Qian.xin2_tiangan + "   " + Qimengua.Qian.men + "   " + Qimengua.Qian.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Gen.xin2 + "   " + Qimengua.Gen.xin + "     " + Qimengua.Gen.xin_tiangan + " │  " + Qimengua.Kan.xin2 + "   " + Qimengua.Kan.xin + "    " + Qimengua.Kan.xin_tiangan + "  │  " + "  " + Qimengua.Qian.xin2 + "  " + Qimengua.Qian.xin + "   " + Qimengua.Qian.xin_tiangan + "  |";


                tu += "\r\n" + "└ ─  ─ ─  ─ ─ ─ ┴─  ─ ─  ─  ─ ─ ┴ ─  ─ ─  ─ ─  ─ ┘";
                textBox_gua.Text = tu;
                //  Thread.Sleep(2000);
                // textBox_tuili.Text = feature.ToString();
            }
            string feature_str = "";
            Dictionary<int, string> preidct_dic = new Dictionary<int, string>();
            foreach (KeyValuePair<int, string> f in feature )
            {
                Dictionary<string, int> dic_f = new Dictionary<string, int>();
              //  feature_str += "\r\n" + f.Key + ":" + f.Value;
                string f_str= f.Value;
                string[] f_s = f_str.Split(";");
                foreach(string s in f_s)
                {
                    if (dic_f.ContainsKey(s))
                        dic_f[s] = dic_f[s] + 1;
                    else
                        dic_f.Add(s, 1);
                }
                string f_c = "";
                foreach(KeyValuePair<string, int> d in dic_f)
                {  if(d.Value>0)
                       f_c += d.Key + " " + d.Value.ToString()+";";
                }
                feature_str += "\r\n" + f.Key + ":" + f_c;
                preidct_dic.Add(f.Key, f_c);

            }
          
            
            Stream stream3 = new FileStream(@"c:\Qimen_zhirun_2.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            // MyObj myObj = new MyObj();
            //To Do: 在这里对myObj的属性进行设置
            //    formatter.Serialize(stream, ListGua);
            //    stream.Close();

            List<Gua> ListGua3 = new List<Gua>();

            ListGua3 = (List<Gua>)formatter.Deserialize(stream3);
            stream3.Close();
            foreach (Gua Qimengua in ListGua3)
            {
                Dictionary<int, string> dic2 = new Dictionary<int, string>();
                //   MessageBox.Show(Qimengua.Ganzhi);
                textBox_ganzhi.Text = Qimengua.Ganzhi;
                // textBox_kaijianghao = Qimengua.Jianghao;
                textBox_shijian.Text = Qimengua.date.ToString();
                textBox_xunkong.Text = Qimengua.Xunkong;
                string kaijianghao = "";
                string MessageTxt = "宫位:\r\n";
                foreach (string n in Qimengua.Jianghao)
                {
                    kaijianghao += n + "  ";
                    MessageTxt += "[[" + n + "](" + dic[int.Parse(n)] + ")] ,\r\n";
                    if (dic2.ContainsKey(int.Parse(n)))
                    {
                        dic2[int.Parse(n)] += dic[int.Parse(n)];
                    }
                    else
                    {
                        dic2.Add(int.Parse(n), dic[int.Parse(n)]);


                    }
                }
                string y = Qimengua.Yinyang;
                if (y.IndexOf("阳") > -1)
                    y = "阳";
                else
                    y = "阴";

          

                textBox_tuili.Text = MessageTxt;

                textBox_kaijianghao.Text = kaijianghao;
                textBox_yinyang.Text = Qimengua.Yinyang;
                textBox_zhishi.Text = Qimengua.Zhishi;
                textBox_zhifu.Text = Qimengua.Zhifu;

                string tu = "┌ ─  ─ ─  ─ ─  ─┬ ─  ─ ─  ─ ─  ─┬ ─  ─ ─  ─ ─  ─ ┐";
                tu += "\r\n" + "│       " + Qimengua.Xun.shen.ToString() + "          │     " + Qimengua.Li.shen.ToString() + "          │    " + Qimengua.Kun.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Xun.xin2_tiangan + "    " + Qimengua.Xun.men + "     " + Qimengua.Xun.men_tiangan + " │    " + Qimengua.Li.xin2_tiangan + "  " + Qimengua.Li.men + "   " + Qimengua.Li.men_tiangan + "       │  " + Qimengua.Kun.xin2_tiangan + "   " + Qimengua.Kun.men + "   " + Qimengua.Kun.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Xun.xin2 + "   " + Qimengua.Xun.xin + "     " + Qimengua.Xun.xin_tiangan + " │  " + Qimengua.Li.xin2 + "   " + Qimengua.Li.xin + "    " + Qimengua.Li.xin_tiangan + "  │  " + "  " + Qimengua.Kun.xin2 + "  " + Qimengua.Kun.xin + "   " + Qimengua.Kun.xin_tiangan + "  |";
                tu += "\r\n" + "├ ─ ─ ─  ─  ─ ─ ┼ ─  ─ ─  ─ ─ ─ ┼ ─ ─ ─   ─ ─  ─ ┤";
                tu += "\r\n" + "│       " + Qimengua.Zhen.shen.ToString() + "          │                       │    " + Qimengua.Dui.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Zhen.xin2_tiangan + "    " + Qimengua.Zhen.men + "     " + Qimengua.Zhen.men_tiangan + " │                       │  " + Qimengua.Dui.xin2_tiangan + "   " + Qimengua.Dui.men + "   " + Qimengua.Dui.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Zhen.xin2 + "   " + Qimengua.Zhen.xin + "     " + Qimengua.Zhen.xin_tiangan + " │          " + Qimengua.Zhong.xin_tiangan + "          │  " + "  " + Qimengua.Dui.xin2 + "  " + Qimengua.Dui.xin + "   " + Qimengua.Dui.xin_tiangan + "  |";


                tu += "\r\n" + "├ ─ ─ ─  ─  ─ ─ ┼ ─  ─ ─  ─ ─ ─ ┼ ─ ─ ─   ─ ─  ─ ┤";
                tu += "\r\n" + "│       " + Qimengua.Gen.shen.ToString() + "          │     " + Qimengua.Kan.shen.ToString() + "          │    " + Qimengua.Qian.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Gen.xin2_tiangan + "    " + Qimengua.Gen.men + "     " + Qimengua.Gen.men_tiangan + " │    " + Qimengua.Kan.xin2_tiangan + "  " + Qimengua.Kan.men + "   " + Qimengua.Kan.men_tiangan + "       │  " + Qimengua.Qian.xin2_tiangan + "   " + Qimengua.Qian.men + "   " + Qimengua.Qian.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Gen.xin2 + "   " + Qimengua.Gen.xin + "     " + Qimengua.Gen.xin_tiangan + " │  " + Qimengua.Kan.xin2 + "   " + Qimengua.Kan.xin + "    " + Qimengua.Kan.xin_tiangan + "  │  " + "  " + Qimengua.Qian.xin2 + "  " + Qimengua.Qian.xin + "   " + Qimengua.Qian.xin_tiangan + "  |";


                tu += "\r\n" + "└ ─  ─ ─  ─ ─ ─ ┴─  ─ ─  ─  ─ ─ ┴ ─  ─ ─  ─ ─  ─ ┘";
                textBox_gua.Text = tu;
                gong_check2(Qimengua, preidct_dic, feature, y, Qimengua.Ganzhi, Qimengua.Zhifu);
                //  Thread.Sleep(2000);
                // textBox_tuili.Text = feature.ToString();
            }
            textBox_tuili.Text = feature_str;



        }

private void read_model()
        {   
            // https://wenku.baidu.com/view/d2b11aaddd3383c4bb4cd2d2.html

            // ┌──────┬──────┬──────┐", "└──────┴──────┴──────┘
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"c:\Qimen_zhirun_1.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            // MyObj myObj = new MyObj();
            //To Do: 在这里对myObj的属性进行设置
            //    formatter.Serialize(stream, ListGua);
            //    stream.Close();

            List<Gua> ListGua = new List<Gua>();

            ListGua = (List<Gua>) formatter.Deserialize(stream);
            foreach (Gua Qimengua in ListGua)
            {
             //   MessageBox.Show(Qimengua.Ganzhi);
                textBox_ganzhi.Text = Qimengua.Ganzhi;
                // textBox_kaijianghao = Qimengua.Jianghao;
                textBox_shijian.Text = Qimengua.date.ToString();
                textBox_xunkong.Text = Qimengua.Xunkong;
                string kaijianghao = "";
                foreach(string n in Qimengua.Jianghao)
                {
                    kaijianghao += n + "  ";
                }
                textBox_kaijianghao.Text = kaijianghao;
                textBox_yinyang.Text = Qimengua.Yinyang;
                textBox_zhishi.Text = Qimengua.Zhishi;
                textBox_zhifu.Text = Qimengua.Zhifu;

                string tu = "┌ ─  ─ ─  ─ ─  ─┬ ─  ─ ─  ─ ─  ─┬ ─  ─ ─  ─ ─  ─ ┐";
                tu += "\r\n" + "│       " + Qimengua.Xun.shen.ToString() + "          │     " + Qimengua.Li.shen.ToString() + "          │    " + Qimengua.Kun.shen.ToString()+"              |";
                tu += "\r\n" + "│   " + Qimengua.Xun.xin2_tiangan +"    " + Qimengua.Xun.men + "     " + Qimengua.Xun.men_tiangan + " │    " +Qimengua.Li.xin2_tiangan+"  " + Qimengua.Li.men + "   " + Qimengua.Li.men_tiangan + "       │  "+Qimengua.Kun.xin2_tiangan+"   " + Qimengua.Kun.men + "   " + Qimengua.Kun.men_tiangan+"    |";
                tu+= "\r\n" +  "│   " + Qimengua.Xun.xin2 + "   " + Qimengua.Xun.xin + "     " + Qimengua.Xun.xin_tiangan + " │  " +Qimengua.Li.xin2+"   " + Qimengua.Li.xin + "    " + Qimengua.Li.xin_tiangan + "  │  " +"  "+Qimengua.Kun.xin2+"  "+ Qimengua.Kun.xin + "   " + Qimengua.Kun.xin_tiangan+"  |";
                tu += "\r\n" + "├ ─ ─ ─  ─  ─ ─ ┼ ─  ─ ─  ─ ─ ─ ┼ ─ ─ ─   ─ ─  ─ ┤";
                tu += "\r\n" + "│       " + Qimengua.Zhen.shen.ToString() + "          │                       │    " + Qimengua.Dui.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Zhen.xin2_tiangan + "    " + Qimengua.Zhen.men + "     " + Qimengua.Zhen.men_tiangan + " │                       │  " + Qimengua.Dui.xin2_tiangan + "   " + Qimengua.Dui.men + "   " + Qimengua.Dui.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Zhen.xin2 + "   " + Qimengua.Zhen.xin + "     " + Qimengua.Zhen.xin_tiangan + " │          " + Qimengua.Zhong.xin_tiangan + "          │  " + "  " + Qimengua.Dui.xin2 + "  " + Qimengua.Dui.xin + "   " + Qimengua.Dui.xin_tiangan + "  |";


                tu += "\r\n" + "├ ─ ─ ─  ─  ─ ─ ┼ ─  ─ ─  ─ ─ ─ ┼ ─ ─ ─   ─ ─  ─ ┤";
                tu += "\r\n" + "│       " + Qimengua.Gen.shen.ToString() + "          │     " + Qimengua.Kan.shen.ToString() + "          │    " + Qimengua.Qian.shen.ToString() + "              |";
                tu += "\r\n" + "│   " + Qimengua.Gen.xin2_tiangan + "    " + Qimengua.Gen.men + "     " + Qimengua.Gen.men_tiangan + " │    " + Qimengua.Kan.xin2_tiangan + "  " + Qimengua.Kan.men + "   " + Qimengua.Kan.men_tiangan + "       │  " + Qimengua.Qian.xin2_tiangan + "   " + Qimengua.Qian.men + "   " + Qimengua.Qian.men_tiangan + "    |";
                tu += "\r\n" + "│   " + Qimengua.Gen.xin2 + "   " + Qimengua.Gen.xin + "     " + Qimengua.Gen.xin_tiangan + " │  " + Qimengua.Kan.xin2 + "   " + Qimengua.Kan.xin + "    " + Qimengua.Kan.xin_tiangan + "  │  " + "  " + Qimengua.Qian.xin2 + "  " + Qimengua.Qian.xin + "   " + Qimengua.Qian.xin_tiangan + "  |";


                tu += "\r\n" + "└ ─  ─ ─  ─ ─ ─ ┴─  ─ ─  ─  ─ ─ ┴ ─  ─ ─  ─ ─  ─ ┘";
                textBox_gua.Text = tu;
                Thread.Sleep(15000);
               // Thread.;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //read_model_build();
            Thread readmodel = new Thread(read_model_build);
            readmodel.Start();
        }
    }
}
