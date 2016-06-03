﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.ast
{
    public class InsertNodeInDynamicList : InsertStrategy
    {
        public List<PythonNode> Insert(PythonNode context, PythonNode inserted, int index)
        {
            var newList = new List<PythonNode>();
            newList.AddRange(context.Children);
            if (index > context.Children.Count)
                throw new TransformationNotApplicableExpection();
            newList.Insert(index, inserted);
            return newList;
        }
    }

    public class TransformationNotApplicableExpection : Exception
    {
    }
}
