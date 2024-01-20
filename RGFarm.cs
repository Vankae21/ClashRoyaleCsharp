using System;
using WindowsInput;
using WindowsInput.Native;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;

namespace Vankae;
internal class RGFarm
{

        public void StartToFarm()
        {
            Console.WriteLine("Select RGelixir bar");
            Console.ReadKey();
            Point RGelixirPos = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select first card");
            Console.ReadKey();
            Point card0 = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select second card");
            Console.ReadKey();
            Point card1 = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select third card");
            Console.ReadKey();
            Point card2 = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select fourth card");
            Console.ReadKey();
            Point card3 = new Point(Cursor.Position.X, Cursor.Position.Y);

            Console.WriteLine("Select rgPos placement");
            Console.ReadKey();
            Point rgPos = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select spellPos placement");
            Console.ReadKey();
            Point spellPos = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select midPos placement");
            Console.ReadKey();
            Point midPos = new Point(Cursor.Position.X, Cursor.Position.Y);

            Point[] cards = { card0, card1, card2, card3 };
            Random random = new Random();
            InputSimulator input = new InputSimulator();
            ImageComparer rgComparer = new ImageComparer("rg.png");
            ImageComparer eqComparer = new ImageComparer("eq.png");
            ImageComparer logComparer = new ImageComparer("log.png");
            ImageComparer rageComparer = new ImageComparer("rage.png");

            Methods methods = new Methods();
            
            while (true)
            {
                rgComparer.Compare();
                eqComparer.Compare();
                logComparer.Compare();
                rageComparer.Compare();
                Console.WriteLine("There is RG" + rgComparer.IsSuitable);
            //    Thread.Sleep(100);
               if (rgComparer.IsSuitable)
               {
                while(methods.GetPixelColor(RGelixirPos.X, RGelixirPos.Y).R < 200) {}

                        Cursor.Position = rgComparer.Location;
                        input.Mouse.LeftButtonClick();
                        Cursor.Position = new Point(rgPos.X + random.Next(-5, 5), rgPos.Y + random.Next(-5, 5));
                        input.Mouse.LeftButtonClick();
                        Console.WriteLine("RG is coming");
                        Thread.Sleep(1000);
               }
               else{
                    if(eqComparer.IsSuitable)
                    {
                        Cursor.Position = eqComparer.Location;
                        input.Mouse.LeftButtonClick();
                        Cursor.Position = new Point(spellPos.X + random.Next(-5, 5), spellPos.Y + random.Next(-5, 5));
                        input.Mouse.LeftButtonClick();
                        Console.WriteLine("EQ is coming");
                    }
                    else if(logComparer.IsSuitable)
                    {
                        Cursor.Position = logComparer.Location;
                        input.Mouse.LeftButtonClick();
                        Cursor.Position = new Point(spellPos.X + random.Next(-5, 5), spellPos.Y + random.Next(-5, 5));
                        input.Mouse.LeftButtonClick();
                        Console.WriteLine("Log is coming");
                    }
                    else if(rageComparer.IsSuitable)
                    {
                        Cursor.Position = rageComparer.Location;
                        input.Mouse.LeftButtonClick();
                        Cursor.Position = new Point(spellPos.X + random.Next(-5, 5), spellPos.Y + random.Next(-5, 5));
                        input.Mouse.LeftButtonClick();
                        Console.WriteLine("Rage is coming");
                    }
                    else
                    {
                        Cursor.Position = cards[random.Next(cards.Length)];
                        input.Mouse.LeftButtonClick();
                        Cursor.Position = new Point(midPos.X + random.Next(-5, 5), midPos.Y + random.Next(-5, 5));
                        input.Mouse.LeftButtonClick();
                        Console.WriteLine("Something is coming");
                    }
               }}
            }
    }

