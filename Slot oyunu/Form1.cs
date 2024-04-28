using System.Drawing;

namespace Slot_oyunu
{
    public partial class Form1 : Form
    {
        public static int[,] vals = new int[5, 3];
        public int i = 0, j = 0, k = 0, sayac = 0;
        public bool cikisYap = false;

        public int[] result_line_1 = new int[3];//[0] rakam deðeri first val, kiraz mý karpuz mu
        public int[] result_line_2 = new int[3];//[1] kaç sýra yaptý demek ama 1 fazla düþün örneðin 2 ise 3 sýra yaptý demek 
        public int[] result_line_3 = new int[3];//[2] rakam deðerine göre bet baþý kazanç örneðin kirazýn 3 lemesi xxx ödülü oluyo
        public int[] result_line_4 = new int[3];
        public int[] result_line_5 = new int[3];

        public int anaPara = 100;
        public int lastWin = 0;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void randomSayiGoster(int x, int y)
        {
            vals[x, y] = rnd.Next(1, 8);
            switch (x, y)
            {
                case (0, 0):
                    label_0x0.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_0x0, vals[x, y]);
                    break;
                case (0, 1):
                    label_0x1.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_0x1, vals[x, y]);
                    break;
                case (0, 2):
                    label_0x2.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_0x2, vals[x, y]);
                    break;

