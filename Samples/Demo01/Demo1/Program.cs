using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    public class Persona
    {
        protected virtual string Saluto
        //protected string Saluto
        {
            get { return "Ciao sono una persona!"; }
        }

        public void Saluta()
        {
            Console.WriteLine(this.Saluto);
        }
        public virtual void Cammina()
        //public void Cammina()
        {
            Console.WriteLine("Sto camminando....");
        }
    }

    public class Studente : Persona
    {
        public string NumeroMatricola { get; set; }

        protected override string Saluto
        //protected new string Saluto
        {
            get { return "Ciao sono uno studente!"; }
        }

        //public new void Cammina()
        public override void Cammina()
        {
            Console.WriteLine("Sto correndo....");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona();
            p.Saluta();
            p.Cammina();

            Studente s = new Studente();
            s.Saluta();
            s.Cammina();
            
            Persona p1 = (Persona)s;
            p1.Saluta();
            p1.Cammina();

            Console.ReadKey();
            
        }
    }
    
}
