﻿/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Compiler.Ast;

namespace Tutor.ast
{
    class BinaryExpressionNode : InternalNode
    {
        public BinaryExpressionNode(Node innerNode) : base(innerNode)
        {
            InsertStrategy = new InsertFixedList();
        }

        protected override bool IsEqualToInnerNode(Node node)
        {
            var comparedNode = node as BinaryExpression;
            return comparedNode != null && ((BinaryExpression)InnerNode).Operator.Equals(comparedNode.Operator);
        }

        public override PythonNode Clone()
        {
            var pythonNode = new BinaryExpressionNode(InnerNode);
            pythonNode.Children = Children;
            pythonNode.Id = Id;
            if (Value != null) pythonNode.Value = Value;
            return pythonNode;
        }       
    }
}
*/
