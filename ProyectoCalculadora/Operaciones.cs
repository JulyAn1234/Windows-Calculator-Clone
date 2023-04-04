using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCalculadora
{
    class Operaciones
    {
        public Operaciones()
        {

        }

        public string Suma(double numero1, double numero2)
        {
            return (numero1 + numero2).ToString();
        }

        public string Resta(double numero1, double numero2)
        {
            return (numero1 - numero2).ToString();
        }
        public string Multiplicacion(double numero1, double numero2)
        {
            return (numero1 * numero2).ToString();
        }
        public string Division(double numero1, double numero2)
        {
            if (numero2 != 0)
            {
                return (numero1 / numero2).ToString();
            }
            else
            {
                return "Math Error";
            }
        }
        public string Cuadrado(double numero1)
        {
            return (Math.Pow(numero1, 2)).ToString();
        }

        public string Raiz(double numero1)
        {
            if (numero1 >= 0)
            {
                return (Math.Sqrt(numero1)).ToString();
            }
            else
            {
                return "Math Error";
            }
            
        }
    }
}
