using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CacheSimulator
{
    public partial class Form1 : Form
    {
        bool verbose = false;
        bool interrupt = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
            wordCombo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // memory
            uint memSize;
            if (!uint.TryParse(memSizeText.Text, out memSize))
            {
                ShowToolTip(memSizeText, "메모리 크기를 입력하세요(KB)");
                return;
            }
            memSize *= 1024;

            double speed;
            if (!double.TryParse(speedText.Text, out speed))
            {
                ShowToolTip(speedText, "메모리 속도를 입력하세요(ms)");
                return;
            }
            Memory mainMem = new Memory(speed);

            uint wordSize;
            if (wordCombo.SelectedItem == null || !uint.TryParse(
                wordCombo.SelectedItem.ToString().Substring(0, 2),
                out wordSize)
                )
            {
                ShowToolTip(wordCombo, "메모리 word 길이를 고르세요");
                return;
            }

            // cache0
            uint cacheSize;
            if (!uint.TryParse(sizeText1.Text, out cacheSize))
            {
                ShowToolTip(sizeText1, "캐시 크기를 입력하세요(KB)");
                return;
            }
            cacheSize *= 1024;

            double speed1;
            if (!double.TryParse(speedText1.Text, out speed1))
            {
                ShowToolTip(speedText1, "캐시 속도를 입력하세요(ms)");
                return;
            }

            uint lineSize;
            if (!uint.TryParse(lineSize1.Text, out lineSize))
            {
                ShowToolTip(lineSize1, "라인 크기를 정해주세요(Byte)");
                return;
            }

            Type t;
            if (radio1.Checked)
                t = Type.Direct;
            else if (radio2.Checked)
                t = Type.Associative;
            else if (radio3.Checked)
                t = Type.SetAssociative;
            else
            {
                ShowToolTip(radio1, "캐시 종류를 골라주세요");
                return;
            }

            uint setSize = 1;
            if (t == Type.SetAssociative)
            {
                if (!uint.TryParse(setText1.Text, out setSize))
                {
                    ShowToolTip(setText1, "Set 크기를 정해주세요(2의 지수)");
                    return;
                }
            }

            // 초기화
            Cache cache0;
            try
            {
                cache0 = new Cache(t, speed1, mainMem,
                    memSize, wordSize,
                    cacheSize, lineSize, setSize);
                lineLenText1.Text = cache0.lineLength().ToString();
            } catch (Exception error)
            {
                logText.Text += error.Message;
                logText.Select(logText.Text.Length, 0);
                logText.ScrollToCaret();
                return;
            }
            drawInit(cache0.lineLength(), cacheSize);

            int loop;
            if (!int.TryParse(instructionText.Text, out loop))
            {
                ShowToolTip(instructionText, "루프 수를 입력하세요");
                return;
            }

            double locality = (double)locTrack.Value / 10;

            logText.Text += string.Format(
                "Simulation Start({0})\r\n", t);
            logText.Select(logText.Text.Length, 0);
            logText.ScrollToCaret();
            button1.Enabled = false;
            button2.Enabled = true;
            button2.Visible = true;

            double totalTime = 0;
            if (verbose)
            {
                interrupt = false;
                new Thread(new ThreadStart(
                    delegate ()
                    {
                        AddrInfo prev = null;
                        for (int i = 0; i < loop && !interrupt; i++)
                        {
                            AddrInfo addrInfo = cache0.Load(locality);
                            totalTime += addrInfo.time;
                            Brush brush;
                            switch (addrInfo.state)
                            {
                                case "hit":
                                    brush = Brushes.LawnGreen;
                                    break;
                                case "compulsory":
                                    brush = Brushes.AliceBlue;
                                    break;
                                case "conflict":
                                    brush = Brushes.Red;
                                    break;
                                case "capacity":
                                    brush = Brushes.Red;
                                    break;
                                default:
                                    brush = Brushes.White;
                                    break;
                            }
                            drawState(Brushes.AliceBlue, cache0.lineLength(),
                                cacheSize, prev, setSize);
                            drawState(brush, cache0.lineLength(),
                                cacheSize, addrInfo, setSize);
                            prev = addrInfo;
                            Thread.Sleep(100);
                        }//End of for

                        writeLog(cache0, totalTime);
                    }
                )).Start();
            }
            else
            {
                totalTime = cache0.Load(locality, loop).time;
                writeLog(cache0, totalTime);
            }

        }

        private void writeLog(Cache cache, double totalTime)
        {
            if (logText.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    logText.Text += string.Format(
                        "hit\t\t: {1}\r\n" +
                        "compulsory\t: {2}\r\n" +
                        "conflict\t\t: {3}\r\n" +
                        "capacity\t\t: {4}\r\n" +
                        "Simulation End\r\n" +
                        "elapsed time : {0}ms\r\n\r\n",
                        totalTime, cache.hitCount,
                        cache.compulsory, cache.conflict, cache.capacity);
                    logText.Select(logText.Text.Length, 0);
                    logText.ScrollToCaret();

                    button1.Enabled = true;
                    button2.Visible = false;
                }));
            }
            else
            {
                logText.Text += string.Format(
                        "hit\t\t: {1}\r\n" +
                        "compulsory\t: {2}\r\n" +
                        "conflict\t\t: {3}\r\n" +
                        "capacity\t\t: {4}\r\n" +
                        "Simulation End\r\n" +
                        "elapsed time : {0}ms\r\n\r\n",
                        totalTime, cache.hitCount,
                        cache.compulsory, cache.conflict, cache.capacity);
                logText.Select(logText.Text.Length, 0);
                logText.ScrollToCaret();

                button1.Enabled = true;
                button2.Visible = false;
            }
        }

        private void ShowToolTip(IWin32Window win, string msg)
        {
            if(win is TextBox)
            {
                ((TextBox)win).Focus();
            }
            ToolTip toolTip = new ToolTip();
            toolTip.Show(msg, win, 2000);
        }

        private void radio3_CheckedChanged(object sender, EventArgs e)
        {
            setText1.ReadOnly = !setText1.ReadOnly;
        }

        private void drawInit(uint lineLen, uint cacheSize)
        {
            float lineWidth = 2;
            Graphics g = viewPanel.CreateGraphics();
            Pen p = new Pen(Brushes.White, lineWidth);
            g.FillRectangle(Brushes.LightGray, 0, 0, viewPanel.Width, viewPanel.Height);
            g.DrawRectangle(p, 0,0,viewPanel.Width, viewPanel.Height);
            
            for(int i=1; i<lineLen; i++)
            {
                float y= i * viewPanel.Height / lineLen;
                g.DrawLine(p, 0, y, viewPanel.Width, y);
            }
        }

        private void drawState(Brush color, uint lineLen, uint cacheSize, AddrInfo addrInfo, uint setSize=1)
        {
            if (addrInfo == null) return;
            Graphics g = viewPanel.CreateGraphics();

            // 현재 정보를 그려줍니다.
            float y = addrInfo.loc * viewPanel.Height / lineLen;
            if (addrInfo is SetAddr)
            {
                y += ((SetAddr)addrInfo).set * viewPanel.Height / lineLen / setSize;
                g.FillRectangle(color, 0, y, viewPanel.Width, viewPanel.Height / lineLen / setSize);
            }
            else
            {
                g.FillRectangle(color, 0, y, viewPanel.Width, viewPanel.Height / lineLen);
            }
            g.DrawString(addrInfo.tag.ToString(), Font, Brushes.Black, 0, y);

            // 나머지 정보를 그려줍니다.
            g.DrawString("0KB", Font, Brushes.Black, viewPanel.Width - 8*3, 0);
            string size = (cacheSize / 1024).ToString() + "KB";
            g.DrawString(size, Font, Brushes.Black,
                viewPanel.Width - 8 * size.Length, viewPanel.Height - 10);
        }

        private void locTrack_Scroll(object sender, EventArgs e)
        {
            double locality = (double)locTrack.Value / 10;
            locLabel.Text = locality.ToString("F1");
        }

        private void label14_Click(object sender, EventArgs e)
        {
            verbose = !verbose;
            if (verbose)
            {
                label14.Text = "<";
                Width = 711;
            }
            else
            {
                label14.Text = ">";
                Width = 571;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            interrupt = true;
            button2.Enabled = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2019 동국대 허정원\r\n https://github.com/JWHer");
        }
    }
}
