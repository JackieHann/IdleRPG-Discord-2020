﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IdleRPG_JH.Bots
{
    public sealed class Singleton
    {
        Singleton()
        {
        }
        private static readonly object padlock = new object();
        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
        public void Instantiate()
        { 
        
        }
    }
}
