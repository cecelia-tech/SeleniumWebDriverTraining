﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects;

public interface ILoad
{
    public void LoadPage();
    public bool IsPageLoaded();
}
