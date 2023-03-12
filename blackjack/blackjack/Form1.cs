using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace blackjack
{
    public partial class Form1 : Form
    {
        //pontok
        int keresszam = 0, jatekospont = 0, osztopont = 0;

        //tet & ossz pont
        double tet, keret;
        bool vaneredmeny = false;

        //leosztott & kert lap
        int[] leosztas = new int[8];
        int[] pluszlap = new int[2];


        feltoltes osztottkartyak = new feltoltes();
        osztas laposztas = new osztas();
        pontszamok pontellenor = new pontszamok();

        public Form1()
        {

            InitializeComponent();
            //kezdo pont(osszes)
            label5.Text = "1000";

            //jatekter beallitas
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            button1.Enabled = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;






        }

        //tet megadasa kezdeshez kotelezo
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        //tet duplazas
        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            keret = keret - tet;
            label5.Text = Convert.ToString(keret);
            tet = tet * 2;
            textBox1.Text = tet.ToString();
            button2_Click(sender, e);//elindítja button2-at
            if (vaneredmeny==false)
            {
                button3_Click(sender, e);//elindítja button3-at

            }

        }
        //mentes
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog1.FileName;
            File.WriteAllText(fileName, label5.Text);

        }

        //mentheto formatumok
        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|CSV (*.csv)|*.csv|All files (*.*)|*.*";

            saveFileDialog1.ShowDialog();
        }


        //mentes betoltese
        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            string tartalom;
            tartalom= File.ReadAllText(fileName);
            label5.Text = tartalom;
        }

        //megallok
        private void button3_Click(object sender, EventArgs e)
        {
            bool osztohuz = false;//ellenőrzi hogy voltunk a while ciklusban
            bool osztonyer = false;//osztó húzás nélkül nyer
            int huzott = 0;
            button3.Enabled = false;
            pictureBox7.Image = Image.FromFile("kartyalapok/" + leosztas[7] + ".png");
            osztopont = osztopont + leosztas[6];
            label4.Text=(Convert.ToString(osztopont));
            if (osztopont>jatekospont)
            {
                MessageBox.Show("Vesztettél.");
                textBox1.Text = "";
                osztonyer = true;
            }
            //oszto huz lapot & eredmeny hirdetes
            while (osztopont<17 && osztonyer==false)
            {
                huzott++;
                osztohuz = true;
                
                switch (huzott)
                {
                    case 1: pluszlap = laposztas.lapkeres();
                        pictureBox8.Visible = true;
                        pictureBox8.Image = Image.FromFile("kartyalapok/" + pluszlap[1] + ".png");
                        osztopont = osztopont + pluszlap[0];
                        label4.Text = Convert.ToString(osztopont);
                        if (osztopont>jatekospont && osztopont<22)
                        {
                            MessageBox.Show("Vesztettél.");
                            textBox1.Text = "";

                        }
                        if (osztopont==jatekospont)
                        {
                            keret = keret + tet;
                            label5.Text = Convert.ToString(keret);
                            MessageBox.Show("Visszakaptad a pénzed");


                        }
                        if (jatekospont>osztopont && osztopont>16 || osztopont>21)
                        {
                            MessageBox.Show("Nyertél!!");
                            tet = tet * 1.5;
                            keret = keret + tet;
                            label5.Text = Convert.ToString(keret);

                        }
                        break;
                    case 2:
                        pluszlap = laposztas.lapkeres();
                        pictureBox9.Visible = true;
                        pictureBox9.Image = Image.FromFile("kartyalapok/" + pluszlap[1] + ".png");
                        osztopont = osztopont + pluszlap[0];
                        label4.Text = Convert.ToString(osztopont);
                        if (osztopont > jatekospont && osztopont < 22)
                        {
                            MessageBox.Show("Vesztettél.");
                            textBox1.Text = "";

                        }
                        if (osztopont == jatekospont)
                        {
                            keret = keret + tet;
                            label5.Text = Convert.ToString(keret);
                            MessageBox.Show("Visszakaptad a pénzed");



                        }
                        if (jatekospont > osztopont && osztopont > 16 || osztopont > 21)
                        {
                            MessageBox.Show("Nyertél!!");
                            tet = tet * 1.5;
                            keret = keret + tet;
                            label5.Text = Convert.ToString(keret);

                        }
                        break;
                    case 3:
                        pluszlap = laposztas.lapkeres();
                        pictureBox10.Visible = true;
                        pictureBox10.Image = Image.FromFile("kartyalapok/" + pluszlap[1] + ".png");
                        osztopont = osztopont + pluszlap[0];
                        label4.Text = Convert.ToString(osztopont);
                        if (osztopont > jatekospont && osztopont < 22)
                        {
                            MessageBox.Show("Vesztettél.");
                            textBox1.Text = "";

                        }
                        if (osztopont == jatekospont)
                        {
                            keret = keret + tet;
                            label5.Text = Convert.ToString(keret);
                            MessageBox.Show("Visszakaptad a pénzed");


                        }
                        if (jatekospont > osztopont && osztopont > 16 || osztopont > 21)
                        {
                            MessageBox.Show("Nyertél!!");
                            tet = tet * 1.5;
                            keret = keret + tet;
                            label5.Text = Convert.ToString(keret);

                        }
                        break;

                }
                if (jatekospont<osztopont)
                {
                    break;
                }

            }

            if (osztopont<jatekospont && osztohuz==false || osztopont > 21 && osztohuz == false && osztonyer==false)
            {
                MessageBox.Show("Nyertél!");
                tet = tet * 1.5;
                keret = keret + tet;
                label5.Text = Convert.ToString(keret);

            }
            if (osztopont == jatekospont && osztohuz == false)
            {
                MessageBox.Show("Visszakaptad a penzed");
                keret = keret + tet;
                label5.Text = Convert.ToString(keret);

            }
            if (osztopont > jatekospont && osztohuz == false && osztonyer == false)
            {
                MessageBox.Show("Vesztettél!");

                label5.Text = Convert.ToString(keret);
                textBox1.Text = "";

            }

            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            
        }
        //kezdes
        private void button1_Click(object sender, EventArgs e)
        {
            vaneredmeny = false;

            try
            {

                //tet ellenor
                if (Convert.ToDouble(textBox1.Text) > Convert.ToInt32(label5.Text))
                {
                     MessageBox.Show("Nincs ennyi pénzed!!!");
                }
                else
                {
                    //jatekter beallitas jatek indulaskor
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox8.Visible = false;
                    pictureBox9.Visible = false;
                    pictureBox10.Visible = false;
                    keresszam = 0;
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;

                    //int osztoelso, osztomasodik, sorsoltlap;
                    tet =Convert.ToDouble(textBox1.Text);
                    keret = Convert.ToDouble(label5.Text)-tet;
                    label5.Text = Convert.ToString(keret);
                    if (keret<tet)
                    {
                        button4.Enabled = false;
                    }

                    leosztas = laposztas.elsolapok(osztottkartyak.lapok());
                    //osztott lapok megjelenitese
                    pictureBox1.Image = Image.FromFile("kartyalapok/" + leosztas[1] + ".png");
                    pictureBox1.Visible = true;

                    pictureBox2.Image = Image.FromFile("kartyalapok/" + leosztas[3] + ".png");
                    pictureBox2.Visible = true;

                    pictureBox6.Image = Image.FromFile("kartyalapok/" + leosztas[5] + ".png");
                    pictureBox6.Visible = true;

                    pictureBox7.Image = Image.FromFile("kartyalapok/" + "hatlap.png");
                    pictureBox7.Visible = true;

                    jatekospont = leosztas[0] + leosztas[2];
                    label3.Text = Convert.ToString(jatekospont);

                    osztopont = leosztas[4];// + leosztas[6];
                    label4.Text = Convert.ToString(osztopont);



                    if (jatekospont==21)
                    {
                        keret = tet * 2 + keret;
                        MessageBox.Show("BlackJack");
                        label5.Text =Convert.ToString(keret);
                        button1.Enabled = true;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;

                    }
                }

            }
            catch (Exception)
            {

                MessageBox.Show($"Nem adott meg megfelelő tétet.");
            }

           

        }

        //lap keres
        private void button2_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;

            //hany lapot huzott
            keresszam++;

            bool tovabbmehet;
            pluszlap=laposztas.lapkeres();
            switch (keresszam)
            {
                //huzas utan ellenor hogy nyert, vesztett, vagy mehet tovabb
                case 1: pictureBox3.Visible = true;
                    pictureBox3.Image = Image.FromFile("kartyalapok/" + pluszlap[1] + ".png");
                    if (jatekospont > 10 && pluszlap[0] == 11)
                    {
                        pluszlap[0] = 1;
                    }
                    jatekospont = jatekospont + pluszlap[0];

                    label3.Text = Convert.ToString(jatekospont);
                    tovabbmehet = pontellenor.ellenor(jatekospont);
                    if (!tovabbmehet)
                    {
                        vaneredmeny = true;
                        MessageBox.Show("Vesztettél");
                        textBox1.Text = "";
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        keresszam = 0;
                    }
                    if (jatekospont == 21)
                    {
                        vaneredmeny = true;
                        MessageBox.Show("Nyertél");
                        tet = tet + 1.5;
                        keret = tet + keret;
                        
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        keresszam = 0;
                        label5.Text = Convert.ToString(keret);


                    }
                    break;
                case 2:pictureBox4.Visible = true;
                    pictureBox4.Image = Image.FromFile("kartyalapok/" + pluszlap[1] + ".png");
                    if (jatekospont > 10 && pluszlap[0] == 11)
                    {
                        pluszlap[0] = 1;
                    }
                    jatekospont = jatekospont + pluszlap[0];
 
                    label3.Text = Convert.ToString(jatekospont);
                    tovabbmehet = pontellenor.ellenor(jatekospont);

                    if (!tovabbmehet)
                    {
                        
                        MessageBox.Show("Vesztettél");
                        textBox1.Text = "";
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        keresszam = 0;

                    }
                    if (jatekospont == 21)
                    {
                        MessageBox.Show("Nyertél");
                        tet = tet + 1.5;
                        keret = tet + keret;

                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        keresszam = 0;

                        label5.Text = Convert.ToString(keret);

                    }
                    break;
                case 3:pictureBox5.Visible = true;
                    pictureBox5.Image = Image.FromFile("kartyalapok/" + pluszlap[1] + ".png");
                    if (jatekospont > 10 && pluszlap[0] == 11)
                    {
                        pluszlap[0] = 1;
                    }
                    jatekospont = jatekospont + pluszlap[0];

                    label3.Text = Convert.ToString(jatekospont);
                    tovabbmehet = pontellenor.ellenor(jatekospont);
                    if (!tovabbmehet)
                    {
                       
                        MessageBox.Show("Vesztettél");
                        textBox1.Text = "";
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        keresszam = 0;

                    }
                    if (jatekospont == 21)
                    {
                        MessageBox.Show("Nyertél");
                        tet = tet + 1.5;
                        keret = tet + keret;

                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        keresszam = 0;
                        label5.Text = Convert.ToString(keret);


                    }
                    break;


                default:
                    break;
            }

        }

    }
}
