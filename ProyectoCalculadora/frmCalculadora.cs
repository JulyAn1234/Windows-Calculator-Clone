using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCalculadora
{
    public partial class frmCalculadora : Form
    {
        byte operador = 0;
        double ans = 0;
        bool State1 = true;
        bool State2 = true;
        Operaciones Ops = new Operaciones();
        
        public frmCalculadora()
        {
            InitializeComponent();
            string Path = System.IO.Directory.GetCurrentDirectory();

            btnBackspace.Image = Image.FromFile($"{Path}/src/Imagenes/Iconos/imgBackspace.png");
            btnRaiz.Image = Image.FromFile($"{Path}/src/Imagenes/Iconos/imgRaiz.png");
           // Icon = Icon.FromFile($"{Path}/src/Imagenes/Iconos/imgRaiz.png");
        }

        private void Operacion()
        {
            if (operador == 0) { }
            else if (operador == 1)
            {
                ans = Double.Parse(Ops.Suma(ans, Double.Parse(txtResultado.Text)));
            }
            else if (operador == 2)
            {
                ans = Double.Parse(Ops.Resta(ans, Double.Parse(txtResultado.Text)));
            }
            else if (operador == 3)
            {
                ans = Double.Parse(Ops.Multiplicacion(ans, Double.Parse(txtResultado.Text)));
            }
            else if (operador == 4)
            {
                string temp = Ops.Division(ans, Double.Parse(txtResultado.Text));
                if (temp != "Math Error")
                    ans = Double.Parse(temp);
                else
                    txtResultado.Text = temp;
            }
            else if (operador == 5)
            {
                ans = Double.Parse(Ops.Cuadrado(ans));
            }
            else if (operador == 6)
            {
                string temp = Ops.Raiz(ans);
                if (temp != "Math Error")
                    ans = Double.Parse(temp);
                else
                    txtResultado.Text = temp;
            }
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "")
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length-1);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            BtnNum("1");
        }

        private void btn2_Click(object sender, EventArgs e)

        {
            BtnNum("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            BtnNum("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            BtnNum("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            BtnNum("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            BtnNum("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            BtnNum("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            BtnNum("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            BtnNum("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            BtnNum("0");
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            BtnNum(".");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txtResultado.Text = "0";
            txtOperacion.Text = "";
            ans = 0;
            operador = 0;
            State1 = false; State2 = true;
        }
        private void btnDivition_Click(object sender, EventArgs e)
        {
            Operador(4, "/");
        }
        
        private void OperadorUnico(byte indice, string simbolo)
        {
            if (txtResultado.Text != "Math Error")
            {
                State2 = false;
                if (operador == 0)
                {
                    operador = indice;
                    ans = Double.Parse(txtResultado.Text);
                    if (indice == 5)
                        txtOperacion.Text = ans + simbolo;
                    else
                        txtOperacion.Text = simbolo + ans;
                    txtResultado.Text = ans.ToString();
                    State1 = true;
                    Equals();
                }
                else
                {
                    Operacion();
                    if (txtResultado.Text != "Math Error")
                    {
                        operador = indice;
                        txtOperacion.Text = ans + $" {simbolo}";
                        txtResultado.Text = ans.ToString();
                        State1 = true;
                        Equals();
                    }

                }
            }
            else
            {
                Clear();
            }
        }

        private void Operador(byte indice, string simbolo)
        {
            if(txtResultado.Text != "Math Error")
            {
                State2 = false;
                if (operador == 0)
                {
                    operador = indice;
                    ans = Double.Parse(txtResultado.Text);
                    txtOperacion.Text = ans + simbolo;
                    txtResultado.Text = ans.ToString();
                    State1 = true;
                }
                else
                {
                    Operacion();
                    if (txtResultado.Text != "Math Error")
                    {
                        operador = indice;
                        txtOperacion.Text = ans + $" {simbolo}";
                        txtResultado.Text = ans.ToString();
                        State1 = true;
                    }
                    
                }
            }
            else
            {
                Clear();
            }
            

        }
        private void BtnNum(string number)
        {
            if (txtResultado.Text != "Math Error")
            {
                if (State1)
                {
                    txtResultado.Text = "";
                    State1 = false;
                }
                txtResultado.Text = txtResultado.Text + number;
            }
            else
            {
                Clear();
            }
            
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            Equals();
        }

        private void Equals()
        {
            if (txtResultado.Text != "Math Error")
            {
                if (State2)
                {
                    ans = Double.Parse(txtResultado.Text);
                    txtOperacion.Text = $"{ans} =";
                }
                else
                {
                    Operacion();
                    if (txtResultado.Text != "Math Error")
                    {
                        if (operador != 5 && operador != 6)
                            txtOperacion.Text = $"{txtOperacion.Text} {txtResultado.Text} =";
                        else
                            txtOperacion.Text = $"{txtOperacion.Text} ="; ;
                        operador = 0;
                        txtResultado.Text = ans.ToString();
                        State2 = true;
                    }
                    else
                    {
                        txtOperacion.Text = $"{txtOperacion.Text} {"0"} =";
                    }
                }

                State1 = true;
            }
            else
            {
                Clear();
            }

        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            Operador(3, "*");
        }

        private void btnSubs_Click(object sender, EventArgs e)
        {
            Operador(2, "-");
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            Operador(1, "+");
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            OperadorUnico(5, "^2");
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            OperadorUnico(6, "√");
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
