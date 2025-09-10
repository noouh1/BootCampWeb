﻿using System.Data;

namespace WebApplication1.AppMetaData.BaseRouter
{
    public partial class Router
    {
        public class StudentRouter : Router
        {
            private const string Prefix = Rule + "Student";
            public const string Main = Prefix + "/";
            public const string MainId = Prefix + "/{id}";
        }
    }
  
}