using System;
using WindowsInput;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Vankae
{
    internal class NewRoyale
    {
        public void StartToFarm()
        {
            Console.WriteLine("Select the elixir bar: ");
            Console.ReadKey();
            Point elixirBar = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select first card: ");
            Console.ReadKey();
            Point card0 = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select second card: ");
            Console.ReadKey();
            Point card1 = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select third card: ");
            Console.ReadKey();
            Point card2 = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select fourth card: ");
            Console.ReadKey();
            Point card3 = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select the troop placement: ");
            Console.ReadKey();
            Point placement = new Point(Cursor.Position.X, Cursor.Position.Y);
            Console.WriteLine("Select the spell placement: ");
            Console.ReadKey();
            Point spellPlacement = new Point(Cursor.Position.X, Cursor.Position.Y);

            ImageComparer arrowsComparer = new ImageComparer("arrows.png");
            ImageComparer giantComparer = new ImageComparer("giant.png");
            ImageComparer gobhutComparer = new ImageComparer("gobhut.png");
            Methods methods = new Methods();
            Random random = new Random();
            InputSimulator input = new InputSimulator();

            Point[] cards = new Point[] { card0, card1, card2, card3 };

            while(true)
            {
                while(methods.GetPixelColor(elixirBar.X, elixirBar.Y).R < 200) 
                { // nothing to do
                }

                arrowsComparer.Compare();
                giantComparer.Compare();
                gobhutComparer.Compare();
                Console.WriteLine("arrows: " + arrowsComparer.Percentage);
                Thread.Sleep(200);

                if(giantComparer.IsSuitable)
                {
                    Cursor.Position = giantComparer.Location;
                    input.Mouse.LeftButtonClick();
                    Cursor.Position = new Point(placement.X + random.Next(-5, 5), placement.Y + random.Next(-5, 5));
                    input.Mouse.LeftButtonClick();
                }
                else if(arrowsComparer.IsSuitable)
                {
                    Cursor.Position = arrowsComparer.Location;
                    input.Mouse.LeftButtonClick();
                    Cursor.Position = spellPlacement;
                    input.Mouse.LeftButtonClick();
                }
                else if(gobhutComparer.IsSuitable)
                {
                    Cursor.Position = gobhutComparer.Location;
                    input.Mouse.LeftButtonClick();
                    Cursor.Position = new Point(placement.X + random.Next(-5, 5), placement.Y + random.Next(-5, 5));
                    input.Mouse.LeftButtonClick();
                }
                else
                {
                    Cursor.Position = cards[random.Next(0, cards.Length)];
                    input.Mouse.LeftButtonClick();
                    Cursor.Position = new Point(placement.X + random.Next(-5, 5), placement.Y + random.Next(-5, 5));
                    input.Mouse.LeftButtonClick();
                }
            }
        }
    }
}