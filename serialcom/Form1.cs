using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace serialcom
{


    
    public partial class Form1 : Form
    {
        class readparater
        {
            public int temp_value;

            public string modeget = "";
            public int first_count;
            public int count=0;
            public int mode_set = 0;
            public byte[] numberget;
            public readparater(int start = 4)
            {
                temp_value = 0;
                
                first_count = start;
                count = 0;
                mode_set = 0;
                modeget = "";
                numberget = new byte[4];
            }
            public void resetnum(int start)
            {
                count = 0;
                first_count = start;
                
            }
           
        }
       
       
        const int Mode_control =0;
        const int Mode_set = -1;
        const int Mode_read = 1;
        
        //serial通用变量
        private SerialPort comm = new SerialPort();
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。  
        private bool Listening = false;//是否没有执行完invoke相关操作
        private bool Closing_new = false;//是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke
        private long received_count = 0;//接收计数  
        private long send_count = 0;//发送计数 
      
        //serial接收数据相关
        byte[] print_data = new byte[257];
        int[] tmp = new int[50];
        public Form1()
        {
            InitializeComponent();

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            this.DoubleBuffered = true;//双缓冲
           // this.WindowState = FormWindowState.Maximized;//最大化
            baud.SelectedItem = baud.Items[1];//波特率初始化
            Databox.SelectedItem = Databox.Items[0];
            stopbox.SelectedItem = stopbox.Items[0];
            verifybox.SelectedItem = verifybox.Items[0];
            //显示串口
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comport.Items.AddRange(ports);
            comport.SelectedIndex = comport.Items.Count > 0 ? 0 : -1;
            //初始化SerialPort对象  
            comm.NewLine = "/r/n";
            comm.RtsEnable = false;//reset功能
            comport.Enabled = true;
            baud.Enabled = true;
            
            comm.DataReceived += comm_DataReceived;//添加事件注册(这里的comm_DataReceived是接受函数)

        }
        //将这些设为全局变量
        int i_flag = 0;
       
        int set_value = 0;
      
        int[] info_oprg= new int[10];
        int[] info_chrg_17 = new int[10];
        int[] info_chrg_18 = new int[10];
        string[] op_dec = new string[7];
        string[] ch_dec = new string[10];
        readparater elec_static=new readparater();//实例化一个类来实现读取
        readparater ele_dynamic_A = new readparater();
        readparater time_dynamic_A = new readparater(8);
        readparater ele_dynamic_B = new readparater(10);
        readparater time_dynamic_B = new readparater(14);
        readparater info_V = new readparater();
        readparater info_A = new readparater(8);
        readparater info_W = new readparater(12);
        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            
            if (Closing_new == true)
                return;
            try
            {
                Listening = true;////设置标记，说明我已经开始处理数据，   一会儿要使用系统UI的。
                int n = comm.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致   
                byte[] Received_bytes = new byte[n];//声明一个临时数组存储当前来的串口数据
                comm.Read(Received_bytes, 0, n);//读取缓冲数据 
                received_count += n;//增加接收计数  
                builder.Clear();//清除字符串构造器的内容  
                string hexstring = "";
                string moderead = "";
                byte[] kankan = new byte[4];//
                string dynamic_mode = "";
                string set_word = "";
                int test_mode = 0;
                int[] info_oprg1 = new int[10];
                int check_num = 0;
                this.Invoke((EventHandler)(delegate//因为要访问ui资源，所以需要使用invoke方式同步ui。  
                {
                    //string str = a[0].ToString();
                    //builder.Append(str);
                   
                    if (deccheck.Checked)
                    {


                       
                      
                        foreach (byte b in Received_bytes)
                        {
                            if(i_flag>=26)
                            {
                                i_flag = 0;
                            }
                            i_flag++;
                            if(i_flag==3)
                            {
                                set_word = b.ToString("X2");
                                set_value = Convert.ToInt32(set_word, 16);
                            }
                           
                            if (set_value == 18)
                            {
                                recevie_verify(b, i_flag);
                            }
                          //静态电类值读取
                            if (set_value==35|| set_value==37||set_value==39|| set_value == 43|| set_value == 45|| set_value == 47|| set_value == 49||set_value==79)
                            { 
                                
                                check_num = i_flag;
                                if (i_flag == elec_static.first_count)
                                {
                                    elec_static.first_count++;
                                    if (elec_static.count < 4)
                                    {
                                        elec_static.numberget[elec_static.count] = b;
                                    
                                        elec_static.count++;
                                    }
                                }
                             
                                if (i_flag ==25)
                                {
                                  
                                    elec_static.count = 0;
                                    elec_static.first_count = 4;
                                    kankan = elec_static.numberget;
                                    elec_static.temp_value = BitConverter.ToInt32(elec_static.numberget, 0);
                                    switch(set_value)
                                    {
                                        case 35:
                                            MessageBox.Show("最大输入电压:" + elec_static.temp_value.ToString() + "(1mV)");
                                            break;
                                        case 37:
                                            MessageBox.Show("最大输入电流:" + elec_static.temp_value.ToString() + "(0.1mA)");
                                            break;
                                        case 39:
                                            MessageBox.Show("最大输入功率:" + elec_static.temp_value.ToString() + "(1mW)");
                                            break;
                                        case 43:
                                            MessageBox.Show("定电流值:" + elec_static.temp_value.ToString() + "(0.1mA)");
                                            break;
                                        case 45:
                                            MessageBox.Show("定电压值:" + elec_static.temp_value.ToString() + "(1mV)");
                                            break;
                                        case 47:
                                            MessageBox.Show("定功率值:" + elec_static.temp_value.ToString() + "(1mW)");
                                            break;
                                        case 49:
                                            MessageBox.Show("定电阻值:" + elec_static.temp_value.ToString() + "(1mR)");
                                            break;
                                        case 79:
                                            MessageBox.Show("在定电压模式下的最小电压值:" + elec_static.temp_value.ToString() + "(1mV)");
                                            break;

                                    }
                                       
                                    //hexstring = "最大输入电压:" + temp_value.ToString() + "mV";
                                }

                            }
                            //模式读取
                            if(set_value==41||set_value==87)
                            {
                                if(i_flag==4)
                                {
                                    moderead= b.ToString("X2");
                                    test_mode = Convert.ToInt32(moderead, 16);
                                    switch (set_value)
                                    {
                                        case 41:
                                            switch (test_mode)
                                            {
                                                case 0:
                                                    MessageBox.Show("负载模式为：CC");
                                                    break;
                                                case 1:
                                                    MessageBox.Show("负载模式为：CV");
                                                    break;
                                                case 2:
                                                    MessageBox.Show("负载模式为：CW");
                                                    break;
                                                case 3:
                                                    MessageBox.Show("负载模式为：CR");
                                                    break;

                                            }
                                            break;
                                        case 87:
                                            switch (test_mode)
                                            {
                                                case 0:
                                                    MessageBox.Show("远程测量模式关闭");
                                                    break;
                                                case 1:
                                                    MessageBox.Show("远程测量模式打开");
                                                    break;
                                            }

                                            break;
                                    }
                                }
                            

                            }
                            //动态参数读取
                            if(set_value==51|| set_value==53||set_value==55||set_value==57)
                            {
                                if(i_flag== ele_dynamic_A.first_count)
                                {
                                    if(ele_dynamic_A.first_count<8)
                                        ele_dynamic_A.first_count++;
                                    
                                    if(ele_dynamic_A.count<4)
                                    {  
                                        ele_dynamic_A.numberget[ele_dynamic_A.count] = b;
                                        ele_dynamic_A.count++;
                                        
                                    }
                                }
                                if(i_flag==time_dynamic_A.first_count)
                                {
                                    if (time_dynamic_A.first_count < 10)
                                        time_dynamic_A.first_count++;
                                    if(time_dynamic_A.count<2)
                                    {
                                        time_dynamic_A.numberget[2] = 0;
                                        time_dynamic_A.numberget[3] = 0;
                                        time_dynamic_A.numberget[time_dynamic_A.count] = b;
                                        time_dynamic_A.count++;
                                       
                                    }
                                }
                                if (i_flag == ele_dynamic_B.first_count)
                                {
                                    if(ele_dynamic_B.first_count<14)
                                        ele_dynamic_B.first_count++;
                                    if (ele_dynamic_B.count < 4)
                                    {
                                        ele_dynamic_B.numberget[ele_dynamic_B.count] = b;
                                        ele_dynamic_B.count++;
                                        
                                    }
                                }
                                if (i_flag == time_dynamic_B.first_count)
                                {
                                    if(time_dynamic_B.first_count<16)
                                      time_dynamic_B.first_count++;
                                    if (time_dynamic_B.count < 2)
                                    {
                                        time_dynamic_B.numberget[2] = 0;
                                        time_dynamic_B.numberget[3] = 0;
                                        time_dynamic_B.numberget[time_dynamic_B.count] = b;
                                        time_dynamic_B.count++;
                                       
                                    }
                                }
                                if(i_flag==16)//模式读取
                                {
                                    ele_dynamic_B.modeget = b.ToString("X2");
                                    ele_dynamic_B.mode_set = Convert.ToInt32(ele_dynamic_B.modeget, 16);
                                }
                                
                                if(i_flag==25)
                                {
                                    ele_dynamic_A.resetnum(4);
                                    time_dynamic_A.resetnum(8);
                                    ele_dynamic_B.resetnum(10);
                                    time_dynamic_B.resetnum(14);
                                    ele_dynamic_A.temp_value= BitConverter.ToInt32(ele_dynamic_A.numberget, 0);
                                    time_dynamic_A.temp_value = BitConverter.ToInt32(time_dynamic_A.numberget, 0);
                                    ele_dynamic_B.temp_value= BitConverter.ToInt32(ele_dynamic_B.numberget, 0);
                                    time_dynamic_B.temp_value = BitConverter.ToInt32(time_dynamic_B.numberget, 0);
                                     if(ele_dynamic_B.mode_set==0)
                                    {
                                        dynamic_mode = "CONTINUES";
                                    }
                                     else if(ele_dynamic_B.mode_set==1)
                                    {
                                        dynamic_mode = "PULSE";
                                    }
                                    else if(ele_dynamic_B.mode_set==2)
                                    {
                                        dynamic_mode = "TOGGLED";
                                    }
                                    switch (set_value)
                                    {
                                        case 51:
                                            MessageBox.Show("电流A设定值：" + ele_dynamic_A.temp_value.ToString() + "(0.1mA)\n" +
                                                            "电流A时间值：" + time_dynamic_A.temp_value.ToString() + "(0.1MS)\n" +
                                                             "电流B设定值：" + ele_dynamic_B.temp_value.ToString() + "(0.1mA)\n" +
                                                             "电流B时间值：" + time_dynamic_B.temp_value.ToString() + "(0.1MS)\n" +
                                                             "操作模式：" + dynamic_mode);
                                            break;
                                        case 53:
                                            MessageBox.Show("电压A设定值：" + ele_dynamic_A.temp_value.ToString() + "(1mV)\n" +
                                                           "电压A时间值：" + time_dynamic_A.temp_value.ToString() + "(0.1MS)\n" +
                                                            "电压B设定值：" + ele_dynamic_B.temp_value.ToString() + "(1mV)\n" +
                                                            "电压B时间值：" + time_dynamic_B.temp_value.ToString() + "(0.1MS)\n" +
                                                            "操作模式：" + dynamic_mode);
                                            break;
                                        case 55:
                                            MessageBox.Show("功率A设定值：" + ele_dynamic_A.temp_value.ToString() + "(1mW)\n" +
                                                           "功率A时间值：" + time_dynamic_A.temp_value.ToString() + "(0.1MS)\n" +
                                                            "功率B设定值：" + ele_dynamic_B.temp_value.ToString() + "(1mW)\n" +
                                                            "功率B时间值：" + time_dynamic_B.temp_value.ToString() + "(0.1MS)\n" +
                                                            "操作模式：" + dynamic_mode);
                                            break;
                                        case 57:
                                            MessageBox.Show("电阻A设定值：" + ele_dynamic_A.temp_value.ToString() + "(1mR)\n" +
                                                           "电阻A时间值：" + time_dynamic_A.temp_value.ToString() + "(0.1MS)\n" +
                                                            "电阻B设定值：" + ele_dynamic_B.temp_value.ToString() + "(1mR)\n" +
                                                            "电阻B时间值：" + time_dynamic_B.temp_value.ToString() + "(0.1MS)\n" +
                                                            "操作模式：" + dynamic_mode);
                                            break;

                                    }


                                  
                         
                                }
                            }
                            //负载相关输入信息
                            if(set_value==95)
                            {
                                if (i_flag == info_V.first_count)
                                {
                                    if (info_V.first_count < 8)
                                        info_V.first_count++;
                                    if (info_V.count < 4)
                                    {
                                        info_V.numberget[info_V.count] = b;
                                        info_V.count++;
                                    }
                                }
                                if (i_flag==info_A.first_count)
                                {
                                    if (info_A.first_count < 12)
                                        info_A.first_count++;

                                    if (info_A.count < 4)
                                    {
                                        info_A.numberget[info_A.count] = b;
                                        info_A.count++;

                                    }
                                }

                                
                                if(i_flag==info_W.first_count)
                                {
                                    if (info_W.first_count < 16)
                                        info_W.first_count++;
                                    if(info_W.count<4)
                                    {
                                        info_W.numberget[info_W.count] = b;
                                        info_W.count++;
                                    }
                                }
                                if(i_flag==16)
                                {
                                    int i = 0;
                                    int j = 0;
                                    
                                    for(i=0, j = 1; i <8;i++)
                                    {
                                        if(j<=128)
                                        {
                                            info_oprg[i] = (b & j) == j ? 1 : 0;
                                        }
                                        j *= 2;

                                    }
                                    info_oprg1 = info_oprg;
                                }
                               if(i_flag==17)
                                {
                                    int i = 0;
                                    int j = 0;

                                    for (i = 0, j = 1; i < 8; i++)
                                    {
                                        if (j <= 128)
                                        {
                                            info_chrg_17[i] = (b & j) == j ? 1 : 0;
                                        }
                                        j *= 2;

                                    }
                                }
                                if (i_flag == 18)
                                {
                                    int i = 0;
                                    int j = 0;

                                    for (i = 0, j = 1; i < 8; i++)
                                    {
                                        if (j <= 128)
                                        {
                                            info_chrg_18[i] = (b & j) == j ? 1 : 0;
                                        }
                                        j *= 2;

                                    }
                                }
                                if(i_flag==25)
                                {
                                    info_V.resetnum(4);
                                    info_A.resetnum(8);
                                    info_W.resetnum(12);
                                    info_V.temp_value = BitConverter.ToInt32(info_V.numberget, 0);
                                    info_A.temp_value= BitConverter.ToInt32(info_A.numberget, 0);
                                    info_W.temp_value = BitConverter.ToInt32(info_W.numberget, 0);
                                    op_dec = info_opstr(info_oprg);
                                    ch_dec = info_chstr(info_chrg_17, info_chrg_18);
                                    MessageBox.Show("输入电压：" + info_V.temp_value.ToString() + "(1mV)\n" +
                                                    "输入电流：" + info_A.temp_value.ToString() + "(0.1mA)\n" +
                                                    "输入功率：" + info_W.temp_value.ToString() + "(1mW)\n" +
                                                    "操作状态寄存器：" + op_dec[0] + "   " + "查询状态寄存器：" + ch_dec[0] + "\n" +
                                                    "操作状态寄存器：" + op_dec[1] + "   " + "查询状态寄存器：" + ch_dec[1] + "\n" +
                                                    "操作状态寄存器：" + op_dec[2] + "    " + "查询状态寄存器：" + ch_dec[2] + "\n" +
                                                    "操作状态寄存器：" + op_dec[3] + "   " + "查询状态寄存器：" + ch_dec[3] + "\n" +
                                                    "操作状态寄存器：" + op_dec[4] + "   " + "查询状态寄存器：" + ch_dec[4] + "\n" +
                                                    "操作状态寄存器：" + op_dec[5] + "   " + "查询状态寄存器：" + ch_dec[5] + "\n" +
                                                    "操作状态寄存器：" + op_dec[6] + "   " + "查询状态寄存器：" + ch_dec[6] + "\n" +
                                                      "                                    "+"查询状态寄存器：" + ch_dec[7] + "\n" +
                                                        "                                    "+"查询状态寄存器：" + ch_dec[8] + "\n" +
                                                         "                                   "+"查询状态寄存器：" + ch_dec[9]);


                                }



                            }

                            hexstring += b.ToString("X2");
                           
                            





                        }
                      
                        
                          
                        
                     



                        //  MessageBox.Show("出错！");



                        //int value = Convert.ToInt32(hexstring, 16);
                        builder.Append(hexstring);


                    }
                    else if (hexshow.Checked)//判断是否是显示为16进制  
                    {
                        foreach (byte b in Received_bytes) //依次的拼接出16进制字符串  
                            builder.Append(b.ToString("X2") + " ");
                    }
                    else
                    {
                        if (asciishow.Checked == true)
                        {
                            string str = Encoding.ASCII.GetString(Received_bytes);//蓝牙AT时'\r'要剔除
                            builder.Append(str.Replace("\r", ""));//直接按ASCII规则转换成字符串
                        }
                        else
                            builder.Append(Encoding.GetEncoding("GB2312").GetString(Received_bytes));//已经可以支持中文
                    }
                    
                    this.receivedbox.AppendText(builder.ToString());//追加的形式添加到文本框末端，并滚动到最后。  
                    label4.Text = "已接收:" + received_count.ToString();//修改接收计数  
                }));
          


            }
            finally
            {
                Listening = false;//我用完了，ui可以关闭串口了。
            }
           
        }
        public string[] info_opstr(int[] num)
        {
            string[] numtoinfo = new string[7];
            numtoinfo[0] = "CAL=" + num[0].ToString();//因为是小端模式的，所以需要反序。
            numtoinfo[1] = "WTG=" + num[1].ToString();
            numtoinfo[2] = "REM=" + num[2].ToString();
            numtoinfo[3] = "OUT=" + num[3].ToString();
            numtoinfo[4] = "LOCAL=" + num[4].ToString();
            numtoinfo[5] = "SENSE=" + num[5].ToString();
            numtoinfo[6] = "LOT=" + num[6].ToString();
            return numtoinfo;
        }
        public string[] info_chstr(int[] num1,int[] num2)
        {
            string[] chestr = new string[10];
            chestr[0] = "RV="+ num1[0].ToString();
            chestr[1] = "OV=" + num1[1].ToString();
            chestr[2] = "OC=" + num1[2].ToString();
            chestr[3] = "OP=" + num1[3].ToString();
            chestr[4] = "OH=" + num1[4].ToString();
            chestr[5] = "SV=" + num1[5].ToString();
            chestr[6] = "CC=" + num1[6].ToString();
            chestr[7] = "CV=" + num1[7].ToString();
            chestr[8] = "CP=" + num2[0].ToString();
            chestr[9] = "CR=" + num2[1].ToString();
            return chestr;
        }
        public void recevie_verify(byte byte_verify,int start = 0)//该方法是为了检验发回的校验码是否成功
        {
            
            string temp = "";
            int check_value = 0;
            if(start == 4)
            {
                temp = byte_verify.ToString("X2");
                check_value = Convert.ToInt32(temp, 16);
                if (check_value == 144)
                {
                    
                    MessageBox.Show("校验和错误");

                }
                else if (check_value == 160)
                {
                  
                    MessageBox.Show("参数错误或参数溢出");
                }
                else if (check_value == 176)
                {
                   
                    MessageBox.Show("命令不能被执行");
                }
                else if (check_value == 192)
                {
                   
                    MessageBox.Show("命令无效");
                }
                else if (check_value == 128)
                {
                    MessageBox.Show("成功");
                    
                }

            }
         
        
        }
        private void comopen_Click(object sender, EventArgs e)
        {
            if(comm.IsOpen)
            {
                Closing_new = true;
                while (Listening)
                    Application.DoEvents();
                comm.Close();
            }
            else
            {
                if(comport.Text=="")
                {
                    MessageBox.Show("出错！没有串口！");
                    return;
                }
                //打开串口
                Closing_new = false;
                comm.PortName = comport.Text;
                comm.BaudRate = int.Parse(baud.Text);
                try
                {
                    comm.Open();
                }
                catch(Exception ex)
                {
                    comm = new SerialPort();
                    MessageBox.Show(ex.Message);
                }
            }
            comopen.Text = comm.IsOpen ? "关闭端口" : "打开端口";//设置按钮状态
            comport.Enabled = !comm.IsOpen;
            baud.Enabled = !comm.IsOpen;
        }

        private void Clearall_Click(object sender, EventArgs e)
        {
            received_count = 0;
            receivedbox.Text = "已清空!!";
            label4.Text = "已接收：0";
        }

        private void sendbt_Click(object sender, EventArgs e)
        {
            //定义一个变量，记录发送几个字节
            if (!comm.IsOpen)
                return;
            int n = 0;
            if(hexsend.Checked)
            {
                string strText;
                string boxtext;
                boxtext = sendbox.Text;
                strText = boxtext.Replace(" ", " ");
                byte[] btext = new byte[strText.Length / 2];
                for(int i =0;i<strText.Length/2;i++)
                {
                    btext[i] = Convert.ToByte(Convert.ToInt32(strText.Substring(i * 2, 2), 16));
                }
                comm.Write(btext,0,strText.Length/2);
                n = strText.Length / 2;
                //MatchCollection mc = Regex.Matches(sendbox.Text, @"(?i)[/da-f]{2}");
                //List<byte> buf = new List<byte>();//填充到这个临时列表中  
                ////依次添加到列表中  
                //foreach (Match m in mc)
                //{
                //    buf.Add(byte.Parse(m.Value));
                //}
                ////转换列表为数组后发送  
                //comm.Write(buf.ToArray(), 0, buf.Count);
                ////记录发送的字节数  
                //n = buf.Count;
            }
            else
            {
                if (spacesend.Checked)//包含换行符
                {
                    comm.Write(sendbox.Text + System.Environment.NewLine);
                    if (sendbox.Text.Length > 0)
                        n = sendbox.Text.Length + 2;
                    else
                        n = sendbox.Text.Length;
                }
                else//不包含换行符
                {
                    string a = sendbox.Text;
                    string s = sendbox.Text;
                    n = sendbox.Text.Length;
                    if(n>=1)
                    {
                        if (a[n - 1] == '\n')
                            s = a.Substring(0, n - 1) + "\r\n";
                        n = n + 1;
                        comm.Write(s);
                    }
                   
                }


            }
            send_count += n;
            sendlabel.Text = "已发送:" + send_count.ToString();
            if(n==0)
            {
                MessageBox.Show("无发送信息！");
            }
        }

        private void sendclear_Click(object sender, EventArgs e)
        {
            send_count = 0;
            sendlabel.Text = "已发送:0";
            sendbox.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void remote_Click(object sender, EventArgs e)
        {
            if (!comm.IsOpen)
            {
                MessageBox.Show("串口未打开，请检查");
                return;
            }

            if (remote.Text=="远程操作")
            {
                remote.Text = "面板操作";
                string test;
                test = Dectohex(sendbox.Text,0,0,1);
                byte[] btext = new byte[test.Length / 2];
                for (int i = 0; i < test.Length / 2; i++)
                {
                    btext[i] = Convert.ToByte(Convert.ToInt32(test.Substring(i * 2, 2), 16));
                }
                comm.Write(btext, 0, test.Length / 2);
             
            }
            else
            {
                remote.Text = "远程操作";
                string link_local;
                link_local = Dectohex("",0,0,0);
                byte[] btext = new byte[link_local.Length / 2];
                for (int i = 0; i < link_local.Length / 2; i++)
                {
                    btext[i] = Convert.ToByte(Convert.ToInt32(link_local.Substring(i * 2, 2), 16));
                }
                comm.Write(btext, 0, link_local.Length / 2);
                sendbox.Clear();
            }
        }
        public string Dectohex(string decstring="",int kind=0,int modeset=0,int getvlave=0)
        {
            string sendstring;
            int[] dec = new int[25];
            string[] promitive = new string[25];
            string[] inputvalue = new string[4];
            int[] decvalue = new int[4];
            string middle;
            dec[0] = 170;//同步头
            dec[1] = 0;//地址位
            dec[2] = 32 + kind;
            dec[3] = 0;//初始值输入
            dec[4] = 0;//系统保留
            int correct = 0;//校验初始值

            //对前三个字节做的十六进制转换
            for (int i = 0; i < 3; i++)
            {
                promitive[i] = dec[i].ToString("X2");

            }
            switch(modeset)
            {
                case Mode_set://这是设置数据的状态
                    
                        dec[3] = Int32.Parse(decstring);//输入的指定值
                                                        //对设置的电流电压值进行转换十六进制
                        middle = dec[3].ToString("X8");
                        promitive[3] = "";
                        int j = 0;
                        for (int i = 6; i >= 0; i -= 2)
                        {

                            promitive[3] += middle.Substring(i, 2);
                            if (j < 4)
                            {
                                inputvalue[j] = middle.Substring(i, 2);
                                decvalue[j] = Convert.ToInt32(inputvalue[j], 16);
                            }
                            j++;
                        }
                        dec[3] = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            dec[3] += decvalue[i];
                        }
                    //设置系统保留的十六进制
                    promitive[4] = dec[4].ToString("X36");
                    break;
                case Mode_read:
                    dec[3] = 0;
                    promitive[3] = dec[3].ToString("X8");
                    promitive[4] = dec[4].ToString("X36");
                    break;
                case Mode_control:
                    dec[3] = getvlave;
                    promitive[3] = dec[3].ToString("X2");
                    promitive[4] = dec[4].ToString("X42");
                    break;

                 
        }

            
            //计算校验和
            string verify = "";
            for (int i = 0; i < 5; i++)
            {
                correct += dec[i];
            }
            verify = correct.ToString("X8");
            promitive[5] = verify.Substring(6, 2);

            sendstring = "";
            for(int i=0;i<6;i++)
            {
                sendstring += promitive[i];
            }
           
            return sendstring;
        }
        public string dynamictran(int kind = 0, string V_A="",string T_A="",string V_B="",string T_B="",int move=0)
        {
            string dynamic_hex="";
            string temp = "";
            string verify = "";
            int[] dynamic_dec = new int[10];
            string[] dynamic_pre = new string[10];
            string[] inputvalue = new string[4];
            int[]    decvalue = new int[4];
            dynamic_dec[0] = 170;//同步头
            dynamic_dec[1] = 0;//地址位
            dynamic_dec[2] = 32 + kind;
            dynamic_dec[8] = 0;//系统保留
            int correct = 0;//校验码和
            //将前三个字节转换为十六进制字符串
            for(int i=0;i<3;i++)
            {
                dynamic_pre[i] = dynamic_dec[i].ToString("X2");
            }


            //输入的A电类的值
            dynamic_dec[3] = Int32.Parse(V_A);
            //对设置A电类值进行转换十六进制
            temp = dynamic_dec[3].ToString("X8"); 
            dynamic_pre[3] = "";
            int j_va= 0;
            for (int i = 6; i >= 0; i -= 2)
            {

                dynamic_pre[3] += temp.Substring(i, 2);
                if (j_va < 4)
                {
                    inputvalue[j_va] = temp.Substring(i, 2);
                    decvalue[j_va] = Convert.ToInt32(inputvalue[j_va], 16);
                }
                j_va++;
            }
            dynamic_dec[3] = 0;
            for (int i = 0; i < 4; i++)
            {
                dynamic_dec[3] += decvalue[i];
            }


            //输入的A时间值
            dynamic_dec[4] = Int32.Parse(T_A);
            //对设置A时间值进行转换十六进制
            temp = dynamic_dec[4].ToString("X4");
            dynamic_pre[4] = "";
            int j_ta = 0;
            for (int i = 2; i >= 0; i -= 2)
            {

                dynamic_pre[4] += temp.Substring(i, 2);
                if (j_ta < 2)
                {
                    inputvalue[j_ta] = temp.Substring(i, 2);
                    decvalue[j_ta] = Convert.ToInt32(inputvalue[j_ta], 16);
                }
                j_ta++;
            }
            dynamic_dec[4] = 0;
            for (int i = 0; i < 2; i++)
            {
                dynamic_dec[4] += decvalue[i];
            }


            //输入的B电类的值
            dynamic_dec[5] = Int32.Parse(V_B);
            //对设置B电类值进行转换十六进制
            temp = dynamic_dec[5].ToString("X8");
            dynamic_pre[5] = "";
            int j_vb = 0;
            for (int i = 6; i >= 0; i -= 2)
            {

                dynamic_pre[5] += temp.Substring(i, 2);
                if (j_vb < 4)
                {
                    inputvalue[j_vb] = temp.Substring(i, 2);
                    decvalue[j_vb] = Convert.ToInt32(inputvalue[j_vb], 16);
                }
                j_vb++;
            }
            dynamic_dec[5] = 0;
            for (int i = 0; i < 4; i++)
            {
                dynamic_dec[5] += decvalue[i];
            }

            //输入的B时间值
            dynamic_dec[6] = Int32.Parse(T_B);
            //对设置B时间值进行转换十六进制
            temp = dynamic_dec[6].ToString("X4");
            dynamic_pre[6] = "";
            int j_tb = 0;
            for (int i = 2; i >= 0; i -= 2)
            {

                dynamic_pre[6] += temp.Substring(i, 2);
                if (j_tb < 2)
                {
                    inputvalue[j_tb] = temp.Substring(i, 2);
                    decvalue[j_tb] = Convert.ToInt32(inputvalue[j_tb], 16);
                }
                j_tb++;
            }
            dynamic_dec[6] = 0;
            for (int i = 0; i < 2; i++)
            {
                dynamic_dec[6] += decvalue[i];
            }
            //动态模式设置
            dynamic_dec[7] = move;
            dynamic_pre[7] = dynamic_dec[7].ToString("X2");
            //系统保留
            dynamic_pre[8] = dynamic_dec[8].ToString("X18");
            //校验码
            for(int i=0;i<=8;i++)
            {
                correct += dynamic_dec[i];
            }
            verify = correct.ToString("X8");
            dynamic_pre[9] = verify.Substring(6, 2);
            for(int i=0;i<=9;i++)
            {
                dynamic_hex += dynamic_pre[i];
            }

            return dynamic_hex;
        }
        private void test_Click(object sender, EventArgs e)
        {
            if (!comm.IsOpen)
            {
                MessageBox.Show("串口未打开，请检查");
                return;
            }
               
            string hexstring="";
            //模式设置
             if (mode_selec.SelectedItem == mode_selec.Items[0])//控制负载输入状态
            {
                if(elec_switch.SelectedItem==elec_switch.Items[0])
                {
                    hexstring = Dectohex("", 1, Mode_control,0);//OFF
                }
                else if(elec_switch.SelectedItem == elec_switch.Items[1])
                {
                    hexstring = Dectohex("", 1, Mode_control, 1);//ON
                }
              
            }
            else if(mode_selec.SelectedItem == mode_selec.Items[1])//负载模式的设置
            {
                if (selec_elec.SelectedItem == selec_elec.Items[0])
                {
                    hexstring = Dectohex("", 8, Mode_control, 0);//CC
                }
                else if (selec_elec.SelectedItem == selec_elec.Items[1])
                {
                    hexstring = Dectohex("", 8, Mode_control, 1);//CV
                }
                else if (selec_elec.SelectedItem == selec_elec.Items[2])
                {
                    hexstring = Dectohex("", 8, Mode_control, 2);//CW
                }
                else if (selec_elec.SelectedItem == selec_elec.Items[3])
                {
                    hexstring = Dectohex("", 8, Mode_control, 3);//CR
                }
            }
            else if (mode_selec.SelectedItem == mode_selec.Items[2])//local是否使用
            {
                if(local_permit.SelectedItem==local_permit.Items[0])
                {
                    hexstring = Dectohex("", 53, Mode_control, 0);//禁止
                }
                else if(local_permit.SelectedItem==local_permit.Items[1])
                {
                    hexstring = Dectohex("", 53, Mode_control, 1);//允许
                }
            }
            else if (mode_selec.SelectedItem == mode_selec.Items[3])//远程测量是否打开
            {
                if(elec_switch.SelectedItem==elec_switch.Items[0])
                {
                    hexstring = Dectohex("", 54, Mode_control, 0);//禁止
                }
                else if (elec_switch.SelectedItem == elec_switch.Items[1])
                {
                    hexstring = Dectohex("", 54, Mode_control, 1);//允许
                }
            }


            //数值读取
            if (read_selec.SelectedItem == read_selec.Items[0])
            {
                hexstring = Dectohex("", 3, Mode_read);//读取最大输入电压
            }
            else if (read_selec.SelectedItem == read_selec.Items[1])
            {
                hexstring = Dectohex("", 5, Mode_read);//读取最大输入电流
            }
            else if (read_selec.SelectedItem == read_selec.Items[2])
            {
                hexstring = Dectohex("", 7, Mode_read);//读取最大输入功率值
            }
            else if (read_selec.SelectedItem == read_selec.Items[3])
            {
                hexstring = Dectohex("", 11, Mode_read);//读取负载定电流值
            }
            else if (read_selec.SelectedItem == read_selec.Items[4])
            {
                hexstring = Dectohex("", 13, Mode_read);//读取负载的定电压值
            }
            else if (read_selec.SelectedItem == read_selec.Items[5])
            {
                hexstring = Dectohex("", 15, Mode_read);//读取负载的定功率值
            }
            else if (read_selec.SelectedItem == read_selec.Items[6])
            {
                hexstring = Dectohex("", 17, Mode_read);//读取负载的定电阻值
            }
            else if (read_selec.SelectedItem == read_selec.Items[7])
            {
                hexstring = Dectohex("", 9, Mode_read);//读取负载模式
            }
            else if (read_selec.SelectedItem == read_selec.Items[8])
            {
                hexstring = Dectohex("", 47, Mode_read);//读取负载定电压模式下的最小电压值
            }
            else if (read_selec.SelectedItem == read_selec.Items[9])
            {
                hexstring = Dectohex("", 55, Mode_read);//读取远程测量模式
            }
            else if (read_selec.SelectedItem == read_selec.Items[10])
            {
                hexstring = Dectohex("", 63, Mode_read);//读取负载相关状态
            }
            else if (read_selec.SelectedItem == read_selec.Items[11])
            {
                hexstring = Dectohex("", 19, Mode_read);//读取负载动态电流参数值
            }
            else if (read_selec.SelectedItem == read_selec.Items[12])
            {
                hexstring = Dectohex("", 21, Mode_read);//读取负载动态电压参数值
            }
            else if (read_selec.SelectedItem == read_selec.Items[13])
            {
                hexstring = Dectohex("", 23, Mode_read);//读取负载动态功率参数值
            }
            else if (read_selec.SelectedItem == read_selec.Items[14])
            {
                hexstring = Dectohex("", 25, Mode_read);//读取负载动态电阻参数值
            }


            //数值输入
            if (controlbox.SelectedItem==controlbox.Items[0])
            {
                hexstring = Dectohex(staticnum.Text, 2, Mode_set);//设置最大输入电压值
            }
            else if(controlbox.SelectedItem==controlbox.Items[1])
            {
                hexstring = Dectohex(staticnum.Text, 4, Mode_set);//设置最大输入电流值
            }
            else if (controlbox.SelectedItem == controlbox.Items[2])
            {
                hexstring = Dectohex(staticnum.Text, 6, Mode_set);//设置最大输入功率
            }
            else if (controlbox.SelectedItem == controlbox.Items[3])
            {
                hexstring = Dectohex(staticnum.Text, 10, Mode_set);//设置定电流值
            }
            else if (controlbox.SelectedItem == controlbox.Items[4])
            {
                hexstring = Dectohex(staticnum.Text, 12, Mode_set);//设置定电压值
            }
            else if (controlbox.SelectedItem == controlbox.Items[5])
            {
                hexstring = Dectohex(staticnum.Text, 14, Mode_set);//设置定功率值
            }
            else if (controlbox.SelectedItem == controlbox.Items[6])
            {
                hexstring = Dectohex(staticnum.Text, 16, Mode_set);//设置定电阻值
            }
            else if (controlbox.SelectedItem == controlbox.Items[7])
            {
                hexstring = Dectohex(staticnum.Text, 46, Mode_set);//设置定电压模式下的最小电压值
            }

            //动态数值输入
            if(dynamic_selec.SelectedItem==dynamic_selec.Items[0])
            {
                if (dynamic_check.SelectedItem == dynamic_check.Items[0])
                    hexstring = dynamictran(18, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 0) ;
                else if(dynamic_check.SelectedItem == dynamic_check.Items[1])
                    hexstring = dynamictran(18, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 1);
                else if (dynamic_check.SelectedItem == dynamic_check.Items[2])
                    hexstring = dynamictran(18, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 2);
                else if (dynamic_check.SelectedItem == dynamic_check.Items[3])
                    hexstring = dynamictran(18, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 3);

            }
            else if(dynamic_selec.SelectedItem==dynamic_selec.Items[1])
            {
                if (dynamic_check.SelectedItem == dynamic_check.Items[0])
                    hexstring = dynamictran(20, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 0) ;
                else if (dynamic_check.SelectedItem == dynamic_check.Items[1])
                    hexstring = dynamictran(20, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 1);
                else if (dynamic_check.SelectedItem == dynamic_check.Items[2])
                    hexstring = dynamictran(20, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 2);
                else if (dynamic_check.SelectedItem == dynamic_check.Items[2])
                    hexstring = dynamictran(20, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 3);
            }
            else if (dynamic_selec.SelectedItem == dynamic_selec.Items[2])
            {
                if (dynamic_check.SelectedItem == dynamic_check.Items[0])
                    hexstring = dynamictran(22, V_A.Text, T_A.Text, V_B.Text, T_B.Text,0);
                else if (dynamic_check.SelectedItem == dynamic_check.Items[1])
                    hexstring = dynamictran(22, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 1);
                else if (dynamic_check.SelectedItem == dynamic_check.Items[2])
                    hexstring = dynamictran(22, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 2);
                else if (dynamic_check.SelectedItem == dynamic_check.Items[3])
                    hexstring = dynamictran(22, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 3);
            }
            else if (dynamic_selec.SelectedItem == dynamic_selec.Items[3])
            {
                if (dynamic_check.SelectedItem == dynamic_check.Items[0])
                    hexstring = dynamictran(24, V_A.Text, T_A.Text, V_B.Text, T_B.Text,0);
                else if (dynamic_check.SelectedItem == dynamic_check.Items[1])
                    hexstring = dynamictran(24, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 1);
                else if (dynamic_check.SelectedItem == dynamic_check.Items[2])
                    hexstring = dynamictran(24, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 2);
                else if (dynamic_check.SelectedItem == dynamic_check.Items[3])
                    hexstring = dynamictran(24, V_A.Text, T_A.Text, V_B.Text, T_B.Text, 3);
            }

            byte[] btext = new byte[hexstring.Length / 2];
            for (int i = 0; i < hexstring.Length / 2; i++)
            {
                btext[i] = Convert.ToByte(Convert.ToInt32(hexstring.Substring(i * 2, 2), 16));
            }
            comm.Write(btext, 0, hexstring.Length / 2);
        }

        private void sendbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void mode_selec_SelectedIndexChanged(object sender, EventArgs e)
        {
            controlbox.SelectedIndex = -1;
            dynamic_selec.SelectedIndex = -1;
            read_selec.SelectedIndex = -1;
            staticnum.Clear();
            reset_dynamic();
            dynamic_check.Enabled = false;
            if (mode_selec.SelectedItem == mode_selec.Items[0])//负载输入状态
            {
                elec_switch.Enabled = true;
                selec_elec.Enabled = false;
                local_permit.Enabled = false;
            }
            else if(mode_selec.SelectedItem == mode_selec.Items[1])//负载模式
            {
                elec_switch.Enabled = false;
                selec_elec.Enabled = true;
                local_permit.Enabled = false;
            }
            else if(mode_selec.SelectedItem==mode_selec.Items[2])//local模式
            {
                elec_switch.Enabled = false;
                selec_elec.Enabled = false;
                local_permit.Enabled = true;
            }
            else if (mode_selec.SelectedItem == mode_selec.Items[3])//远程测量状态
            {
                elec_switch.Enabled = true;
                selec_elec.Enabled = false;
                local_permit.Enabled = false;
            }

        }

        private void elec_switch_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            for(int i=0;i<elec_switch.Items.Count;i++)
            {
                if(i!=e.Index)
                {
                    elec_switch.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            }
        }

        private void selec_elec_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for(int i=0;i<selec_elec.Items.Count;i++)
            {
                if(i!=e.Index)
                {
                    selec_elec.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            }
        }

        private void local_permit_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for(int i=0;i<local_permit.Items.Count;i++)
            {
                if(i!=e.Index)
                {
                    local_permit.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            }
        }

        private void read_selec_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            controlbox.SelectedIndex = -1;
            dynamic_selec.SelectedIndex = -1;
            mode_selec.SelectedIndex = -1;
            staticnum.Clear();
            reset_dynamic();
            elec_switch.Enabled = false;
            selec_elec.Enabled = false;
            local_permit.Enabled = false;
            dynamic_check.Enabled = false;
        }

        private void dynamic_selec_SelectedIndexChanged(object sender, EventArgs e)
        {
            controlbox.SelectedIndex = -1;
            read_selec.SelectedIndex = -1;
            mode_selec.SelectedIndex = -1;
            staticnum.Enabled = false;
            staticnum.Clear();
           
            elec_switch.Enabled = false;
            selec_elec.Enabled = false;
            local_permit.Enabled = false;
           
        }
        public void reset_dynamic()
        {
            V_A.Clear();
            V_A.Enabled = false;
            T_A.Clear();
            T_A.Enabled = false;
            V_B.Clear();
            V_B.Enabled = false;
            T_B.Clear();
            T_B.Enabled = false;
        }
        private void controlbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_selec.SelectedIndex = -1;
            dynamic_selec.SelectedIndex = -1;
            mode_selec.SelectedIndex = -1;
            reset_dynamic();
            elec_switch.Enabled = false;
            selec_elec.Enabled = false;
            local_permit.Enabled = false;
            dynamic_check.Enabled = false;
        }

        private void dynamic_check_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < dynamic_check.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    dynamic_check.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            }
        }
    }
}
