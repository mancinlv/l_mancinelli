﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.UI.Workflows;


namespace FlooringProgram.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new MainMenu();
            menu.Execute();

        }
    }
}