                case (1, 0):
                    label_1x0.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_1x0, vals[x, y]);

                    break;
                case (1, 1):
                    label_1x1.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_1x1, vals[x, y]);

                    break;
                case (1, 2):
                    label_1x2.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_1x2, vals[x, y]);

                    break;

                case (2, 0):
                    label_2x0.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_2x0, vals[x, y]);

                    break;
                case (2, 1):
                    label_2x1.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_2x1, vals[x, y]);

                    break;
                case (2, 2):
                    label_2x2.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_2x2, vals[x, y]);

                    break;

                case (3, 0):
                    label_3x0.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_3x0, vals[x, y]);
                    break;
                case (3, 1):
                    label_3x1.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_3x1, vals[x, y]);
                    break;
                case (3, 2):
                    label_3x2.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_3x2, vals[x, y]);
                    break;

                case (4, 0):
                    label_4x0.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_4x0, vals[x, y]);
                    break;
                case (4, 1):
                    label_4x1.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_4x1, vals[x, y]);
                    break;
                case (4, 2):
                    label_4x2.Text = vals[x, y].ToString();
                    change_picturebox(pictureBox_4x2, vals[x, y]);
                    break;

            }

        }
        public void change_picturebox(PictureBox pictureBox, int val)
        {
            switch (val)
            {
                case 1:
                    pictureBox.Image = Slot_oyunu.Properties.Resources._1;
                    break;
                case 2:
                    pictureBox.Image = Slot_oyunu.Properties.Resources._2;
                    break;
                case 3:
                    pictureBox.Image = Slot_oyunu.Properties.Resources._3;
                    break;
                case 4:
                    pictureBox.Image = Slot_oyunu.Properties.Resources._4;
                    break;
                case 5:
                    pictureBox.Image = Slot_oyunu.Properties.Resources._5;
                    break;
                case 6:
                    pictureBox.Image = Slot_oyunu.Properties.Resources._6;
                    break;
                case 7:
                    pictureBox.Image = Slot_oyunu.Properties.Resources._7;
                    break;
                case 8:
                    pictureBox.Image = Slot_oyunu.Properties.Resources._8;
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                anaPara--;
                label_ana_para.Text = anaPara.ToString();
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayac > 2)
            {
                sayac = 0;
                j++;
            }
            if (j > 2)
            {
                j = 0;
                i++;
            }
            if (i > 4)
            {
                cikisYap = true;
            }

            sayac++;

            if (!cikisYap)
            {
                randomSayiGoster(i, j);
            }


            if (cikisYap)
            {
                cikisYap = false;
                sayac = 0;
                i = 0;
                j = 0;
                timer1.Enabled = false;

                result_line_1 = line_1_result();
                result_line_2 = line_2_result();
                result_line_3 = line_3_result();
                result_line_4 = line_4_result();
                result_line_5 = line_5_result();

                /*
                label_line1.Text = "Line 1 Result: " + result_line_1[1] + " Kuvvet: " + result_line_1[0] + "  ödül: " + result_line_1[2].ToString();
                label_line2.Text = "Line 2 Result: " + result_line_2[1] + " Kuvvet: " + result_line_2[0] + "  ödül: " + result_line_2[2].ToString();
                label_line3.Text = "Line 3 Result: " + result_line_3[1] + " Kuvvet: " + result_line_3[0] + "  ödül: " + result_line_3[2].ToString();
                label_line4.Text = "Line 4 Result: " + result_line_4[1] + " Kuvvet: " + result_line_4[0] + "  ödül: " + result_line_4[2].ToString();
                label_line5.Text = "Line 5 Result: " + result_line_5[1] + " Kuvvet: " + result_line_5[0] + "  ödül: " + result_line_5[2].ToString();
                */

                label_line1.Text = "Line 1 : " +  result_line_1[2].ToString() + " TRY";
                label_line2.Text = "Line 2 : " +  result_line_2[2].ToString() + " TRY";
                label_line3.Text = "Line 3 : " +  result_line_3[2].ToString() + " TRY";
                label_line4.Text = "Line 4 : " +  result_line_4[2].ToString() + " TRY";
                label_line5.Text = "Line 5 : " +  result_line_5[2].ToString() + " TRY";




                lastWin = result_line_1[2] + result_line_2[2] + result_line_3[2] + result_line_4[2] + result_line_5[2];
                anaPara += lastWin;
                label_last_win.Text=lastWin.ToString() + " TRY";
                label_ana_para.Text = anaPara.ToString() + "TRY";
            }
        }

        public int[] line_1_result()
        {
            int point = 0;
            int first_val = vals[0, 0];



            if (point == 0 && first_val == vals[1, 0])
            {
                point++;
                if (point == 1 && first_val == vals[2, 0])
                {
                    point++;
                    if (point == 2 && first_val == vals[3, 0])
                    {
                        point++;
                        if (point == 3 && first_val == vals[4, 0])
                        {
                            point++;
                        }
                    }
                }
            }

            #region puan hesaplama
            /*kuvvet gücü ve isimlendirme
             * yani first val:
             * ödüller 5 dazzling ile ayný
             * 1:kiraz
             * 2:portakal
             * 3:kayýsý
             * 4:limon
             * 5:karpuz
             * 6:üzüm
             * 7:yedi
             * 8:yýldýz
             */
            #endregion
            int kac_adet_sira_yapti = point;
            int kuvvet = first_val;
            int odul = 0;

            odul = odul_hesap(kac_adet_sira_yapti, kuvvet);

            int[] result = new int[3];
            result[0] = first_val;
            result[1] = point;
            result[2] = odul;
            /*
             * first val gelen verinin kuvvetini gösteriyor yani karpuz mu üzümmü geldi
             * point kaç adet eþleþti
             * 
             * point 1 ise 2 deðer eþleþti
             * point 2 ise 3 deðer eþleþti
             * ...   3 ise 4 deðer eþleþti
             * ...   4 ise 5 deðer eþleþti
             */
            return result;
        }
        public int[] line_2_result()
        {
            int point = 0;
            int first_val = vals[0, 1];

            if (point == 0 && first_val == vals[1, 1])
            {
                point++;
                if (point == 1 && first_val == vals[2, 1])
                {
                    point++;
                    if (point == 2 && first_val == vals[3, 1])
                    {
                        point++;
                        if (point == 3 && first_val == vals[4, 1])
                        {
                            point++;
                        }
                    }
                }
            }
            #region puan hesaplama
            /*kuvvet gücü ve isimlendirme
             * yani first val:
             * ödüller 5 dazzling ile ayný
             * 1:kiraz
             * 2:portakal
             * 3:kayýsý
             * 4:limon
             * 5:karpuz
             * 6:üzüm
             * 7:yedi
             * 8:yýldýz
             */
            #endregion
            int kac_adet_sira_yapti = point;
            int kuvvet = first_val;
            int odul = 0;

            odul = odul_hesap(kac_adet_sira_yapti, kuvvet);

            int[] result = new int[3];
            result[0] = first_val;
            result[1] = point;
            result[2] = odul;
            /*
             * point 2 ise 3 deðer eþleþti
             * ...   3 ise 4 deðer eþleþti
             * ...   4 ise 5 deðer eþleþti
             */
            return result;
        }
        public int[] line_3_result()
        {
            int point = 0;
            int first_val = vals[0, 2];

            if (point == 0 && first_val == vals[1, 2])
            {
                point++;
                if (point == 1 && first_val == vals[2, 2])
                {
                    point++;
                    if (point == 2 && first_val == vals[3, 2])
                    {
                        point++;
                        if (point == 3 && first_val == vals[4, 2])
                        {
                            point++;
                        }
                    }
                }
            }
            #region puan hesaplama
            /*kuvvet gücü ve isimlendirme
             * yani first val:
             * ödüller 5 dazzling ile ayný
             * 1:kiraz
             * 2:portakal
             * 3:kayýsý
             * 4:limon
             * 5:karpuz
             * 6:üzüm
             * 7:yedi
             * 8:yýldýz
             */
            #endregion
            int kac_adet_sira_yapti = point;
            int kuvvet = first_val;
            int odul = 0;

            odul = odul_hesap(kac_adet_sira_yapti, kuvvet);

            int[] result = new int[3];
            result[0] = first_val;
            result[1] = point;
            result[2] = odul;
            /*
             * point 2 ise 3 deðer eþleþti
             * ...   3 ise 4 deðer eþleþti
             * ...   4 ise 5 deðer eþleþti
             */
            return result;
        }
        public int[] line_4_result()
        {
            int point = 0;
            int first_val = vals[0, 0];

            if (point == 0 && first_val == vals[1, 1])
            {
                point++;
                if (point == 1 && first_val == vals[2, 2])
                {
                    point++;
                    if (point == 2 && first_val == vals[3, 1])
                    {
                        point++;
                        if (point == 3 && first_val == vals[4, 0])
                        {
                            point++;
                        }
                    }
                }
            }
            #region puan hesaplama
            /*kuvvet gücü ve isimlendirme
             * yani first val:
             * ödüller 5 dazzling ile ayný
             * 1:kiraz
             * 2:portakal
             * 3:kayýsý
             * 4:limon
             * 5:karpuz
             * 6:üzüm
             * 7:yedi
             * 8:yýldýz
             */
            #endregion
            int kac_adet_sira_yapti = point;
            int kuvvet = first_val;
            int odul = 0;

            odul = odul_hesap(kac_adet_sira_yapti, kuvvet);

            int[] result = new int[3];
            result[0] = first_val;
            result[1] = point;
            result[2] = odul;
            /*
             * point 2 ise 3 deðer eþleþti
             * ...   3 ise 4 deðer eþleþti
             * ...   4 ise 5 deðer eþleþti
             */
            return result;
        }
        public int[] line_5_result()
        {
            int point = 0;
            int first_val = vals[0, 2];

            if (point == 0 && first_val == vals[1, 1])
            {
                point++;
                if (point == 1 && first_val == vals[2, 0])
                {
                    point++;
                    if (point == 2 && first_val == vals[3, 1])
                    {
                        point++;
                        if (point == 3 && first_val == vals[4, 2])
                        {
                            point++;
                        }
                    }
                }
            }
            #region puan hesaplama
            /*kuvvet gücü ve isimlendirme
             * yani first val:
             * ödüller 5 dazzling ile ayný
             * 1:kiraz
             * 2:portakal
             * 3:kayýsý
             * 4:limon
             * 5:karpuz
             * 6:üzüm
             * 7:yedi
             * 8:yýldýz
             */
            #endregion
            int kac_adet_sira_yapti = point;
            int kuvvet = first_val;
            int odul = 0;

            odul = odul_hesap(kac_adet_sira_yapti, kuvvet);

            int[] result = new int[3];
            result[0] = first_val;
            result[1] = point;
            result[2] = odul;
            /*
             * point 2 ise 3 deðer eþleþti
             * ...   3 ise 4 deðer eþleþti
             * ...   4 ise 5 deðer eþleþti
             */
            return result;
        }

        public int odul_hesap(int kac_adet_sira_yapti, int kuvvet)
        {

            #region puan hesaplama
            /*kuvvet gücü ve isimlendirme
             * yani first val:
             * ödüller 5 dazzling ile ayný
             * 1:kiraz
             * 2:portakal
             * 3:kayýsý
             * 4:limon
             * 5:karpuz
             * 6:üzüm
             * 7:yedi
             * 8:yýldýz
             */

            int odul = 0;
            switch (kac_adet_sira_yapti, kuvvet)
            {
                #region kiraz puan

                case (1, 1):
                    odul = 1;
                    break;
                case (2, 1):
                    odul = 4;
                    break;
                case (3, 1):
                    odul = 10;
                    break;
                case (4, 1):
                    odul = 40;
                    break;

                    #endregion

                    #region portakal

                    break;
                case (2, 2):
                    odul = 4;
                    break;
                case (3, 2):
                    odul = 10;
                    break;
                case (4, 2):
                    odul = 40;
                    break;
                    #endregion
                    #region kayýsý

                    break;
                case (2, 3):
                    odul = 4;
                    break;
                case (3, 3):
                    odul = 10;
                    break;
                case (4, 3):
                    odul = 40;
                    break;
                    #endregion
                    #region limon

                    break;
                case (2, 4):
                    odul = 4;
                    break;
                case (3, 4):
                    odul = 10;
                    break;
                case (4, 4):
                    odul = 40;
                    break;
                    #endregion

                    #region karpuz

                    break;
                case (2, 5):
                    odul = 10;
                    break;
                case (3, 5):
                    odul = 40;
                    break;
                case (4, 5):
                    odul = 100;
                    break;
                #endregion
                #region üzüm


                case (2, 6):
                    odul = 10;
                    break;
                case (3, 6):
                    odul = 40;
                    break;
                case (4, 6):
                    odul = 100;
                    break;
                #endregion

                #region yedi


                case (2, 7):
                    odul = 20;
                    break;
                case (3, 7):
                    odul = 200;
                    break;
                case (4, 7):
                    odul = 1000;
                    break;
                #endregion
                #region yýldýz


                case (2, 8):
                    odul = 2;
                    break;
                case (3, 8):
                    odul = 10;
                    break;
                case (4, 8):
                    odul = 50;
                    break;
                #endregion



                default:
                    odul = 0;
                    break;
            }
            #endregion



            return odul;
        }

        private void pictureBox_0x1_Click(object sender, EventArgs e)
        {

        }

        private void button_x1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 150;
            label1.Text = "CHANGE SPEED: 1X";
        }

        private void button_x3_Click(object sender, EventArgs e)
        {
            timer1.Interval = 50;
            label1.Text = "CHANGE SPEED: 3X";
        }

        private void button_x5_Click(object sender, EventArgs e)
        {
            timer1.Interval = 30;
            label1.Text = "CHANGE SPEED: 5X";
        }

        private void button_x10_Click(object sender, EventArgs e)
        {
            timer1.Interval = 15;
            label1.Text = "CHANGE SPEED: 10X";
        }
    }
}
