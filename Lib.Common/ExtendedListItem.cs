﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Lib.Common
{
    public class ExtendedSelectListItem : SelectListItem
    {
        public object htmlAttributes { get; set; }
    }

    public static partial class HtmlHelperExtensions
    {
        
    }
}