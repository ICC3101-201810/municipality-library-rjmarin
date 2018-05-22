using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Reflection;


namespace Lab10
{
    class Program
    {
        // BONUS1
        // address con person se produce un ciclo que ya que estas clases se tiene entre si como atributo
        // tipo fecha 2009-05-08 14:40:52,531
        // este progrma corre porque no edita sobre el address de la persona sino que de una adress x al igual que la persona con sus padres y si  pido direccion de una persona para editar   no me dejaria usarla por que en person la adress es private y viceversa 
        static void Main(string[] args)
        {
            DateTime date = new DateTime(1997, 9, 9);
            ClassLibrary1.Person person = new Person("rai","marlyn",date,null,"1267889", null, null);
            // el alma mater no esta en el constructor yes solo lectura, no se puede escribir al igual que 

            Type Typeperson = person.GetType();
            ClassLibrary1.Address address = new Address("las tarrias",345, "longii","santiasco",person,2015,10,10,true,true);
            Type TypeAdress = address.GetType();
            ClassLibrary1.Car car = new Car("lambo","murchielago",1,person,"J01NT",4,true);
            Type Typecar = car.GetType();
            List<Person> personas = new List<Person>();
            personas.Add(person);
            Console.WriteLine("REGISTRO CIVIL");
            string opcion;
            bool boliano = true;
            Console.WriteLine("porfavor de registrarse");
            Console.WriteLine("nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("apellido:");
            string apelli = Console.ReadLine();
            Console.WriteLine("rut:");
            string rut = Console.ReadLine();
            Console.WriteLine("nacimiento:");
            string nacimineto = Console.ReadLine();
            DateTime date1 = DateTime.ParseExact(nacimineto, "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            Person personilla = new Person(nombre, apelli, date1, address, rut, null, null);
            personas.Add(personilla);
            List<Address> direcciones = new List<Address>();
            List<Car> autos = new List<Car>();
            while (boliano)
            {
                Console.WriteLine("Ingrese opcion\n (1)registrar vehiculo a tu nombre\n (2)registro de persona\n (3)registrar direccion\n ");
                opcion= Console.ReadLine();
                if (opcion == "1")
                {
                    Console.WriteLine("opcion\n (1) registrar vehiculo\n (2) pasar auto a otra persona ");
                    string opcc = Console.ReadLine();
                    if (opcc == "1")
                    {
                        Console.WriteLine("marca:");
                        string mar = Console.ReadLine();
                        Console.WriteLine("modelo:");
                        string model = Console.ReadLine();
                        Console.WriteLine("año:");
                        int año = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("patente:");
                        string petente = Console.ReadLine();
                        Console.WriteLine("cinturones");
                        int cint = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("diesel (1)SI  (2)NO");
                        string dis = Console.ReadLine();
                        bool diss;
                        if (dis=="1")
                        {
                            diss = true;
                        }
                        else
                        {
                            diss = false;
                        }
                        Car c = new Car(mar, model,año,personilla,petente,cint,diss);
                        autos.Add(c);
                    }
                    else if (opcc == "2")
                    {
                        Console.WriteLine(" a quien desea pasarle el auto");
                        foreach (Person item in personas)
                        {
                            Console.WriteLine(item.First_name + " " + item.Last_name + " \n");
                        }
                        Console.WriteLine("ingrese nombre de la persona");
                        string nombrin = Console.ReadLine();
                        Console.WriteLine("ingrese apellido de la persona");
                        string ep = Console.ReadLine();
                        foreach (Person item in personas)
                        {
                            if (item.Last_name == ep && item.First_name == nombrin)
                            {
                                car.giveUpOwnershipToThirdParty(item);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("opcion incorrecta");
                    }
                    

                }
                else if (opcion == "2")
                {
                    
                    Console.WriteLine("opciones\n (1) Cambiar nombre \n(2) cambiar apellido\n (3) abandonado \n(4) adoptado\n (5) regalar pertennencias\n (6) registrar persona\n (7) agregar profesion");
                    string opcionn=Console.ReadLine();
                    if (opcionn=="1")
                    {
                        Console.WriteLine("ingrese nuevo nombre:");
                        string newname = Console.ReadLine();
                        personilla.changeFirstName(newname);
                    }
                    else if (opcionn=="2")
                    {
                        Console.WriteLine("ingrese nuevo nombre:");
                        string newname = Console.ReadLine();
                        personilla.changeLastName(newname);
                    }
                    else if (opcionn == "3")
                    {
                        Console.WriteLine("fuiste abandonado");
                        personilla.getAbandoned();
                    }
                    else if (opcionn == "4")
                    {
                        
                        Console.WriteLine("ers un niño adoptado adoptado");
                        personilla.getAdopted(person);
                    }
                    else if (opcionn == "5")
                    {
                        
                        foreach (Person item in personas)
                        {
                            Console.WriteLine(item.First_name + " " + item.Last_name + " \n");
                        }
                        Console.WriteLine("ingrese nombre de la persona");
                        string nombrin=Console.ReadLine();
                        Console.WriteLine("ingrese apellido de la persona");
                        string ep = Console.ReadLine();
                        foreach (Person item in personas)
                        {
                            if (item.Last_name == ep && item.First_name== nombrin)
                            {
                                person.giveUpOwnershipToThirdParty(item);
                            }
                        }

                        
                    }
                    else if (opcionn =="6")
                    {
                        Console.WriteLine("porfavor de registrar persona ");
                        Console.WriteLine("nombre:");
                        string nombre1 = Console.ReadLine();
                        Console.WriteLine("apellido:");
                        string apellid = Console.ReadLine();
                        Console.WriteLine("rut:");
                        string rutt = Console.ReadLine();
                        Console.WriteLine("nacimiento:");
                        string nacimiento = Console.ReadLine();
                        DateTime date11 = DateTime.ParseExact(nacimineto, "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                        Person pers = new Person(nombre1, apellid, date11, null, rutt, personilla, null);
                        personas.Add(pers);
                    }
                    else if (opcionn == "7")
                    {
                        Console.WriteLine("alma mater:");
                        string alma = Console.ReadLine();
                        Console.WriteLine("profesion:");
                        string proff = Console.ReadLine();
                        personilla.setEducation(alma, proff);
                    }
                    else
                    {
                        Console.WriteLine("opcion incorrecta");
                    }
                    
            
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("opcion\n (1)agregar casa\n (2)dar propieda a otra persona (3)agregar baño (4) agregar pieza ");
                    string op = Console.ReadLine();
                    if (op=="1")
                    {
                        
                        Console.WriteLine("calle:");
                        string calle = Console.ReadLine();
                        Console.WriteLine("comuna:");
                        string comuna = Console.ReadLine();
                        Console.WriteLine("ciudad:");
                        string city = Console.ReadLine();
                        Console.WriteLine("numero de la casa:");
                        int num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("año de construccion:");
                        int año = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("piezas:");
                        int pi = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("baños:");
                        int baño = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("tiene jardin (1)SI (2)NO");
                        string j = Console.ReadLine();
                        bool jardin;
                        if (j == "1")
                        {
                            jardin = true;
                        }
                        else
                        {
                            jardin = false;
                        }
                        Console.WriteLine("tiene pisina (1)SI (2)NO");
                        string pis = Console.ReadLine();
                        bool piss;
                        if (pis == "1")
                        {
                            piss = true;
                        }
                        else
                        {
                            piss = false;
                        }


                        Address a = new Address(calle,num,comuna,city,personilla,año,pi,baño,jardin,piss);
                        direcciones.Add(a);
                        
                    }
                    else if (op=="2")
                    {
                        foreach (Person item in personas)
                        {
                            Console.WriteLine(item.First_name + " " + item.Last_name + " \n");
                        }
                        Console.WriteLine("ingrese nombre de la persona");
                        string nombrin = Console.ReadLine();
                        Console.WriteLine("ingrese apellido de la persona");
                        string ep = Console.ReadLine();
                        foreach (Person item in personas)
                        {
                            if (item.Last_name == ep && item.First_name == nombrin)
                            {
                                address.changeOwner(item);
                            }
                        }
                    }
                    else if (op == "3")
                    {
                        Console.WriteLine("cuantas pieza desea agregar");
                        int cint = Convert.ToInt32(Console.ReadLine());
                        address.addBeedrooms(cint);

                    }
                    else if (op == "4")
                    {
                        Console.WriteLine("cuantas pieza desea agregar");
                        int cint = Convert.ToInt32(Console.ReadLine());
                        address.addBathrooms(cint);
                    }
                    else {
                        Console.WriteLine("opcion incorrecta");
                    }
                }
                else 
                {
                    Console.WriteLine("numero incorrecto ingrese denuevo");
                }

            }

          
           
        }
    }
}
