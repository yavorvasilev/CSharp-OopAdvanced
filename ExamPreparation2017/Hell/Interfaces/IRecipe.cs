﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IRecipe : IItem
{
    List<string> RequiredItems { get; set; }
}
