using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Validation // Girilen üç input için validasyonlar belirledim
    {
        public bool isFirstInputValid(string input) // ilkinde iki ayrı değer alacağı için arada boşluk olmalı
        {
            if (!input.Contains(' '))
            {
                throw new Exception("Invalid Input");

            }
            else
            {
                return true;
            }


        }
        public bool isSecondInputValid(string []arr) // ikinci input main de boşluğa göre split edildikten sonra validasyon için bu fonksiyon çağrılıyor.
        {                                           // eğer arrayin boyutu üç değilse invalid.

            if (arr.Length != 3)
            {
                throw new Exception("Invalid Input");

            }
            else
            {
                return true;
            }


        }
        public bool isThirdInputValid(string input) // üçüncü inputta ise hiç boşluk olmaması lazım. Bunun kontrolü yapılıyor.
        {

            if (input.Contains(' '))
            {
                throw new Exception("Invalid Input");

            }
            else
            {
                return true;
            }


        }
    }

    public class Plato
    {
        private int x_coordinate;
        private int y_coordinate;

        public Plato(int x_coordinate, int y_coordinate)
        {
            if(x_coordinate <= 0 || y_coordinate<= 0) // (0,0) noktası sol alt köşe kabul edildiğinden x ve y negatif olamaz. Sıfıra da eşit olamaz
            {                                          // çünkü o zaman plato alanı olmaz.
                throw new ArgumentOutOfRangeException("Plato values can not be equal or less than 0 ");
            }
            else
            {
                
                this.x_coordinate = x_coordinate ;
                this.y_coordinate = y_coordinate ;
               
            }
        }
       
        public char MoveToLeft(char initial) // 'L' komutu geldiğinde
        {
            if (initial.Equals('N'))
                initial = 'W';
            else if (initial.Equals('W'))
                initial = 'S';
            else if (initial.Equals('S'))
                initial = 'E';
            else if (initial.Equals('E'))
                initial = 'N';
            return initial;
        }
        public char MoveToRight(char initial) // 'R' komutu geldiğinde
        {
            if (initial.Equals('N'))
                initial = 'E';
            else if (initial.Equals('E'))
                initial = 'S';
            else if (initial.Equals('S'))
                initial = 'W';
            else if (initial.Equals('W'))
                initial = 'N';
            return initial;

        }
       
        public void Travelling(int x, int y, char location, string direction) // parametre sırasıyla: x koordinatı, y koordinatı, pusula yönleri, üçüncü input
        {

            for (int i = 0; i < direction.Length; i++) // üçüncü input harfleri sırasıyla geziliyor
            {
                if (direction[i].Equals('L'))
                {
                    location = MoveToLeft(location);
                }
                else if (direction[i].Equals('R'))
                {
                    location = MoveToRight(location);
                }
                else if (direction[i].Equals('M')) // eğer hareket ettiriliyorsa gittiği yönde koordinat noktaları ayarlanıyor.
                {
                    
                   if (location.Equals('N'))
                            y++;
                   else if (location.Equals('W'))
                            x--;
                   else if (location.Equals('S'))
                            y--;
                   else if (location.Equals('E'))
                            x++;
                    
                   if (y < 0 || y > y_coordinate || x < 0 || x > x_coordinate) // burda platonun sınırlarının dışına çıkılıp çıkılmadığı kontrol ediliyor.
                   {
                        throw new ArgumentOutOfRangeException(" Traveller out of the plato");
                   }



                }
            }

            Console.WriteLine(x + " " + y+ " " + location);
            Console.WriteLine("This traveller finished.");


        }

        

        static void Main(string[] args)
        {
            int traveller = 1;

            int x_plato = 0;
            int y_plato = 0;
            string first_input;
            Console.WriteLine("Please enter the top-rigth coordinates:");
            first_input = Console.ReadLine();

            Validation validation = new Validation();

            if(validation.isFirstInputValid(first_input) == true) { 
            
               string[] plato_coordinates = first_input.Split(' ');
                x_plato = Convert.ToInt32(plato_coordinates[0]);
                y_plato = Convert.ToInt32(plato_coordinates[1]);
            }
           

            Plato plato = new Plato(x_plato, y_plato); // ilk input değerlerine göre plato oluşturuluyor.
         

            string[] start_points = null;
            string input = "";

            while(true)
            {
                Console.WriteLine("Please enter the start location for the " + traveller + ". traveller:");
                input = Console.ReadLine();
                start_points = input.Split(' ');
                if(validation.isSecondInputValid(start_points) == true)
                {
                 
                    int x = Convert.ToInt32(start_points[0]);
                    int y = Convert.ToInt32(start_points[1]);
                    char direction = Convert.ToChar(start_points[2]);
                    Console.WriteLine("Please enter the instructions:");
                    input = Console.ReadLine();
                    if(validation.isThirdInputValid(input) == true)
                    {
                        
                        plato.Travelling(x, y, direction, input);
                    }

                }
                traveller++;
                
                     
            }


            
        }
    }

}
