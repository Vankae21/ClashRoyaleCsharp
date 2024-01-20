using System;
using WindowsInput;
using WindowsInput.Native;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;

namespace Vankae;
class Program
{
    static void Main(string[] args)
    {
        NewRoyale newRoyale = new NewRoyale();
        newRoyale.StartToFarm();
    }
}
